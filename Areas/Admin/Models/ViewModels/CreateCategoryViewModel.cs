using ManageLibraryItemsAndEmployees.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace ManageLibraryItemsAndEmployees.Areas.Admin.Models.ViewModels
{
    public class CreateCategoryViewModel
    {
       
       
        [Required]
        [MaxLength(50)]
        public string CategoryName { get; set; }
     
    }
}
