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
    public class PublishersController : ControllerBase
    {
        public PublishersService _publishersService;

        public PublishersController(PublishersService publishersService)
        {
            _publishersService = publishersService;
        }

        [HttpGet]
        public IActionResult GetAllPublishers()
        {
            var authors = _publishersService.GetAllPublishers();

            return Ok(authors);
        }

        [HttpGet("{id}")]
        public IActionResult GetPublisherById(int id)
        {
            var book = _publishersService.GetPublisherById(id);

            return Ok(book);
        }

        [HttpPost]
        public IActionResult AddPublisher([FromBody] PublisherVM publisher)
        {
            _publishersService.AddPublisher(publisher);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAuthorById(int id, [FromBody] Publisher publisher)
        {
            var updatedPublisher = _publishersService.UpdatePublisher(id, publisher);
            return Ok(updatedPublisher);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePublisherById(int id)
        {
            _publishersService.DeletePublisherById(id);
            return Ok();
        }
    }
}
