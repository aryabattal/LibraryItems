using ManageLibraryItemsAndEmployees.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ManageLibraryItemsAndEmployees.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SearchResultController : Controller
    {
        private readonly ApplicationDbContext context;

        public SearchResultController(ApplicationDbContext context)
        {
            this.context = context;
        }


        // GET: /search?q=LibraryItems
        [Route("Admin/search")]
        public IActionResult Index(string q)
        {
            var libraryItems = context.LibraryItems.Where(l => l.Title.Contains(q));

            return View(libraryItems);
        }
    }
}
