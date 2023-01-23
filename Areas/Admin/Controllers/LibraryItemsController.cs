using ManageLibraryItemsAndEmployees.Areas.Admin.Models.ViewModels;
using ManageLibraryItemsAndEmployees.Data;
using ManageLibraryItemsAndEmployees.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ManageLibraryItemsAndEmployees.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LibraryItemsController : Controller
    {
        private readonly ApplicationDbContext context;

        public LibraryItemsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        //GET: /admin/LibraryItems
        public async Task<IActionResult> Index()
        {
            // .\Areas\Admin\Views\LibraryItems\Index.cshtml
            return View(await context.LibraryItems.ToListAsync());
        }

        //GET: /admin/LibraryItems/details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libraryItems = await context.LibraryItems.OrderBy(x => x.Title).FirstOrDefaultAsync(m => m.Id == id);

            if (libraryItems == null)
            {
                return NotFound();
            }

            return View(libraryItems);
        }

        // GET: Admin/LibraryItems/Create
        public IActionResult Create()
        {
            // Categories for dropdown box
            var categories = context.Categories.ToList()
                .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.CategoryName.ToString() }).ToList();

            ViewBag.categories = categories;

            return View();
        }
        // POST /admin/LibraryItems/create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateLibraryItemViewModel createLibraryItemViewModel)
        {
            if (ModelState.IsValid)
            {
                // Retrieve associated category (in case of unselection, category id will be set to default value "0")
                string categoryIdString = Request.Form["Categories"];
                bool categoryIdIsValid = int.TryParse(categoryIdString, out int categoryIdParsed);
                int categoryId = categoryIdIsValid ? categoryIdParsed : 0;
                var associatedCategory = context.Categories.Find(categoryId);


                var libraryItem = new LibraryItem(
                    createLibraryItemViewModel.Title,
                    createLibraryItemViewModel.Author,
                    createLibraryItemViewModel.Pages,
                    createLibraryItemViewModel.IsBorrowable,
                    createLibraryItemViewModel.Borrower,
                    createLibraryItemViewModel.BorrowerDate,
                    createLibraryItemViewModel.Type);

              
                libraryItem.Category = associatedCategory;
                libraryItem.IsBorrowable = true;

                context.Add(libraryItem);

                await context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            // .\Areas\Admin\Views\libraryItem\Create.cshtml
            return View(createLibraryItemViewModel);
        }

        // GET /admin/libraryItem/edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libraryItem = await context.LibraryItems.FindAsync(id);

            // Categories for dropdown box
            var categories = context.Categories.ToList()
                .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.CategoryName.ToString() }).ToList();

            ViewBag.categories = categories;

            if (libraryItem == null)
            {
                return NotFound();
            }
            
            var viewModel = new EditLibraryItemViewModel
            {
               
                Id = libraryItem.Id,
                Title = libraryItem.Title,
                Author = libraryItem.Author,
                Pages = libraryItem.Pages,
                IsBorrowable = libraryItem.IsBorrowable,
                Borrower = libraryItem.Borrower,
                BorrowerDate = libraryItem.BorrowerDate,
                Type = libraryItem.Type,
                CategoryId = libraryItem.CategoryId,

            };
        
            return View(viewModel);
        }

        // POST /admin/libraryItem/edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditLibraryItemViewModel editLibraryItemViewModel)
        {
            if (id != editLibraryItemViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Retrieve associated Categories (in case of unselection, Categories id will be set to default value "0")
                string categoryIdString = Request.Form["Categories"];
                bool categoryIdIsValid = int.TryParse(categoryIdString, out int categoryIdParsed);
                int categoryId = categoryIdIsValid ? categoryIdParsed : 0;
                var associatedCategory = context.Categories.Find(categoryId);

                // Retrieve located cake and its categories
                //var locatedCake = await context.LibraryItems.Include(c => c.Category).FirstOrDefaultAsync(c => c.Id == editLibraryItemViewModel.Id);
                //var locatedCakeCategories = locatedCake.Category.Id.ToList();

                var libraryItem = new LibraryItem(
                    editLibraryItemViewModel.Title,
                    editLibraryItemViewModel.Author,
                    editLibraryItemViewModel.Pages,
                    editLibraryItemViewModel.IsBorrowable,
                    editLibraryItemViewModel.Borrower,
                    editLibraryItemViewModel.BorrowerDate,
                    editLibraryItemViewModel.Type);

                libraryItem.Category = associatedCategory;

                //if (associatedCategory != null &&
                //   !locatedCakeCategories.Contains(associatedCategory))
                //{
                //    locatedCake.Categories.Add(associatedCategory);
                //}

                try
                {
                    context.Update(libraryItem);

                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(libraryItem.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(editLibraryItemViewModel);
        }

        // GET /admin/libraryItems/delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libraryItem = await context.LibraryItems
                .FirstOrDefaultAsync(m => m.Id == id);

            if (libraryItem == null)
            {
                return NotFound();
            }

            return View(libraryItem);
        }

        // POST: Admin/libraryItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var libraryItem = await context.LibraryItems.FindAsync(id);

            context.LibraryItems.Remove(libraryItem);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return context.LibraryItems.Any(e => e.Id == id);
        }


    }
}
