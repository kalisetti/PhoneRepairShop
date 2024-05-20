using System;
using PX.Data;
using PX.Data.BQL.Fluent;
using PX.Objects.IN;

namespace PhoneRepairShop {
	public class RSSVWorkOrderEntry : PXGraph<RSSVWorkOrderEntry> {

		public PXSave<RSSVWorkOrder> Save;
		public PXCancel<RSSVWorkOrder> Cancel;

		// Views
		// The primary view
		public SelectFrom<RSSVWorkOrder>.View WorkOrders;

		// The view for the repair items tab
		public SelectFrom<RSSVWorkOrderItem>.
			LeftJoin<InventoryItem>.
				On<InventoryItem.inventoryID.IsEqual<RSSVWorkOrderItem.inventoryID.FromCurrent>>.
			Where<RSSVWorkOrderItem.orderNbr.IsEqual<RSSVWorkOrder.orderNbr.FromCurrent>>.View RepairItems;

		// The view for the labor tab
		public SelectFrom<RSSVWorkOrderLabor>.
			LeftJoin<InventoryItem>.
				On<InventoryItem.inventoryID.IsEqual<RSSVWorkOrderLabor.inventoryID.FromCurrent>>.
			Where<RSSVWorkOrderLabor.orderNbr.IsEqual<RSSVWorkOrder.orderNbr.FromCurrent>>.View Labor;

	}
}