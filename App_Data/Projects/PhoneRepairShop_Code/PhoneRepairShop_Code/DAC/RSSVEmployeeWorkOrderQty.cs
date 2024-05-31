using System;
using PX.Data;

namespace PhoneRepairShop
{
  [PXHidden]
  [PXCacheName("RSSVEmployeeWorkOrderQtyAccumulator")]
  public class RSSVEmployeeWorkOrderQty : IBqlTable
  {
    #region Userid
    [PXDBInt(IsKey = true)]
    [PXUIField(DisplayName = "Userid")]
    public virtual int? Userid { get; set; }
    public abstract class userid : PX.Data.BQL.BqlInt.Field<userid> { }
    #endregion

    #region NbrOfAssignedOrders
    [PXDBInt()]
    [PXUIField(DisplayName = "Nbr Of Assigned Orders")]
    public virtual int? NbrOfAssignedOrders { get; set; }
    public abstract class nbrOfAssignedOrders : PX.Data.BQL.BqlInt.Field<nbrOfAssignedOrders> { }
    #endregion

    #region LastModifiedDateTime
    [PXDBLastModifiedDateTime()]
    public virtual DateTime? LastModifiedDateTime { get; set; }
    public abstract class lastModifiedDateTime : PX.Data.BQL.BqlDateTime.Field<lastModifiedDateTime> { }
    #endregion
  }
}