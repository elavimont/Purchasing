using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MP_Purchasing.Models;

namespace MP_Purchasing.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[action]")]
    public class VendorController : Controller
    {
        List<Vendor> listVendor = new List<Vendor>();
        APIContext db;

        public VendorController(APIContext context)
        {
            db = context;

        }

        [HttpGet]
        public IActionResult GetAllVendors()
        {
            listVendor= db.Vendor.ToList().FindAll(vend=>vend.Status==true);
            return Ok(listVendor);
        }

        [HttpGet]
        public IActionResult GetVendorByName(string vendorName)
        {

            List<Vendor> result = db.Vendor.ToList().FindAll(cust => cust.VendorName== vendorName);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddNewVendor(Vendor vendor)
        {
            db.Vendor.Add(vendor);
            db.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult UpdateVendor(Vendor dataVendor)
        {
            var existingVend = db.Vendor.Where(a => a.ID == dataVendor.ID).First();
            existingVend.ID = dataVendor.ID;
            existingVend.VendorName = dataVendor.VendorName;
            existingVend.Phone = dataVendor.Phone;
            existingVend.Address = dataVendor.Address;
            existingVend.Status = dataVendor.Status;
            db.SaveChanges();
            return Ok();
        }

    }
}
