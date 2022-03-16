using my_books.Data;
using my_books.Data.Models;
using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Services
{
    public class PublishersService
    {
        private AppDbContext _dbContext;
        public PublishersService(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public List<Publisher> GetAllPublishers()
        {
            return _dbContext.Publishers.ToList();
        }

        public Publisher GetPublisherById(int publisherId)
        {
            return _dbContext.Publishers.FirstOrDefault(x => x.Id == publisherId);
        }

        public void AddPublisher(PublisherVM publisher)
        {
            var newPublisher = new Publisher()
            {
                Name = publisher.Name
            };

            _dbContext.Publishers.Add(newPublisher);
            _dbContext.SaveChanges();
        }

        public Publisher UpdatePublisher(int publisherId, Publisher publisher)
        {
            var publisherToUpdate = _dbContext.Publishers.FirstOrDefault(x => x.Id == publisherId);

            if (publisherToUpdate != null)
            {
                publisherToUpdate.Name = publisher.Name;

                _dbContext.SaveChanges();
            }

            return publisherToUpdate;
        }

        public void DeletePublisherById(int publisherId)
        {
            var publisherToDelete = _dbContext.Publishers.FirstOrDefault(x => x.Id == publisherId);

            if (publisherToDelete != null)
            {
                _dbContext.Remove(publisherToDelete);
                _dbContext.SaveChanges();
            }
        }
    }
}
