using System.ComponentModel.DataAnnotations;

namespace ManageLibraryItemsAndEmployees.Data.Entities
{


    public class OrderLine
    {
        public OrderLine(int libraryItemId, int quantity)
        {
            LibraryItemId = libraryItemId;
            Quantity = quantity;
        }

        public int Id { get;  set; }

        public int LibraryItemId { get;  set; }

        public LibraryItem LibraryItem { get;  set; }

        [Required]
        public int Quantity { get;  set; }
    }
}