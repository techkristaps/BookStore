using BookStore.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<AuthorDto>> GetAuthors()
        {
            return Ok(AuthorsDataStore.Current.Authors);
        }

        [HttpGet("{id}")]
        public ActionResult<AuthorDto> GetAuthor(int id)
        {
            var authorToReturn = AuthorsDataStore.Current.Authors.FirstOrDefault(x => x.Id == id);

            if (authorToReturn == null)
            {
                return NotFound();
            }

            return Ok(authorToReturn);
        }
    }
}
