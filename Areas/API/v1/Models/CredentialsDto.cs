using System.ComponentModel.DataAnnotations;

namespace ManageLibraryItemsAndEmployeese.Areas.API.v1.Models
{
    public class CredentialsDto
    {
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
    }
}