using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using PX.Api.Models;
using PX.Common;
using PX.Data;
using PX.Objects.AP;
using PX.Objects.AR;
using PX.Objects.CR;
using PX.Objects.CS;
using PX.Objects.DR;
using PX.Objects.GL;
using PX.Objects.PO;
using PX.Objects.RUTROT;
using PX.Objects.SO;
using PX.Objects.Common.Discount;
using PX.SM;
using PX.Web.UI;
using CRLocation = PX.Objects.CR.Standalone.Location;
using ItemStats = PX.Objects.IN.Overrides.INDocumentRelease.ItemStats;
using SiteStatus = PX.Objects.IN.Overrides.INDocumentRelease.SiteStatus;
using PX.Objects;
using PX.Objects.IN;

using PhoneRepairShop;
using PX.Data.BQL;
using PX.Data.BQL.Fluent;

namespace PX.Objects.IN
{
    public class InventoryItemMaint_Extension : PXGraphExtension<InventoryItemMaint>
    {
        public SelectFrom<RSSVStockItemDevice>.
            LeftJoin<RSSVDevice>.
            On<RSSVStockItemDevice.deviceID.IsEqual<RSSVDevice.deviceID>>.
            Where<RSSVStockItemDevice.inventoryID.IsEqual<
                InventoryItem.inventoryID.FromCurrent>>.View CompatibleDevices;

        #region Event Handlers

        protected void _(Events.RowSelected<InventoryItem> e)
        {

            InventoryItem item = e.Row;
            InventoryItemExt itemExt = PXCache<InventoryItem>.GetExtension<InventoryItemExt>(item);
            bool enableFields = itemExt != null && itemExt.UsrRepairItem == true;

            // Make the Repair Item Type box available
            // when the Repair Item check box is selected.
            PXUIFieldAttribute.SetEnabled<InventoryItemExt.usrRepairItemType>(e.Cache, e.Row, enableFields);

            // Display the Compatible Devices tab when the Repair Item check box
            // is selected.
            CompatibleDevices.Cache.AllowSelect = enableFields;
        }



        #endregion
    }
}