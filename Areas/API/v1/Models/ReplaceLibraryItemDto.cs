using ManageLibraryItemsAndEmployees.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManageLibraryItemsAndEmployees.Areas.API.v1.Models
{
    public class ReplaceLibraryItemDto
    {
        public int Id { get; set; }
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
        public ICollection<Category> Categories { get; set; }
    }
}