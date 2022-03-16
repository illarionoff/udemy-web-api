using my_books.Data;
using my_books.Data.Models;
using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Services
{
    public class AuthorsService
    {
        private AppDbContext _dbContext;
        public AuthorsService(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public List<Author> GetAllAuthors()
        {
            return _dbContext.Authors.ToList();
        }

        public Author GetAuthorById(int authorId)
        {
            return _dbContext.Authors.FirstOrDefault(x => x.Id == authorId);
        }

        public void AddAuthor(AuthorVM author)
        {
            var newAuthor = new Author()
            {
                FullName = author.FullName
            };

            _dbContext.Authors.Add(newAuthor);
            _dbContext.SaveChanges();
        }

        public Author UpdateAuthor(int authorId, Author author)
        {
            var authorToUpdate = _dbContext.Authors.FirstOrDefault(x => x.Id == authorId);

            if (authorToUpdate != null)
            {
                authorToUpdate.FullName = author.FullName;

                _dbContext.SaveChanges();
            }

            return authorToUpdate;
        }

        public void DeleteAuthorById(int authorId)
        {
            var authorToDelete = _dbContext.Authors.FirstOrDefault(x => x.Id == authorId);

            if (authorToDelete != null)
            {
                _dbContext.Remove(authorToDelete);
                _dbContext.SaveChanges();
            }
        }
    }
}
