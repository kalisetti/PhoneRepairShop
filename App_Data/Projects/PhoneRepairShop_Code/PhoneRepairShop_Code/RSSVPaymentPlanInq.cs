using System;
using System.Collections;
using PX.Data;
using PX.Data.BQL;
using PX.Data.BQL.Fluent;
using PX.Objects.AR;
using PX.Objects.SO;

namespace PhoneRepairShop {
	public class RSSVPaymentPlanInq : PXGraph<RSSVPaymentPlanInq> {

		#region Data Views
		//[PXFilterable]
		//public SelectFrom<RSSVWorkOrderToPay>.
		//	InnerJoin<ARInvoice>.On<ARInvoice.refNbr.IsEqual<RSSVWorkOrderToPay.invoiceNbr>>.
		//	Where<RSSVWorkOrderToPay.status.IsNotEqual<workOrderStatusPaid>>.View.ReadOnly DetailsView;

		[PXFilterable]
		public SelectFrom<RSSVWorkOrderToPay>.
			InnerJoin<ARInvoice>.On<ARInvoice.refNbr.IsEqual<RSSVWorkOrderToPay.invoiceNbr>>.
			Where<RSSVWorkOrderToPay.status.IsNotEqual<workOrderStatusPaid>.
				And<RSSVWorkOrderToPayFilter.customerID.FromCurrent.IsNull.
					Or<RSSVWorkOrderToPay.customerID.IsEqual<RSSVWorkOrderToPayFilter.customerID.FromCurrent>>
				>.
				And<RSSVWorkOrderToPayFilter.serviceID.FromCurrent.IsNull.
					Or<RSSVWorkOrderToPay.serviceID.IsEqual<RSSVWorkOrderToPayFilter.serviceID.FromCurrent>>
				>
			>.View.ReadOnly DetailsView;

		public PXFilter<RSSVWorkOrderToPayFilter> Filter;
		#endregion

		#region Actions
		public PXCancel<RSSVWorkOrderToPayFilter> Cancel;
		#endregion

		public override bool IsDirty {
			get {
				return false;
			}
		}

		public static RSSVWorkOrderToPay RSSVWorkOrderToPay(SOOrderShipment shipment) {
			RSSVWorkOrderToPay ret = new RSSVWorkOrderToPay();
			ret.OrderNbr = shipment.OrderNbr;
			ret.InvoiceNbr = shipment.InvoiceNbr;
			return ret;
		}

		// Data view delegate to query data dynamically from multiple sources
		protected virtual IEnumerable detailsView() {
			BqlCommand query;
			var filter = Filter.Current;
			if (filter.GroupByStatus != true) {
				query = new SelectFrom<RSSVWorkOrderToPay>.
								InnerJoin<ARInvoice>.
									On<ARInvoice.refNbr.IsEqual<RSSVWorkOrderToPay.invoiceNbr>>.
							Where<RSSVWorkOrderToPay.status.IsNotEqual<workOrderStatusPaid>.
								And<RSSVWorkOrderToPayFilter.customerID.FromCurrent.IsNull.
									Or<RSSVWorkOrderToPay.customerID.IsEqual<RSSVWorkOrderToPayFilter.customerID.FromCurrent>>
								>.
								And<RSSVWorkOrderToPayFilter.serviceID.FromCurrent.IsNull.
									Or<RSSVWorkOrderToPay.serviceID.IsEqual<RSSVWorkOrderToPayFilter.serviceID.FromCurrent>>
								>
							>();
			}
			else {
				query = new SelectFrom<RSSVWorkOrderToPay>.
								InnerJoin<ARInvoice>.
									On<ARInvoice.refNbr.IsEqual<RSSVWorkOrderToPay.invoiceNbr>>.
							Where<RSSVWorkOrderToPay.status.IsNotEqual<workOrderStatusPaid>.
								And<RSSVWorkOrderToPayFilter.customerID.FromCurrent.IsNull.
									Or<RSSVWorkOrderToPay.customerID.IsEqual<RSSVWorkOrderToPayFilter.customerID.FromCurrent>>
								>.
								And<RSSVWorkOrderToPayFilter.serviceID.FromCurrent.IsNull.
									Or<RSSVWorkOrderToPay.serviceID.IsEqual<RSSVWorkOrderToPayFilter.serviceID.FromCurrent>>
								>
							>.
							AggregateTo<GroupBy<RSSVWorkOrderToPay.status>, Sum<ARInvoice.curyDocBal>>();
			}

			var view = new PXView(this, true, query);
			foreach (PXResult<RSSVWorkOrderToPay, ARInvoice> order in view.SelectMulti(null)) {
				yield return order;
			}

			//foreach (PXResult<RSSVWorkOrderToPay, ARInvoice> order in
			//				SelectFrom<RSSVWorkOrderToPay>.
			//					InnerJoin<ARInvoice>.
			//						On<ARInvoice.refNbr.IsEqual<RSSVWorkOrderToPay.invoiceNbr>>.
			//				Where<RSSVWorkOrderToPay.status.IsNotEqual<workOrderStatusPaid>.
			//					And<RSSVWorkOrderToPayFilter.customerID.FromCurrent.IsNull.
			//						Or<RSSVWorkOrderToPay.customerID.IsEqual<RSSVWorkOrderToPayFilter.customerID.FromCurrent>>
			//					>.
			//					And<RSSVWorkOrderToPayFilter.serviceID.FromCurrent.IsNull.
			//						Or<RSSVWorkOrderToPay.serviceID.IsEqual<RSSVWorkOrderToPayFilter.serviceID.FromCurrent>>
			//					>
			//				>.View.Select(this)
			//) {
			//	yield return order;
			//}

			var sorders = SelectFrom<SOOrderShipment>.
				InnerJoin<ARInvoice>.
					On<ARInvoice.refNbr.IsEqual<SOOrderShipment.invoiceNbr>>.
				Where<RSSVWorkOrderToPayFilter.customerID.FromCurrent.IsNull.
					Or<SOOrderShipment.customerID.IsEqual<RSSVWorkOrderToPayFilter.customerID.FromCurrent>>
				>.View.Select(this);

			foreach (PXResult<SOOrderShipment, ARInvoice> order in sorders) {
				SOOrderShipment soshipment = order;
				ARInvoice invoice = order;

				RSSVWorkOrderToPay workOrder = RSSVWorkOrderToPay(soshipment);
				workOrder.OrderType = OrderTypeConstants.SalesOrder;

				var result = new PXResult<RSSVWorkOrderToPay, ARInvoice>(workOrder, invoice);
				yield return result;
			}
		}

