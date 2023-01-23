using ManageLibraryItemsAndEmployees.Areas.API.v2.Models;
using ManageLibraryItemsAndEmployees.Data;
using ManageLibraryItemsAndEmployees.Data.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ManageLibraryItemsAndEmployees.Areas.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiVersion("2")]
    [ApiController]
    public class LibraryItemController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public LibraryItemController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET /api/LibraryItem
        [HttpGet]
        public IEnumerable<LibraryItemDto> GetAll()
        {
            var libraryItems = context.LibraryItems.ToList();

            //var dto = products.Select(x => ToProductDto(x));
            var dto = libraryItems.Select(ToLibraryItemDto);

            return dto;
        }

        // GET /api/libraryItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LibraryItemDto>> GetById(int id)
        {
            var libraryItem = await context.LibraryItems.FindAsync(id);

            if (libraryItem == null)
            {
                // 404 Not Found
                return NotFound();
            }

            var dto = ToLibraryItemDto(libraryItem);

            // 200 OK
            // return Ok(libraryItem);
            return dto;
        }

        //POST: /api/libraryItems
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<ActionResult<LibraryItemDto>> CreateLibraryItem(CreateLibraryItemDto createLibraryItemDto)
        {
            var libraryItem = new LibraryItem(
                    createLibraryItemDto.Title,
                    createLibraryItemDto.Author,
                    createLibraryItemDto.IsBorrowable,
                    createLibraryItemDto.Borrower,
                    createLibraryItemDto.Type);

            var categoryId = await context.Categories.FirstOrDefaultAsync(m => m.Id == createLibraryItemDto.CategoryId);

            libraryItem.Category = categoryId;

            context.LibraryItems.Add(libraryItem);

            await context.SaveChangesAsync();

            var libraryItemDto = ToLibraryItemDto(libraryItem);

            // https://localhost:5001/api/libraryItems/
            // 201 Created
            return CreatedAtAction(nameof(GetById), new { id = libraryItemDto.Id }, libraryItemDto);

          
        }

        // DELETE /api/products/{id}
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public IActionResult DeleteLibraryItems(int id)
        {
            var products = context.LibraryItems.Where(x => x.Id == id);

            context.LibraryItems.RemoveRange(products);

            context.SaveChanges();

            return NoContent(); // 204 No Content
        }

        // PUT /api/products/{id}
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public IActionResult ReplaceProduct(int id, ReplaceLibraryItemDto replaceProductDto)
        {
            if (id != replaceProductDto.Id)
            {
                return BadRequest("Id missmatch");
            }

            var product = ToLibraryItem(replaceProductDto);

            // TODO: Skillnad mellan Entry / Update
            context.Entry(product).State = EntityState.Modified;

            context.SaveChanges();

            return NoContent(); // 204 No Content
        }

        // Beginning with C# 9.0, constructor invocation expressions are
        // target-typed. That is, if a target type of an expression is
        // known, you can omit a type name
        private LibraryItemDto ToLibraryItemDto(LibraryItem libraryItem)
            => new()
            {
                Id = libraryItem.Id,
                CategoryId = libraryItem.CategoryId,
                Title = libraryItem.Title,
                Author = libraryItem.Author,
                IsBorrowable = libraryItem.IsBorrowable,
                Borrower = libraryItem.Borrower,
                Type = libraryItem.Type

            };

        private LibraryItem ToLibraryItem(ReplaceLibraryItemDto dto)
            => new(id: dto.Id,
                categoryId: dto.CategoryId,
                title: dto.Title,
                author: dto.Author,
                isBorrowable: dto.IsBorrowable,
                   borrower: dto.Borrower,
                   type: dto.Type);
    }
}
