using System;
using PX.Data;
using PX.Data.BQL.Fluent;
using PX.Objects.IN;

namespace PhoneRepairShop {
	[Serializable]
	[PXCacheName("Work Order Labor")]
	public class RSSVWorkOrderLabor : IBqlTable {
		#region OrderNbr
		[PXDBString(15, IsKey = true, IsUnicode = true, InputMask = "")]
		//[PXUIField(DisplayName = "Order Nbr")]
		[PXDBDefault(typeof(RSSVWorkOrder.orderNbr))]
		[PXParent(typeof(SelectFrom<RSSVWorkOrder>.
				Where<RSSVWorkOrder.orderNbr.IsEqual<RSSVWorkOrderLabor.orderNbr.FromCurrent>>)
			)]
		public virtual string OrderNbr { get; set; }
		public abstract class orderNbr : PX.Data.BQL.BqlString.Field<orderNbr> { }
		#endregion

		#region InventoryID
		//[PXDBInt(IsKey = true)]
		[PXUIField(DisplayName = "Inventory ID")]
		[PXRestrictor(
			typeof(Where<InventoryItem.stkItem.IsEqual<False>>),
			Messages.StockItemNotPermitted)]
		[Inventory]
		public virtual int? InventoryID { get; set; }
		public abstract class inventoryID : PX.Data.BQL.BqlInt.Field<inventoryID> { }
		#endregion

		#region DefaultPrice
		[PXDBDecimal()]
		[PXUIField(DisplayName = "Default Price")]
		public virtual Decimal? DefaultPrice { get; set; }
		public abstract class defaultPrice : PX.Data.BQL.BqlDecimal.Field<defaultPrice> { }
		#endregion

		#region Quantity
		[PXDBDecimal()]
		[PXUIField(DisplayName = "Quantity")]
		public virtual Decimal? Quantity { get; set; }
		public abstract class quantity : PX.Data.BQL.BqlDecimal.Field<quantity> { }
		#endregion

		#region ExtPrice
		[PXDBDecimal()]
		[PXUIField(DisplayName = "Ext Price")]
		public virtual Decimal? ExtPrice { get; set; }
		public abstract class extPrice : PX.Data.BQL.BqlDecimal.Field<extPrice> { }
		#endregion

		#region CreatedByID
		[PXDBCreatedByID()]
		public virtual Guid? CreatedByID { get; set; }
		public abstract class createdByID : PX.Data.BQL.BqlGuid.Field<createdByID> { }
		#endregion

		#region CreatedByScreenID
		[PXDBCreatedByScreenID()]
		public virtual string CreatedByScreenID { get; set; }
		public abstract class createdByScreenID : PX.Data.BQL.BqlString.Field<createdByScreenID> { }
		#endregion

		#region CreatedDateTime
		[PXDBCreatedDateTime()]
		public virtual DateTime? CreatedDateTime { get; set; }
		public abstract class createdDateTime : PX.Data.BQL.BqlDateTime.Field<createdDateTime> { }
		#endregion

		#region LastModifiedByID
		[PXDBLastModifiedByID()]
		public virtual Guid? LastModifiedByID { get; set; }
		public abstract class lastModifiedByID : PX.Data.BQL.BqlGuid.Field<lastModifiedByID> { }
		#endregion

		#region LastModifiedByScreenID
		[PXDBLastModifiedByScreenID()]
		public virtual string LastModifiedByScreenID { get; set; }
		public abstract class lastModifiedByScreenID : PX.Data.BQL.BqlString.Field<lastModifiedByScreenID> { }
		#endregion

		#region LastModifiedDateTime
		[PXDBLastModifiedDateTime()]
		public virtual DateTime? LastModifiedDateTime { get; set; }
		public abstract class lastModifiedDateTime : PX.Data.BQL.BqlDateTime.Field<lastModifiedDateTime> { }
		#endregion

		#region Tstamp
		[PXDBTimestamp()]
		[PXUIField(DisplayName = "Tstamp")]
		public virtual byte[] Tstamp { get; set; }
		public abstract class tstamp : PX.Data.BQL.BqlByteArray.Field<tstamp> { }
		#endregion

		#region Noteid
		[PXNote()]
		public virtual Guid? Noteid { get; set; }
		public abstract class noteid : PX.Data.BQL.BqlGuid.Field<noteid> { }
		#endregion
	}
}