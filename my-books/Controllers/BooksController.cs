using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Models;
using my_books.Data.ViewModels;
using my_books.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BooksService _booksServcie;

        public BooksController(BooksService booksService)
        {
            _booksServcie = booksService;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = _booksServcie.GetAllBooks(); 

            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _booksServcie.GetBookById(id);

            return Ok(book);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] BookVM book)
        {
            _booksServcie.AddBook(book);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBookById(int id, [FromBody] Book book)
        {
            var uodatedBook =_booksServcie.UpdateBook(id, book);
            return Ok(uodatedBook);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBookById(int id)
        {
            _booksServcie.DeleteBookById(id);
            return Ok();
        }
    }
}
