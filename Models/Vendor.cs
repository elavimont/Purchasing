using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MP_Purchasing.Models
{
    public class Vendor
    {
        public Guid ID { get; set; }
        public string VendorName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool Status { get; set; }
        //public Vendor() { }

        //public Vendor( string vendorName, string phone, string address)
        //{
        //    VendorName = vendorName;
        //    Phone = phone;
        //    Address = address;
        //}

    }
}
