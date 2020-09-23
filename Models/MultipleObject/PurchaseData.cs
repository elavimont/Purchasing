using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MP_Purchasing.Models.MultipleObject
{
    public class PurchaseData
    {
        public TR_PurchaseRequisition TR_PurchaseRequisition { get; set; }
        public List<TR_PurchaseRequisitionDetail> ListPurchase { get; set; }

    }
}
