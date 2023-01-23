using ManageLibraryItemsAndEmployees.Data.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManageLibraryItemsAndEmployees.Areas.Admin.Models.ViewModels
{
    public class EditCategoryViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string CategoryName { get; set; }
        public ICollection<LibraryItem> LibraryItems { get; protected set; }
           = new List<LibraryItem>();
    }
}
