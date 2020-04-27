using OnlineBookstore.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        public List<Subcategory> Subcategory { get; set; }
    }
}
