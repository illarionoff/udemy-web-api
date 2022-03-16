using my_books.Data;
using my_books.Data.Models;
using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Services
{
    public class BooksService
    {
        private AppDbContext _dbContext;
        public BooksService(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public List<Book> GetAllBooks()
        {
            return _dbContext.Books.ToList();
        }

        public Book GetBookById(int bookId)
        {
            return _dbContext.Books.FirstOrDefault(x => x.Id == bookId);
        }

        public void AddBook(BookVM book)
        {
            var newBook = new Book()
            {
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.IsRead ? book.Rate.Value : null,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now
            };

            _dbContext.Books.Add(newBook);
            _dbContext.SaveChanges();
        }

        internal Book UpdateBook(int bookId, Book book)
        {
            var bookToUpdate = _dbContext.Books.FirstOrDefault(x => x.Id == bookId);

            if(bookToUpdate != null)
            {
                bookToUpdate.Title = book.Title;
                bookToUpdate.Author = book.Author;
                bookToUpdate.Description = book.Description;
                bookToUpdate.IsRead = book.IsRead;
                bookToUpdate.DateRead = book.IsRead ? book.DateRead.Value : null;
                bookToUpdate.Rate = book.IsRead ? book.Rate.Value : null;
                bookToUpdate.Genre = book.Genre;
                bookToUpdate.CoverUrl = book.CoverUrl;

                _dbContext.SaveChanges();
            }

            return bookToUpdate;
        }

        internal void DeleteBookById(int bookId)
        {
            var bookToDelete = _dbContext.Books.FirstOrDefault(x => x.Id == bookId);

            if (bookToDelete != null)
            {
                _dbContext.Remove(bookToDelete);
                _dbContext.SaveChanges();
            }
        }
    }
}
