using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MP_Purchasing.Models
{
    public class Material
    {
        public Guid ID { get; set; }
        public string MaterialName{ get; set; }
        public decimal Price{ get; set; }
        public string UnitOfMeasure { get; set; }
        public bool Status { get; set; }
    }
}
