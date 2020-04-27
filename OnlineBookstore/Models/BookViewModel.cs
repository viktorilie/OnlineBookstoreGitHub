using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineBookstore.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.Models
{
    public class BookViewModel
    {
        // Book Data
        public int BookID { get; set; }

        [StringLength(350)]
        public string Title { get; set; }

        public DateTime YearOfIssue { get; set; }

        public int NumberOfPages { get; set; }

        public int UserId { get; set; }

        [StringLength(150)]
        public string Genre { get; set; }

        public double Price { get; set; }

        [StringLength(50)]
        public string BookType { get; set; }

        public string Description { get; set; }

        [StringLength(50)]
        public string Language { get; set; }

        [StringLength(150)]
        public string Country { get; set; }

        public int Edition { get; set; }

        [StringLength(50)]
        public string Dimensions { get; set; }

        public double Weight { get; set; }

        public int Copies { get; set; }
  
        [StringLength(50)]
        public string Shipping { get; set; }

        public string MainPhotoURL { get; set; }

        public List<Photo> Photos { get; set; }

        // Author Data
        [StringLength(350)]
        public string AuthorName { get; set; }

        public int AuthorID { get; set; }

        public Author Author { get; set; }

        public IEnumerable<SelectListItem> Authors { get; set; }

        public string CreateAuthorName { get; set; }

        public string CreateAuthorShortDescription { get; set; }

        // Publisher Data
        [StringLength(250)]
        public string PublisherName { get; set; }
   
        [StringLength(250)]
        public string PublisherCountry { get; set; }
       
        public Publisher Publisher { get; set; }
 
        public int PublisherID { get; set; }

        public IEnumerable<SelectListItem> Publishers { get; set; }

        // Category Data
        public int CategoryID { get; set; }
    
        public IEnumerable<SelectListItem> Categories { get; set; }
     
        public Category Category { get; set; }
      
        [StringLength(150)]
        public string CategoryName { get; set; }

        public string CreateCategoryName { get; set; }


        // Photos Data  
        public string PhotoURL { get; set; }
        public bool IsMainPhoto { get; set; }
        public string DescriptionPhoto { get; set; }

        // Other Data
        public string CreatePublisherName { get; set; }
        public string CreatePublisherCountry { get; set; }

        public string CreatePublisherShortDescription { get; set; }

    }
}
