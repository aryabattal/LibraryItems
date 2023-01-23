using ManageLibraryItemsAndEmployees.Areas.Admin.Models;
using ManageLibraryItemsAndEmployees.Data;
using ManageLibraryItemsAndEmployees.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ManageLibraryItemsAndEmployees.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext context;
       
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            this.context = context;
        }
        public async Task<IActionResult> Index(string sortList)
        {
            //Add sorting Functionality to the Index method
            ViewData["CategoryNameSortParm"] = String.IsNullOrEmpty(sortList) ? "categoryName_desc" : "";
            ViewData["TypeSortParm"] = sortList == "Type" ? "type_desc" : "Type";

            var categories = from s in context.Categories.Include(x => x.LibraryItems)
                             select s;

            categories = sortList switch
            {
                "categoryName_desc" => categories.OrderByDescending(s => s.CategoryName),
                "Type" => categories.OrderBy(s => s.SelectLibraryitems.Type),
                "type_desc" => categories.OrderByDescending(s => s.SelectLibraryitems.Type),
                _ => categories.OrderBy(s => s.CategoryName),
            };
            var libraryItems = context.LibraryItems.ToList();

            ViewBag.libraryItem = libraryItems;
            ViewBag.category = categories;


            return View(await categories.AsNoTracking().ToListAsync());
        }
    

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
