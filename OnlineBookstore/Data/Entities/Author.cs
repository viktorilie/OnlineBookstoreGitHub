using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.Data.Entities
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [StringLength(350)]
        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public bool Popularity { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
