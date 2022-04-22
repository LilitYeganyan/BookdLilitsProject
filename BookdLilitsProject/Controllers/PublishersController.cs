using BookdLilitsProject.Data.Services;
using BookdLilitsProject.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookdLilitsProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private PublishersService _publisher;
        public PublishersController(PublishersService authorsService)
        {
            _publisher = authorsService;
        }

        [HttpPost("Add-publisher")]
        public IActionResult AddPublisher([FromBody] PublisherVM publisher)
        { 
          _publisher.AddPublisher(publisher);
            return Ok();
        }
    }
}
