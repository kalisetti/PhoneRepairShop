using System;
using PX.Data;
using PX.Data.BQL.Fluent;

namespace PhoneRepairShop {
	public class RSSVAssignProcess : PXGraph<RSSVAssignProcess> {

		public PXCancel<RSSVWorkOrder> Cancel;
		public PXProcessing<RSSVWorkOrder,
			Where<RSSVWorkOrder.status.IsEqual<workOrderStatusReadyForAssignment>>> WorkOrders;

		public RSSVAssignProcess() {
			WorkOrders.SetProcessCaption("Assign");
			WorkOrders.SetProcessAllCaption("Assign All");
			WorkOrders.SetProcessDelegate<RSSVWorkOrderEntry>(
				delegate (RSSVWorkOrderEntry graph, RSSVWorkOrder order) {
					try {
						graph.Clear();
						graph.AssignOrder(order, true);
					}
					catch (Exception e) {
						PXProcessing<RSSVWorkOrder>.SetError(e);
					}
				}
			);
		}

	}
}