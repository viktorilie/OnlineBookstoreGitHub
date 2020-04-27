using OnlineBookstore.Data.Entities;
using OnlineBookstore.Repositories.Repositories.Interfaces;
using OnlineBookstore.Services.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository _publisherRepository;

        public PublisherService(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        public void Add(Publisher publisher)
        {
            _publisherRepository.Add(publisher);
        }

        public void Delete(int id)
        {
            _publisherRepository.Delete(id);
        }

        public void Edit(Publisher publisher)
        {
            _publisherRepository.Edit(publisher);
        }

        public Publisher GetPublisherById(int id)
        {
            var result = _publisherRepository.GetPublisherById(id);
            return result;
        }

        public IEnumerable<Publisher> GetPublishers()
        {
            var result = _publisherRepository.GetPublishers();
            return result;
        }
    }
}
