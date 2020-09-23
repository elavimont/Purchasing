using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MP_Purchasing.Models
{
    public class TR_PurchaseRequisitionDetail
    {
        public Guid ID { get; set; }
        public Guid PurchaseRequisitionID { get; set; }
        public Guid MaterialID { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
        public bool Status { get; set; }
    }
}
