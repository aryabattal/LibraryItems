//using Microsoft.AspNetCore.Identity;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;

//namespace ManageLibraryItemsAndEmployees.Data.Entities
//{
//    public class Customer : IdentityUser
//    {
//        public Customer(string firstName, string lastName, string email, string address)
//        {
//            FirstName = firstName;
//            LastName = lastName;
//            Email = email;
//            Address = address;
//            UserName = email;

//        }

//        [Required]
//        [MaxLength(50)]
//        public string FirstName { get; protected set; }

//        [Required]
//        [MaxLength(50)]
//        public string LastName { get; protected set; }

//        [Required]
//        [MaxLength(200)]
//        public string Address { get; protected set; }

//        public ICollection<Order> Orders { get; protected set; }
//            = new List<Order>();
//    }
//}
