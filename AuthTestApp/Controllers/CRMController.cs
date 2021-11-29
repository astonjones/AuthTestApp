using AuthTestApp.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthTestApp.Controllers
{
    [AllowAnonymous]
    public class CRMController : Controller
    {

        private readonly ApplicationDbContext _db;

        public CRMController(ApplicationDbContext db, GraphServiceClient graphServiceClient)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            // Possibly get the DB here and view the leads??
            return View();
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST - CREATE
        /* public IActionResult Create(Lead obj)
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
        } */

        //GET - Edit
        /* public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                // Go to the create page instead
                return NotFound();
            }
            var obj = _db.Ticket.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        } */


    }
}
