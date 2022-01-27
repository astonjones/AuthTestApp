using Microsoft.AspNetCore.Mvc;
using AuthTestApp.Data;
using AuthTestApp.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace AuthTestApp.Controllers
{
    [Authorize]
    public class HardwareController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HardwareController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["TypeSortParm"] = String.IsNullOrEmpty(sortOrder) ? "Type" : "";
            ViewData["LocationSortParm"] = String.IsNullOrEmpty(sortOrder) ? "Location" : "";
            ViewData["StatusSortParm"] = String.IsNullOrEmpty(sortOrder) ? "Status" : "";
            ViewData["InUseSortParm"] = String.IsNullOrEmpty(sortOrder) ? "In_Use" : "";

            if (searchString != null){ pageNumber = 1; }
            else { searchString = currentFilter; }

            ViewData["CurrentFilter"] = searchString;

            var items = from i in _db.Hardware select i;

            if (pageNumber == 1 || pageNumber == null)
            {
                ViewData["PRNInUseComputers"] = items.Where(i => i.Location == "PRN" && i.In_Use == 'Y' && i.Type == "PC").Count();
                ViewData["PRNGoodComputers"] = items.Where(i => i.Location == "PRN" && i.In_Use == 'N' && i.Type == "PC" && i.Status == "Good").Count();
                ViewData["PRNBadComputers"] = items.Where(i => i.Location == "PRN" && i.Type == "PC" && i.Status == "Bad").Count();

                ViewData["PRNInUseMonitors"] = items.Where(i => i.Location == "PRN" && i.In_Use == 'Y' && i.Type == "Monitor").Count();
                ViewData["PRNGoodMonitors"] = items.Where(i => i.Location == "PRN" && i.In_Use == 'N' && i.Type == "Monitor" && i.Status == "Good").Count();
                ViewData["PRNBadMonitors"] = items.Where(i => i.Location == "PRN" && i.Type == "Monitor" && i.Status == "Bad").Count();
            }

            //Can search by attributes placed in this block
            if (!String.IsNullOrEmpty(searchString))
            {
                items = items.Where(i => i.Type.Contains(searchString) || i.Location.Contains(searchString) || i.SN.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "Type":
                    items = items.OrderByDescending(i => i.Type);
                    break;
                case "Location":
                    items = items.OrderBy(i => i.Location);
                    break;
                case "Status":
                    items = items.OrderBy(i => i.Status);
                    break;
                case "In_Use":
                    items = items.OrderBy(i => i.In_Use);
                    break;
                default:
                    items = items.OrderBy(i => i.Location);
                    break;
            }

            int pageSize = 50;
            return View(await PaginatedList<Hardware>.CreateAsync(items.AsNoTracking(), pageNumber ?? 1, pageSize));
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
            if (_db.Hardware.Find(obj.SN) == null)
            {
                if (ModelState.IsValid)
                {
                    _db.Hardware.Add(obj);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View();
            }
            else
            {
                return RedirectToAction("DuplicateRecord");
            }
        }

        //GET - EDIT
        public IActionResult Edit(string? id)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        //POST - EDIT
        public IActionResult Edit(Hardware obj)
        {
            if (ModelState.IsValid)
            {
                _db.Hardware.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
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
        [ActionName("Delete")]
        public IActionResult DeleteHardware(string? id)
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

        //GET - EDIT
        public IActionResult Details(string? id)
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

        public IActionResult DuplicateRecord()
        {
            return View();
        }
    }
}
