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
    public class AuthorsController : ControllerBase
    {
        public AuthorsService _authorsService;

        public AuthorsController(AuthorsService authorsService)
        {
            _authorsService = authorsService;
        }

        [HttpGet]
        public IActionResult GetAuthorBooks()
        {
            var authors = _authorsService.GetAllAuthors();

            return Ok(authors);
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthorById(int id)
        {
            var book = _authorsService.GetAuthorById(id);

            return Ok(book);
        }

        [HttpPost]
        public IActionResult AddAuthor([FromBody] AuthorVM author)
        {
            _authorsService.AddAuthor(author);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAuthorById(int id, [FromBody] Author author)
        {
            var uodatedAuthor = _authorsService.UpdateAuthor(id, author);
            return Ok(uodatedAuthor);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthorById(int id)
        {
            _authorsService.DeleteAuthorById(id);
            return Ok();
        }
    }
}
