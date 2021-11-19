using AuthTestApp.Data;
using AuthTestApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AuthTestApp.Controllers
{
    public class VicidialCampaignController : Controller
    {
        private readonly ApplicationDbContext _db;

        public VicidialCampaignController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<VicidialCampaign> objList = _db.VicidialCampaign;
            return View(objList);
        }

        //GET - Edit
        public IActionResult Details(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _db.VicidialCampaign.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
    }
}
