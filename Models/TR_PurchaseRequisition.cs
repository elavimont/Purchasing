using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MP_Purchasing.Models
{
    public class TR_PurchaseRequisition
    {
        public Guid ID { get; set; }
        public Guid UserLoginID { get; set; }
        public Guid VendorID { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime TargetDate { get; set; }
        public DateTime FulfillmentDate { get; set; }
        public int FulfillmentStatus { get; set; }
        public bool Status { get; set; }
        //public List<PurchaseDetail> ListPurchases { get; set; }
    }
}
