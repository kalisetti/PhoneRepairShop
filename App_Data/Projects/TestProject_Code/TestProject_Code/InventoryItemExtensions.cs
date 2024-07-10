using PX.Data.ReferentialIntegrity.Attributes;
using PX.Data;
using PX.Objects.Common.Extensions;
using PX.Objects.Common;
using PX.Objects.CR;
using PX.Objects.CS;
using PX.Objects.DR;
using PX.Objects.EP;
using PX.Objects.GL;
using PX.Objects.IN.Matrix.Attributes;
using PX.Objects.IN.Matrix.Graphs;
using PX.Objects.IN;
using PX.Objects.TX;
using PX.Objects;
using PX.TM;
using System.Collections.Generic;
using System;

namespace PX.Objects.IN
{
  public class InventoryItemExt : PXCacheExtension<PX.Objects.IN.InventoryItem>
  {
    #region UsrTestColumn
    [PXDBString(30)]
    [PXUIField(DisplayName="TestColumn")]

    public virtual string UsrTestColumn { get; set; }
    public abstract class usrTestColumn : PX.Data.BQL.BqlString.Field<usrTestColumn> { }
    #endregion
  }
}