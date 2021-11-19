using Microsoft.AspNetCore.Mvc;
using System.Collection.Generic;
using System;

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
            IEnumerable<Ticket> objList = _db.Ticket;
            return View(objList);
        }

        //GET - Edit
        public IActionResult Details(string? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Ticket.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
    }
}
