
using System;
using System.Linq;

namespace ManageLibraryItemsAndEmployees.Extensions
{
    public static class StringExtensions
    {
        // "Black T-Shirt" > "black-tshirt"
        // "T-Shirts" > "tshirts
        // whitespace kan och fram ska tas bort, "   Black T-Shirt   "  >   "black-tshirt"
        public static string Slugify(this string name) => name.Trim()
            .Replace("-", "")
            .Replace(" ", "-")
            .ToLower();

        public static string FirstCharLibraryItem(this string title) => String.Join(String.Empty, title.Split(new[] { ' ' })
           .Select(title => title.First()));
           
    
    }
}
