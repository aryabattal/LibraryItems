
using ManageLibraryItemsAndEmployees.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ManageLibraryItemsAndEmployees.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class SearchResultController : Controller
    {
        private readonly ApplicationDbContext context;

        public SearchResultController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET /search?q=book
        [Route("/search")]
        public ActionResult Index(string q)
        {
            var products = context.LibraryItems.Where(x => x.Title.Contains(q));

            // .\Views\SearchResult\Index.cshtml
            return View(products);
        }
    }
}
