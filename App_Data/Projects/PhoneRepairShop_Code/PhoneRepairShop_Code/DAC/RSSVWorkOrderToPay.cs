using System;
using PX.Data;

namespace PhoneRepairShop
{
  [PXCacheName("Repair Work Order to Pay")]
  public class RSSVWorkOrderToPay : RSSVWorkOrder
  {
		#region invoiceNbr
		public new abstract class invoiceNbr : PX.Data.BQL.BqlString.Field<invoiceNbr> { }
		#endregion

		#region Status
		public new abstract class status: PX.Data.BQL.BqlString.Field<status> { }
		#endregion

		#region OrderNbr
		public new abstract class orderNbr: PX.Data.BQL.BqlString.Field<orderNbr> { }
		#endregion

		#region PercentPaid
		[PXDecimal]
		[PXUIField(DisplayName = "Percent Paid")]
		public virtual Decimal? PercentPaid { get; set; }
		public abstract class percentPaid: PX.Data.BQL.BqlDecimal.Field<percentPaid> { }
		#endregion

		#region OrderType
		[PXString]
		[PXUIField(DisplayName = "Order Type")]
		[PXUnboundDefault(OrderTypeConstants.WorkOrder)]
		[PXStringList(
			new string[] {
				OrderTypeConstants.WorkOrder,
				OrderTypeConstants.SalesOrder
			},
			new string[] {
				Messages.WorkOrder,
				Messages.SalesOrder,
			}
		)]
		public virtual String OrderType { get; set; }
		public abstract class orderType : PX.Data.BQL.BqlString.Field<orderType> { }
		#endregion

		#region ServiceID
		public new abstract class serviceID : PX.Data.BQL.BqlInt.Field<serviceID> { }
		#endregion

		#region CustomerID
		public new abstract class customerID : PX.Data.BQL.BqlInt.Field<customerID> { }
		#endregion
	}
}