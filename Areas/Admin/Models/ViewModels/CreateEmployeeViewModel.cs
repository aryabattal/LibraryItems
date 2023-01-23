using ManageLibraryItemsAndEmployees.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ManageLibraryItemsAndEmployees.Areas.Admin.Models.ViewModels
{
    public class CreateEmployeeViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Salary { get; set; }

        public Boolean IsCEO { get; set; }
        public Boolean IsManager { get; set; }
        public int? ManagerId { get; set; }


    }
}
