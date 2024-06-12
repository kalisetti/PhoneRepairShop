using System;
using PX.Data;
using PX.Data.BQL;
using PX.Data.BQL.Fluent;
using PX.Objects.AR;

namespace PhoneRepairShop {
	public class RSSVPaymentPlanInq : PXGraph<RSSVPaymentPlanInq> {

		#region Data Views
		[PXFilterable]
		public SelectFrom<RSSVWorkOrderToPay>.
			InnerJoin<ARInvoice>.On<ARInvoice.refNbr.IsEqual<RSSVWorkOrderToPay.invoiceNbr>>.
			Where<RSSVWorkOrderToPay.status.IsNotEqual<workOrderStatusPaid>>.View.ReadOnly DetailsView;
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
		}
		#endregion
	}
}