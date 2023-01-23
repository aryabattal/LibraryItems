using ManageLibraryItemsAndEmployees.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ManageLibraryItemsAndEmployees.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class LibraryItemsController : Controller
    {
        private readonly ApplicationDbContext context;

        public LibraryItemsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET /LibraryItems/book
        [Route("/libraryItems/{urlSlug}", Name = "libraryItemsdetails")]
        public async Task<IActionResult> Details(string urlSlug)
        {

            if (urlSlug == null)
            {
                return NotFound();
            }

            var libraryItem = await context.LibraryItems.FirstOrDefaultAsync(libraryItem => libraryItem.UrlSlug == urlSlug);

            if (libraryItem == null)
            {
                return NotFound();
            }

            // .\Views\LibraryItems\Details.cshtml
            return View(libraryItem);
        }
    }
}
