using Microsoft.AspNetCore.Mvc;
using AuthTestApp.Models;
using AuthTestApp.Data;
using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AuthTestApp.Controllers
{
    public class VicidialCarrierLogController : Controller
    {
        private readonly ApplicationDbContext _db;

        public VicidialCarrierLogController(ApplicationDbContext db)
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
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["DialStatusSortParm"] = String.IsNullOrEmpty(sortOrder) ? "DialStatus" : "";
            ViewData["DialTimeSortParm"] = String.IsNullOrEmpty(sortOrder) ? "DialTime" : "";

            if (searchString != null) { pageNumber = 1; }
            else { searchString = currentFilter; }

            ViewData["CurrentFilter"] = searchString;

            var items = from i in _db.VicidialCarrierLog select i;

            if (!String.IsNullOrEmpty(searchString))
            {
                items = items.Where(i => i.Dialstatus.Contains(searchString) || i.DialTime.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "Date":
                    items = items.OrderBy(i => i.CallDate);
                    break;
                case "date_desc":
                    items = items.OrderByDescending(i => i.CallDate);
                    break;
                case "DialStatus":
                    items = items.OrderBy(i => i.Dialstatus);
                    break;
                case "DialTime":
                    items = items.OrderBy(i => i.DialTime);
                    break;
                default:
                    items = items.OrderBy(i => i.CallDate);
                    break;
            }

            int pageSize = 50;
            return View(await PaginatedList<VicidialCarrierLog>.CreateAsync(items.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        public IActionResult Details(double? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _db.VicidialCarrierLog.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
    }
}
