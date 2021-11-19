using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AuthTestApp.Models;
using AuthTestApp.Data;
using System.Collections.Generic;
using System;

namespace AuthTestApp.Controllers
{
    public class VicidialApiLogController : Controller
    {
        private readonly ApplicationDbContext _db;

        public VicidialApiLogController(ApplicationDbContext db)
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
            ViewData["DateSortParm"] = String.IsNullOrEmpty(sortOrder) ? "Date" : "";
            ViewData["ResultSortParm"] = String.IsNullOrEmpty(sortOrder) ? "Result" : "";
            ViewData["ResultReasonSortParm"] = String.IsNullOrEmpty(sortOrder) ? "ResultReason" : "";

            if (searchString != null) { pageNumber = 1; }
            else { searchString = currentFilter; }

            ViewData["CurrentFilter"] = searchString;

            var items = from i in _db.VicidialApiLog select i;

            if (!String.IsNullOrEmpty(searchString))
            {
                items = items.Where(i => i.ApiDate.Contains(searchString) || i.Result.Contains(searchString) || i.ResultReason.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "Type":
                    items = items.OrderByDescending(i => i.ApiDate);
                    break;
                case "Location":
                    items = items.OrderBy(i => i.Result);
                    break;
                case "Status":
                    items = items.OrderBy(i => i.ResultReason);
                    break;
                default:
                    items = items.OrderBy(i => i.ApiDate);
                    break;
            }

            int pageSize = 50;
            return View(await PaginatedList<Hardware>.CreateAsync(items.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        public IActionResult Details(string? id)
        { 
            if (id == null)
            {
                return NotFound();
            }
            var obj = _db.VicidialApiLog.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
    }
}
