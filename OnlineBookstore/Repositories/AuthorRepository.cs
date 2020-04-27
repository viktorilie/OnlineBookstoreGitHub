using OnlineBookstore.Data;
using OnlineBookstore.Data.Entities;
using OnlineBookstore.Repositories.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DataContext _context;

        public AuthorRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public void Delete(Author author)
        {
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }

        public void Edit(Author author)
        {
            _context.Authors.Update(author);
            _context.SaveChanges();
        }

        public Author GetAuthorById(int id)
        {
            var result = _context.Authors.FirstOrDefault(x => x.Id == id);
            return result;
        }

        public Author GetAuthorByPopularity()
        {
            var result = _context.Authors.Where(x => x.Popularity == true).FirstOrDefault();
            return result;
        }

        public IEnumerable<Author> GetAuthors()
        {
            var result = _context.Authors.AsEnumerable();
            return result;
        }
    }
}
