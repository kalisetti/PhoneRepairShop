using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PX.Data;
using PX.Data.BQL.Fluent;

namespace PhoneRepairShop
{
    public class RSSVRepairPriceMaint : PXGraph<RSSVRepairPriceMaint, RSSVRepairPrice>
    {
        public SelectFrom<RSSVRepairPrice>.View RepairPrices;

        //public PXSave<RSSVRepairPrice> Save;
        //public PXCancel<RSSVRepairPrice> Cancel;

        //public PXFilter<MasterTable> MasterView;
        //public PXFilter<DetailsTable> DetailsView;

        //[Serializable]
        //public class MasterTable : IBqlTable
        //{

        //}

        //[Serializable]
        //public class DetailsTable : IBqlTable
        //{

        //}
    }
}