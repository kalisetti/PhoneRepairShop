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

		// Copy repair items and labor items from the Services and Prices form.
		protected virtual void _(Events.RowUpdated<RSSVWorkOrder> e) {
			RSSVWorkOrder order = e.Row;
			if (order == null) return;
			if (WorkOrders.Cache.GetStatus(order) == PXEntryStatus.Inserted &&
				RepairItems.Select().Count == 0 && Labor.Select().Count == 0) {
				if (order.DeviceID != null && order.ServiceID != null) {
					// Retrieve the default repair items
					var repairItems = SelectFrom<RSSVRepairItem>.
						Where<RSSVRepairItem.deviceID.IsEqual<RSSVWorkOrder.deviceID.FromCurrent>.
						And<RSSVRepairItem.serviceID.IsEqual<RSSVWorkOrder.serviceID.FromCurrent>>>.View.Select(this);

					// Insert default repair items
					if (repairItems != null) {
						foreach (RSSVRepairItem item in repairItems) {
							RSSVWorkOrderItem orderItem = RepairItems.Insert(new RSSVWorkOrderItem());
							orderItem.RepairItemType = item.RepairItemType;
							orderItem.InventoryID = item.InventoryID;
							orderItem.BasePrice = item.BasePrice;
							orderItem.LineNbr = item.LineNbr;

							RepairItems.Update(orderItem);
						}
					}

					// Retrive the default labor items
					var laborItems = SelectFrom<RSSVLabor>.
						Where<RSSVLabor.deviceID.IsEqual<RSSVWorkOrder.deviceID.FromCurrent>.
						And<RSSVLabor.serviceID.IsEqual<RSSVWorkOrder.serviceID.FromCurrent>>>.View.Select(this);

					// Insert the default labor items
					if (laborItems != null) {
						foreach (RSSVLabor item in laborItems) {
							RSSVWorkOrderLabor orderItem = Labor.Insert(new RSSVWorkOrderLabor());
							orderItem.InventoryID = item.InventoryID;
							orderItem.DefaultPrice = item.DefaultPrice;
							orderItem.Quantity = item.Quantity;
							orderItem.ExtPrice = item.ExtPrice;

							Labor.Update(orderItem);
						}
					}
				}
			}
		}

		// Update price and repair item type when inventory ID of repair item
		// is updated.
		protected void _(Events.FieldUpdated<RSSVWorkOrderItem, RSSVWorkOrderItem.inventoryID> e) {
			RSSVWorkOrderItem row = e.Row;

			if (row.InventoryID != null) {
				// Use the PXSelector attribute to select the stock item.
				InventoryItem item = PXSelectorAttribute.Select<RSSVWorkOrderItem.inventoryID>(e.Cache, row) as InventoryItem;

				// Copy the base price from the stock item to the row.
				row.BasePrice = item.BasePrice;

				// Retrive the extension fields.
				InventoryItemExt itemExt = PXCache<InventoryItem>.GetExtension<InventoryItemExt>(item);
				if (itemExt != null) {
					// Copy the repair item type from the stock item to the row.
					row.RepairItemType = itemExt.UsrRepairItemType;
				}
			}
		}

		// Change the status based on whether the Hold check box is select or cleared
		protected virtual void _(Events.FieldUpdated<RSSVWorkOrder, RSSVWorkOrder.hold> e) {
			RSSVWorkOrder row = e.Row;

			// If Hold is cleared, specify the status depending on the Prepayment field
			// of the service
			if (row.Hold == false) {
				RSSVRepairService service = (RSSVRepairService)SelectFrom<RSSVRepairService>.
					Where<RSSVRepairService.serviceID.IsEqual<RSSVWorkOrder.serviceID.FromCurrent>>.View.Select(this);

				if (service != null && service.Prepayment == true)
					e.Cache.SetValueExt<RSSVWorkOrder.status>(e.Row, WorkOrderStatusConstants.PendingPayment);
				if (service != null && service.Prepayment == false)
					e.Cache.SetValueExt<RSSVWorkOrder.status>(e.Row, WorkOrderStatusConstants.ReadyForAssignment);
			}

			// If Hold is selected, change the status to On Hold
			if (row.Hold == true)
				e.Cache.SetValueExt<RSSVWorkOrder.status>(e.Row, WorkOrderStatusConstants.OnHold);
		}
	}
}