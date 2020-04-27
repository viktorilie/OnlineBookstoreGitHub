using OnlineBookstore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.Services.Service.Interfaces
{
    public interface IAuthorService
    {
        void Add(Author author);
        void Edit(Author author);
        void Delete(Author author);

        IEnumerable<Author> GetAuthors();
        Author GetAuthorById(int id);
    }
}
