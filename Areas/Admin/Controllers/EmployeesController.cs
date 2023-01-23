using ManageLibraryItemsAndEmployees.Areas.Admin.Models.ViewModels;
using ManageLibraryItemsAndEmployees.Data;
using ManageLibraryItemsAndEmployees.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ManageLibraryItemsAndEmployees.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmployeesController : Controller
    {
        public readonly ApplicationDbContext context;

        public EmployeesController(ApplicationDbContext context)
        {
            this.context = context;
        }
        //GET: Admin/Employees
        public async Task<IActionResult> Index()
        {
            return View(await context.Employees.ToListAsync());
        }



        //GET /Admin/Employees/Details/{id} 
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await context.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
           
        }

        // GET: Admin/Employees/Create
        public IActionResult Create()
        {
            return View();
        }
        // POST: Admin/Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateEmployeeViewModel createEmployeeViewModel)
        {
            if (ModelState.IsValid)
            {
                var employee = new Employee(
                    createEmployeeViewModel.FirstName,
                    createEmployeeViewModel.LastName,
                    createEmployeeViewModel.Salary);

                //if (employee.IsManager = true)

                //{
                //    employee.IsCEO = false;
                //    employee.ManagerId = createEmployeeViewModel.ManagerId;
                //}
                //else
                //{
                //    employee.IsCEO = true;
                //}

                context.Add(employee);

                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(createEmployeeViewModel);
           

        }

        // GET: Admin/Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            var viewModel = new EditEmployeeViewModel
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Salary = employee.Salary
            };
            return View(viewModel);
        }

        // POST: Admin/Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditEmployeeViewModel editEmployeeViewModel)
        {
            if (id != editEmployeeViewModel.Id)
            {
                return NotFound(); // 404 Not Found
            }

            if (ModelState.IsValid)
            {
                var employee = new Employee(
                    editEmployeeViewModel.Id,
                    editEmployeeViewModel.FirstName,
                    editEmployeeViewModel.LastName,
                    editEmployeeViewModel.Salary);

                if (employee.IsManager = true)

                {
                    employee.IsCEO = false;
                }
                else
                {
                    employee.IsCEO = true;
                }

                try
                {
                    context.Update(employee);

                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
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

            return View(editEmployeeViewModel);
        }

        // GET: Admin/Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await context.Employees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Admin/Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await context.Employees.FindAsync(id);
            context.Employees.Remove(employee);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return context.Employees.Any(e => e.Id == id);
        }


    }
}
