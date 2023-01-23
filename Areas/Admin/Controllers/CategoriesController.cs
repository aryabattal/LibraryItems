using ManageLibraryItemsAndEmployees.Areas.Admin.Models.ViewModels;
using ManageLibraryItemsAndEmployees.Data;
using ManageLibraryItemsAndEmployees.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ManageLibraryItemsAndEmployees.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        public readonly ApplicationDbContext context;

        public CategoriesController(ApplicationDbContext context)
        {
            this.context = context;
        }
        //GET: Admin/Categories
        public async Task<IActionResult> Index()
        {
            return View(await context.Categories.ToListAsync());
        }



        //GET /Admin/Categories/Details/{id} 
       public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            // Fetch all categories from database(Retrieve categories and related LibraryItem lists)
            var category = await context.Categories
                // including all libraryItems lists that are associated with each of the categories
                .Include(g => g.LibraryItems)
            // then pick out only that category, that has the same name as the passed parameter "int? id"
                .FirstOrDefaultAsync(x => x.Id == id);

            if (category == null)
            {
                return NotFound();
            }
            // return picked out specific game with the specific highscore list
            return View(category);
        }
          

        // GET: Admin/Categories/Create
        public IActionResult Create()
        {
            return View();
        }
        // POST: Admin/Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCategoryViewModel createCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                var category = new Category(createCategoryViewModel.CategoryName);

                context.Add(category);

                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(createCategoryViewModel);
           

        }

        // GET: Admin/Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            var viewModel = new EditCategoryViewModel
            {
                Id = category.Id,
                CategoryName = category.CategoryName
            };
            return View(viewModel);
        }

        // POST: Admin/Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditCategoryViewModel editCategoryViewModel)
        {
            if (id != editCategoryViewModel.Id)
            {
                return NotFound(); // 404 Not Found
            }

            if (ModelState.IsValid)
            {
                var category = new Category(
                        editCategoryViewModel.Id,
                        editCategoryViewModel.CategoryName);

                try
                {
                    context.Update(category);

                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.Id))
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

            return View(editCategoryViewModel);
        }

        // GET: Admin/Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Admin/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await context.Categories.FindAsync(id);

            context.Categories.Remove(category);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return context.Categories.Any(e => e.Id == id);
        }


    }
}
