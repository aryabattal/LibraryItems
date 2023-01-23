using ManageLibraryItemsAndEmployees.Extensions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml.Linq;

namespace ManageLibraryItemsAndEmployees.Data.Entities
{
    public class Category
    {
      
        public Category(string categoryName)
        {
            CategoryName = categoryName;
            UrlSlug = categoryName.Slugify();
        }
        public Category(int id, string categoryName)
        {
            Id = id;    
            CategoryName = categoryName;
            UrlSlug = categoryName.Slugify();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string CategoryName { get; set; }
        [Required]
        [MaxLength(50)]
        public string UrlSlug { get; protected set; }
        public ICollection<LibraryItem> LibraryItems { get; protected set; }
           = new List<LibraryItem>();

        public LibraryItem SelectLibraryitems
        {
            get
            {
                var selectLibraryitems = LibraryItems.Select(x => x.Id).Prepend(0).Max();
                //var libraryItems = LibraryItems.ToList().ToString().Split(new[] { ' ' })
                //.Select(title => title.First());

                return LibraryItems.FirstOrDefault(x => x.Id == selectLibraryitems);
            }

        }

    }
}
