using BookdLilitsProject.Data.Services;
using BookdLilitsProject.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookdLilitsProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private BooksService _booksService;
        public BooksController(BooksService booksService)
        {
            _booksService = booksService;
        }
        [HttpGet("Get-all-books")]
        public IActionResult GetallBooks()
        { 
          var allBooks = _booksService.GetAllBooks();
            return Ok(allBooks);
        }

        [HttpGet("Get-boo-by-id/{id}")]
        public IActionResult GetBookById(int id)
        { 
          var book = _booksService.GetBookById(id);
            return Ok(book);
        }

        [HttpPost("Add-book-with-authors")]
        public IActionResult AddBook([FromBody] BookVM book)
        { 
           _booksService.AddBookWithAuthors(book);
            return Ok();
        }

        [HttpPut("Update-book-by-id/{id}")]
        public IActionResult UpdateBookById(int id, [FromBody] BookVM book)
        {
            var _book = _booksService.UpdatBookById(id, book);
            return Ok(_book);
        }

        [HttpDelete("Delete-book-by-id/{id}")]
        public IActionResult DeleteBookById(int id)
        {
            _booksService.DeletebyId(id);
            return Ok();
            
        }
    }
}
