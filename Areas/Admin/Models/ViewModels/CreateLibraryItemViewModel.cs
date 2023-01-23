using ManageLibraryItemsAndEmployees.Data.Entities;
using System;
using System.Collections.Generic;

namespace ManageLibraryItemsAndEmployees.Areas.Admin.Models.ViewModels
{
    public class CreateLibraryItemViewModel
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        public int? Pages { get; set; }
        public int? RunTimeMinutes { get; set; }
        public Boolean IsBorrowable { get; set; } = true;
        public string Borrower { get; set; }
        public DateTime? BorrowerDate { get; set; }
        public string Type { get; set; }
        public ICollection<Category> Categories { get; set; }


    }
}
