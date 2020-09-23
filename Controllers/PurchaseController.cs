using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using MP_Purchasing.Models;
using MP_Purchasing.Models.MultipleObject;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MP_Purchasing.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[action]")]
    public class PurchaseController : Controller
    {
        APIContext db;

        public PurchaseController(APIContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult GetVendor()
        {
            return Json(db.Vendor.Select(x => new
            {
                id = x.ID,
                vendorName = x.VendorName
            }).ToList());
        }

        [HttpGet]
        public IActionResult GetMaterial()
        {
            return Json(db.Material.Select(x => new
            {
                id = x.ID,
                materialName = x.MaterialName,
                price = x.Price,
                unitOfMeasure= x.UnitOfMeasure
            }).ToList());
        }

        [HttpPost]
        public IActionResult AddNewPurchase(PurchaseData purchaseData)
        {
            purchaseData.TR_PurchaseRequisition.ID = Guid.NewGuid();
            purchaseData.TR_PurchaseRequisition.RequestDate = DateTime.Now;
            purchaseData.TR_PurchaseRequisition.FulfillmentDate = DateTime.Now;

            db.TR_PurchaseRequisition.Add(purchaseData.TR_PurchaseRequisition);
            foreach (var data in purchaseData.ListPurchase)
            {
                data.ID = Guid.NewGuid();
                data.PurchaseRequisitionID = purchaseData.TR_PurchaseRequisition.ID;
                db.TR_PurchaseRequisitionDetail.Add(data);
            }
            db.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public IActionResult GetPurchase()
        {
            var listPurchase = db.Usp_GetPurchase.FromSqlRaw("exec usp_GetPurchase").ToList();
            return Ok(listPurchase);
        }
    }
}
