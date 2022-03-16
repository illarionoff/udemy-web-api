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

        public List<BookWithAuthorsVM> GetAllBooks()
        {
            return _dbContext.Books.Select(x => new BookWithAuthorsVM()
            {
                Title = x.Title,
                Description = x.Description,
                IsRead = x.IsRead,
                DateRead = x.IsRead ? x.DateRead.Value : null,
                Rate = x.IsRead ? x.Rate.Value : null,
                Genre = x.Genre,
                CoverUrl = x.CoverUrl,
                PublisherName = x.Publisher.Name,
                AuthorNames = x.Book_Authors.Select(x => x.Author.FullName).ToList()
            }).ToList();
        }

        public BookWithAuthorsVM GetBookById(int bookId)
        {
            var book = _dbContext.Books.Where(x => x.Id == bookId).Select(x => new BookWithAuthorsVM()
            {
                Title = x.Title,
                Description = x.Description,
                IsRead = x.IsRead,
                DateRead = x.IsRead ? x.DateRead.Value : null,
                Rate = x.IsRead ? x.Rate.Value : null,
                Genre = x.Genre,
                CoverUrl = x.CoverUrl,
                PublisherName = x.Publisher.Name,
                AuthorNames = x.Book_Authors.Select(x => x.Author.FullName).ToList()
            }).FirstOrDefault();

            return book;
        }

        public void AddBook(BookVM book)
        {
            var newBook = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.IsRead ? book.Rate.Value : null,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now,
                PublisherId = book.PublisherId,
            };

            _dbContext.Books.Add(newBook);
            _dbContext.SaveChanges();

            foreach (var authorId in  book.AuthorIds)
            {
                var book_author = new Book_Author()
                {
                    BookId = newBook.Id,
                    AuthorId = authorId
                };

                _dbContext.Books_Authors.Add(book_author);
                _dbContext.SaveChanges();
            }
        }

        public Book UpdateBook(int bookId, Book book)
        {
            var bookToUpdate = _dbContext.Books.FirstOrDefault(x => x.Id == bookId);

            if(bookToUpdate != null)
            {
                bookToUpdate.Title = book.Title;
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

        public void DeleteBookById(int bookId)
        {
            var bookToDelete = _dbContext.Books.FirstOrDefault(x => x.Id == bookId);

            if (bookToDelete != null)
            {
                _dbContext.Books.Remove(bookToDelete);
                _dbContext.SaveChanges();
            }
        }
    }
}
