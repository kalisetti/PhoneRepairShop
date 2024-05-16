using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PX.Data;
using PX.Data.BQL.Fluent;
using PX.Objects.IN;

namespace PhoneRepairShop
{
    public class RSSVRepairPriceMaint : PXGraph<RSSVRepairPriceMaint, RSSVRepairPrice>
    {
        public SelectFrom<RSSVRepairPrice>.View RepairPrices;
        public SelectFrom<RSSVRepairItem>.
            LeftJoin<InventoryItem>.
                On<InventoryItem.inventoryID.IsEqual<RSSVRepairItem.inventoryID.FromCurrent>>.
            Where<RSSVRepairItem.deviceID.IsEqual<RSSVRepairPrice.deviceID.FromCurrent>.
                And<RSSVRepairItem.serviceID.IsEqual<RSSVRepairPrice.serviceID.FromCurrent>>>.View RepairItems;
        
        // Update price and repair item type when inventory ID of repair item
        // is updated.
        protected void _(Events.FieldUpdated<RSSVRepairItem, RSSVRepairItem.inventoryID> e)
        {
            RSSVRepairItem row = e.Row;

            if (row.InventoryID != null)
            {
                // Use the PXSelector attribute to select the stock item.
                InventoryItem item = PXSelectorAttribute.Select<RSSVRepairItem.inventoryID>(e.Cache, row) as InventoryItem;

                // Copy the base price from the stock item to the row.
                row.BasePrice = item.BasePrice;

                // Retrieve the extension fields.
                InventoryItemExt itemExt = PXCache<InventoryItem>.GetExtension<InventoryItemExt>(item);
                if (itemExt != null)
                {
                    // Copy the repair item type from the stock item to the row.
                    row.RepairItemType = itemExt.UsrRepairItemType;
                }
            }
        }

        // Update the IsDefault field of other records with the same repair item type
        // when the IsDefault field is updated.
        protected void _(Events.RowUpdated<RSSVRepairItem> e)
        {
            RSSVRepairItem row = e.Row;

            // Use LINQ to select the repair items with the same repair item type
            // as in the updated row.
            var repairItems = RepairItems.Select().Where(item =>
                    item.GetItem<RSSVRepairItem>().RepairItemType == row.RepairItemType);

            foreach (RSSVRepairItem repairItem in repairItems)
            {
                if (repairItem.LineNbr != row.LineNbr)
                {
                    // Set IsDefault to false for all other items.
                    if (row.IsDefault == true)
                    {
                        repairItem.IsDefault = false;
                        RepairItems.Update(repairItem);
                    }

                    // Make the Required field identical for all items.
                    if (row.Required != e.OldRow.Required && row.Required != repairItem.Required)
                    {
                        repairItem.Required = row.Required;
                        RepairItems.Update(repairItem);
                    }
                }
            }

            // Refresh the UI.
            RepairItems.View.RequestRefresh();
        }

        // Update the Required check box when a repair item type is selected.
        protected void _(Events.FieldUpdated<RSSVRepairItem, RSSVRepairItem.repairItemType> e)
        {
            RSSVRepairItem row = e.Row;

            // Use LINQ to check whether there are any repair items with the same
            // repair item type.
            var repairItem = (RSSVRepairItem)RepairItems.Select().Where(item =>
                    item.GetItem<RSSVRepairItem>().RepairItemType == row.RepairItemType).FirstOrDefault();

            // Copy the Required value from the previous records.
            if (repairItem != null)
            {
                row.Required = repairItem.Required;
            }

        }
    }
}