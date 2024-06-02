using System;
using PX.Data;
using PX.Data.BQL.Fluent;

namespace PhoneRepairShop {
	public class RSSVAssignProcess : PXGraph<RSSVAssignProcess> {
		#region RSSVWorkOrderToAssignFilter
		[PXHidden]
		public class RSSVWorkOrderToAssignFilter : IBqlTable {
			#region Priority
			[PXString(20)]
			[PXUIField(DisplayName = "Priority")]
			[PXStringList(
				new string[] {
					WorkOrderPriorityConstants.High,
					WorkOrderPriorityConstants.Medium,
					WorkOrderPriorityConstants.Low,
				},
				new string[] {
					Messages.High,
					Messages.Medium,
					Messages.Low,
				}
			)]
			public virtual string Priority { get; set; }
			public abstract class priority : PX.Data.BQL.BqlString.Field<priority> { }
			#endregion

			#region TimeWithoutAction
			[PXInt]
			[PXDefault(0, PersistingCheck = PXPersistingCheck.Nothing)]
			[PXUIField(DisplayName = "Minimum Number of Days Unassigned")]
			public virtual int? TimeWithoutAction { get; set; }
			public abstract class timeWithoutAction : PX.Data.BQL.BqlInt.Field<timeWithoutAction> { }
			#endregion

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
		}
		#endregion

		public PXFilter<RSSVWorkOrderToAssignFilter> Filter;

		public PXCancel<RSSVWorkOrderToAssignFilter> Cancel;

		//public PXProcessing<RSSVWorkOrder,
		//	Where<RSSVWorkOrder.status.IsEqual<workOrderStatusReadyForAssignment>>> WorkOrders;

		public PXFilteredProcessing<RSSVWorkOrderToAssign, RSSVWorkOrderToAssignFilter,
			Where<RSSVWorkOrderToAssign.status.IsEqual<workOrderStatusReadyForAssignment>.
				And<RSSVWorkOrderToAssign.timeWithoutAction.IsGreaterEqual<RSSVWorkOrderToAssignFilter.timeWithoutAction.FromCurrent>.
					And<RSSVWorkOrderToAssign.priority.IsEqual<RSSVWorkOrderToAssignFilter.priority.FromCurrent>.
						Or<RSSVWorkOrderToAssignFilter.priority.FromCurrent.IsNull>>.
					And<RSSVWorkOrderToAssign.serviceID.IsEqual<RSSVWorkOrderToAssignFilter.serviceID.FromCurrent>.
						Or<RSSVWorkOrderToAssignFilter.serviceID.FromCurrent.IsNull>>
				>
			>,
			OrderBy<Desc<RSSVWorkOrderToAssign.timeWithoutAction, RSSVWorkOrderToAssign.priority.Desc>>
		> WorkOrders;

		public RSSVAssignProcess() {
			WorkOrders.SetProcessCaption("Assign");
			WorkOrders.SetProcessAllCaption("Assign All");
			WorkOrders.SetProcessDelegate<RSSVWorkOrderEntry>(
				delegate (RSSVWorkOrderEntry graph, RSSVWorkOrderToAssign order) {
					try {
						graph.Clear();
						graph.AssignOrder(order, true);
					}
					catch (Exception e) {
						PXProcessing<RSSVWorkOrderToAssign>.SetError(e);
					}
				}
			);

			PXUIFieldAttribute.SetEnabled<RSSVWorkOrderToAssign.assignTo>(
				WorkOrders.Cache, null, true);
		}

		public override bool IsDirty {
			get {
				return false;
			}
		}
	}
}