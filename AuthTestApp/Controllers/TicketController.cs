using AuthTestApp.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AuthTestApp.Models;
using System.Collections.Generic;
using Microsoft.Graph;
using System;
using System.Linq;

namespace AuthTestApp.Controllers
{
    [Authorize(Roles = "Survey Writer")]
    public class TicketController : Controller
    {

        private readonly ApplicationDbContext _db;

        public TicketController(ApplicationDbContext db, GraphServiceClient graphServiceClient)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Ticket> objList = _db.Ticket;
            return View(objList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Ticket obj)
        {


            Console.WriteLine(ModelState.IsValid);
            if (ModelState.IsValid)
            {
                if (obj.Name == null)
                {
                    var name = ((System.Security.Claims.ClaimsIdentity)User.Identity).Claims.Where(c => c.Type == "name").FirstOrDefault().Value;
                    var email = User.Identity.Name;
                    obj.Name = name;
                    obj.Email = email;
                }

                obj.Status = "Not Started";
                

                Console.WriteLine(obj);

                _db.Ticket.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET - Edit
        public IActionResult Edit(int? id)
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
