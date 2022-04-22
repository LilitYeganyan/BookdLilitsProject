using BookdLilitsProject.Data.Services;
using BookdLilitsProject.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookdLilitsProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private AuthorsService _authorService;
        public AuthorsController(AuthorsService authorsService)
        {
            _authorService = authorsService;
        }


        [HttpPost("Add-Author")]
        public IActionResult AddAuthor([FromBody] AuthorVM author)
        {
            _authorService.AddAuthor(author);
            return Ok();
        }

        [HttpGet("get-auther-with-book-by-id/{id}")]
        public IActionResult GetAutherWithBooks(int id)
        { 
           var response =  _authorService.GetAuthorWithBooks(id);
            return Ok(response);
        }
    }
}
