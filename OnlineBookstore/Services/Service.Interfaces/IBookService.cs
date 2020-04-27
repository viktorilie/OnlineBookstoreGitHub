using OnlineBookstore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.Services.Service.Interfaces
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooks();
        void Add(Book book);
        void Edit(Book book);
        void Delete(int bookID);
        Book GetBookById(int id);
    }
}
