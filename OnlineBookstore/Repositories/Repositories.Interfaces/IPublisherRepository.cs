using OnlineBookstore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.Repositories.Repositories.Interfaces
{
    public interface IPublisherRepository
    {
        void Add(Publisher publisher);
        void Edit(Publisher publisher);
        void Delete(int id);
        IEnumerable<Publisher> GetPublishers();
        Publisher GetPublisherById(int id);
    }
}
