using ManageLibraryItemsAndEmployees.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace ManageLibraryItemsAndEmployees.Areas.API.v2.Models
{
    public class CreateLibraryItemDto
    {
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        [MaxLength(50)]
        public string Author { get; set; }

        public int? Pages { get; set; }
        public int? RunTimeMinutes { get; set; }
        public Boolean IsBorrowable { get; set; }
        public string Borrower { get; set; }
        public DateTime? BorrowerDate { get; set; }
        public string Type { get; set; }
        public Category Category { get; set; }
    }
}
