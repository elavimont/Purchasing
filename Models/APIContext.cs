using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MP_Purchasing.Models;
using MP_Purchasing.Models.MultipleObject;
using MP_Purchasing.Models.StoredProcedures;

namespace MP_Purchasing.Models
{
    public class APIContext : DbContext
    {
       
        public DbSet<Vendor> Vendor { get; set; }
        public DbSet<Material> Material { get; set; }
        
        public DbSet<TR_PurchaseRequisition> TR_PurchaseRequisition { get; set; }      
        public DbSet<TR_PurchaseRequisitionDetail> TR_PurchaseRequisitionDetail { get; set; }
        public DbSet<PurchaseData> PurchaseData { get; set; }
        public DbSet<usp_GetPurchase> Usp_GetPurchase { get; set; }     
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<usp_GetPurchase>().HasNoKey();
            modelBuilder.Entity<PurchaseData>().HasNoKey();
        }
        public APIContext(DbContextOptions<APIContext> options) : base(options) { }
    }
}