		#region Actions
		// T250 - Step 1.5.2: Add a Link by Using an Action
		// This will allow us to open SO & WO respectively when clicked on orderNbr
		public PXAction<RSSVWorkOrderToPay> ViewOrder;
		[PXButton]
		[PXUIField]
		protected virtual void viewOrder() {
			RSSVWorkOrderToPay order = DetailsView.Current;

			// if this is a repair work order
			if (order.OrderType == OrderTypeConstants.WorkOrder) {
				// create a new instance of the graph
				var graph = PXGraph.CreateInstance<RSSVWorkOrderEntry>();

				// set the current property of the graph
				graph.WorkOrders.Current = graph.WorkOrders.Search<RSSVWorkOrder.orderNbr>(order.OrderNbr);

				// if the order is found by its ID,
				// throw an exception to open the order in a new tab
				if (graph.WorkOrders.Current != null) {
					throw new PXRedirectRequiredException(graph, true, "Repair Work Order Details");
				}
			}
			// if this is a sales order
			else {
				// create a new instance of the graph
				var graph = PXGraph.CreateInstance<SOOrderEntry>();

				// set the current property of the graph
				graph.Document.Current = graph.Document.Search<RSSVWorkOrder.orderNbr>(order.OrderNbr);

				// if the order is found by its ID,
				// throw an exception to open the order in a new tab
				if (graph.Document.Current != null) {
					throw new PXRedirectRequiredException(graph, true, "Sales Order Details");
				}
			}
		}
		#endregion

		#region Event Handlers
		protected virtual void _(Events.FieldSelecting<RSSVWorkOrderToPay, RSSVWorkOrderToPay.percentPaid> e) {
			if (e.Row == null) return;
			if (e.Row.OrderTotal == 0) return;

			RSSVWorkOrderToPay order = e.Row;
			var invoices = SelectFrom<ARInvoice>.
				Where<ARInvoice.refNbr.IsEqual<@P.AsString>>.View.Select(this, order.InvoiceNbr);
			if (invoices.Count == 0) return;

			ARInvoice first = invoices[0];
			e.ReturnValue = (order.OrderTotal - first.CuryDocBal) / order.OrderTotal * 100;
		}
		#endregion

		#region Data Access Classes
		[PXHidden]
		public class RSSVWorkOrderToPayFilter : IBqlTable {
			#region ServiceID
			[PXInt]
			[PXUIField(DisplayName = "Service")]
			[PXSelector(
				typeof(Search<RSSVRepairService.serviceID>),
				typeof(RSSVRepairService.serviceCD),
				typeof(RSSVRepairService.description),
				DescriptionField = typeof(RSSVRepairService.description),
				SelectorMode = PXSelectorMode.DisplayModeText
			)]
			public virtual int? ServiceID { get; set; }
			public abstract class serviceID : PX.Data.BQL.BqlInt.Field<serviceID> { }
			#endregion

			#region CustomerID
			[CustomerActive(DisplayName = "Customer ID", Required = true)]
			public virtual int? CustomerID { get; set; }
			public abstract class customerID : PX.Data.BQL.BqlInt.Field<customerID> { }
			#endregion

			#region GroupByStatus
			[PXBool]
			[PXUIField(DisplayName = "Show Total Amount to Pay")]
			public bool? GroupByStatus { get; set; }
			public abstract class groupByStatus : PX.Data.BQL.BqlBool.Field<groupByStatus> { }
			#endregion
		}
		#endregion
	}
}