using BookStore.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/authors/{authorId}/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<BookDto>> GetBooks(int authorId)
        {
            var author = AuthorsDataStore.Current.Authors.FirstOrDefault(x => x.Id == authorId);

            if (author == null)
            {
                return NotFound();
            }

            return Ok(author.Books);
        }

        [HttpGet("{bookid}")]
        public ActionResult<BookDto> GetBook(int authorId, int bookId)
        {
            // find an author first
            var author = AuthorsDataStore.Current.Authors.FirstOrDefault(x => x.Id == authorId);

            if (author == null)
            {
                return NotFound();
            }

            // find a book
            var book = author.Books.FirstOrDefault(x => x.Id == bookId);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }
    }
}
