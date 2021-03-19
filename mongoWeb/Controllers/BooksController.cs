using BookServices.Core;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace mongoWeb.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookServices bookServices;

        public BooksController(IBookServices bookServices)
        {
            this.bookServices = bookServices;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            return Ok(bookServices.GetBooks());
        }

        [HttpGet("{id}")]
        public IActionResult GetBook(string id)
        {
            return Ok(bookServices.GetBook(id));
        }

        [HttpPost]
        public IActionResult AddBook(Book data)
        {
            return Ok(bookServices.addBook(data));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(string id)
        {
            bookServices.DeleteBook(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult DeleteBook(string id, Book data)
        {
            bookServices.updateBook(id, data);
            return Ok(bookServices.GetBook(id));
        }
    }
}
