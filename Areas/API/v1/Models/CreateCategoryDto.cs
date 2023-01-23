using System.ComponentModel.DataAnnotations;

namespace ManageLibraryItemsAndEmployees.Areas.API.v1.Models
{
    public class CreateCategoryDto
    {
       
       
        [Required]
        [MaxLength(50)]
        public string CategoryName { get; set; }
     
    }
}
