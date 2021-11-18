using Microsoft.AspNetCore.Mvc;
using AuthTestApp.Data;
using AuthTestApp.Models;
using System.Collections.Generic;
using System;

namespace AuthTestApp.Controllers
{
    public class HardwareController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HardwareController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Hardware> objList = _db.Hardware;
            return View(objList);
        }

        //GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Hardware obj)
        {
            if (ModelState.IsValid) {
                _db.Hardware.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        //GET - EDIT
        public IActionResult Edit(string? id)
        {
            if (id == null )
            {
                return NotFound();
            }
            var obj = _db.Hardware.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //POST - EDIT
        public IActionResult Edit(Hardware obj)
        {
            if (_db.Hardware.Find(obj.SN) == null)
            {

                if (ModelState.IsValid)
                {
                    _db.Hardware.Update(obj);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(obj);
            }
            else {
                return RedirectToAction("DuplicateRecord");
            }
        }

        //GET - DELETE
        public IActionResult Delete(string? id)
        {
            if (id == null)
            { 
                return NotFound();
            }
            var obj = _db.Hardware.Find(id);
            if (obj == null)
            { 
                return NotFound();
            }

            return View(obj);
        }

        //POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteHardware(string id)
        {
            var obj = _db.Hardware.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
                _db.Hardware.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            
        }

        public IActionResult DuplicateRecord()
        {
            return View();
        }
    }
}
