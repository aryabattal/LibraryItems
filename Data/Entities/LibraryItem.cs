using ManageLibraryItemsAndEmployees.Extensions;
using System;
using System.ComponentModel.DataAnnotations;

 namespace ManageLibraryItemsAndEmployees.Data.Entities
{
    public class LibraryItem
    {
        public LibraryItem(string title, string author,int? pages, Boolean isBorrowable, string borrower,DateTime? borrowerDate, string type)
        {
            Title = title;
            Author = author;
            Pages = pages;
            IsBorrowable = isBorrowable;
            Borrower = borrower;
            BorrowerDate = borrowerDate;
            Type = type;
            UrlSlug = Title.Slugify();
        }


        public LibraryItem(int id, int categoryId, string title, string author, int? pages, bool isBorrowable, string borrower, DateTime? borrowerDate, string type)
        {
            Id = id;
            CategoryId = categoryId;
            Title = title;
            Author = author;
            Pages = pages;
            IsBorrowable = isBorrowable;
            Borrower = borrower;
            BorrowerDate = borrowerDate;
            Type = type;
            UrlSlug = Title.Slugify();
        }


        [Key]
        public int Id { get; set; }

        public int CategoryId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MaxLength(50)]
        public string Author { get; set; }
       
        public int? Pages { get; set; }
        public int? RunTimeMinutes { get; set; }
        public Boolean IsBorrowable{ get; set; }
        public string Borrower { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? BorrowerDate { get; set; }
        public string Type { get; set; }
        [Required]
        [MaxLength(50)]
        public string UrlSlug { get; protected set; }
        public Category Category { get; set; }

    }


    //public class Type
    //{
    //    public Book Book { get; set; }
    //    public string ReferenceBook { get; set; }
    //    public string Dvd { get; set; }
    //    public string AudioBook { get; set; }

    //}

    //public class Book
    //{
    //    public int Id { get; set; }

    //    [Required]
    //    [MaxLength(50)]
    //    public string Title { get; set; }

    //    [Required]
    //    [MaxLength(50)]
    //    public string Author { get; set; }

    //    public int Pages { get; set; }
    //    public Boolean IsBorrowable { get; set; }
    //    public int CategoryId { get; set; }
    //    public string Borrower { get; set; }

    //    [DataType(DataType.Date)]
    //    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    //    public DateTime? BorrowerDate { get; set; }

    //}
}
