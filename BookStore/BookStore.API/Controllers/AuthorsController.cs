using BookStore.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorsDataStore _authorsDataStore;

        public AuthorsController(AuthorsDataStore authorsDataStore)
        {
            _authorsDataStore = authorsDataStore ?? throw new ArgumentNullException(nameof(authorsDataStore));
        }

        // IEnumerable returns a collection of items of type T
        [HttpGet]
        public ActionResult<IEnumerable<AuthorDto>> GetAuthors()
        {
            return Ok(_authorsDataStore.Authors);
        }

        // ActionResult<T> lets you return both data and HTTP status codes
        [HttpGet("{id}")]
        public ActionResult<AuthorDto> GetAuthor(int id)
        {
            var authorToReturn = _authorsDataStore.Authors.FirstOrDefault(x => x.Id == id);

            if (authorToReturn == null)
            {
                return NotFound();
            }

            return Ok(authorToReturn);
        }
    }
}
