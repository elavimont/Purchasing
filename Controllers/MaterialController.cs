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
    public class MaterialController : Controller
    {
        List<Material> listMaterial= new List<Material>();
        APIContext db;
        public MaterialController(APIContext context)
        {
            db = context;
        }
        [HttpGet]
        public IActionResult GetAllMaterials()
        {
            listMaterial = db.Material.ToList();
            return Ok(listMaterial);
        }
        [HttpPost]
        public IActionResult AddNewMaterial(Material material)
        {
            db.Material.Add(material);
            db.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult UpdateMaterial(Material dataMaterial)
        {
            var existingMat = db.Material.Where(a => a.ID == dataMaterial.ID).First();
            existingMat.ID = dataMaterial.ID;
            existingMat.MaterialName = dataMaterial.MaterialName;
            existingMat.Price = dataMaterial.Price;
            existingMat.UnitOfMeasure = dataMaterial.UnitOfMeasure;
            existingMat.Status = dataMaterial.Status;
            db.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public IActionResult GetMaterialPrice (Guid materialID)
        {
            return Ok(db.Material.Where(p => p.ID == materialID).First().Price);
        }
    }
}
