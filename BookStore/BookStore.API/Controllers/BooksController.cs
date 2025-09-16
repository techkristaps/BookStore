using BookStore.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/authors/{authorId}/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;

        public BooksController(ILogger<BooksController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public ActionResult<IEnumerable<BookDto>> GetBooks(int authorId)
        {
            var author = AuthorsDataStore.Current.Authors.FirstOrDefault(x => x.Id == authorId);

            if (author == null)
            {
                _logger.LogInformation($"Author {authorId} was not found when accessing books.");
                return NotFound();
            }

            return Ok(author.Books);
        }

        [HttpGet("{bookId}", Name = "GetBook")]
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

        [HttpPost]
        public ActionResult<BookDto> CreateBook(int authorId, [FromBody] BookForCreationDto book)
        {
            // find an author first
            var author = AuthorsDataStore.Current.Authors.FirstOrDefault(x => x.Id == authorId);

            if (author == null)
            {
                return NotFound();
            }

            // demo purposes
            var maxBooks = AuthorsDataStore.Current.Authors.SelectMany(x => x.Books).Max(b => b.Id);

            var finalBook = new BookDto()
            {
                Id = ++maxBooks,
                Title = book.Title
            };

            author.Books.Add(finalBook);

            return CreatedAtRoute("GetBook", new
            {
                authorId = authorId,
                BookId = finalBook.Id
            }, finalBook);
        }

        [HttpPut("{bookId}")]
        public ActionResult UpdateBook([FromRoute] int authorId, [FromRoute] int bookId, [FromBody] BookForUpdateDto book)
        {
            // find an author first
            var author = AuthorsDataStore.Current.Authors.FirstOrDefault(x => x.Id == authorId);

            if (author == null)
            {
                return NotFound();
            }

            // find a book
            var bookFromStore = author.Books.FirstOrDefault(x => x.Id == bookId);

            if (bookFromStore == null)
            {
                return NotFound();
            }

            bookFromStore.Title = book.Title;

            return NoContent();
        }

        [HttpPatch("{bookId}")]
        public ActionResult PartiallyUpdateBook(int authorId, int bookId, JsonPatchDocument<BookForUpdateDto> patchDocument)
        {
            // find an author first
            var author = AuthorsDataStore.Current.Authors.FirstOrDefault(x => x.Id == authorId);

            if (author == null)
            {
                return NotFound();
            }

            // find a book
            var bookFromStore = author.Books.FirstOrDefault(x => x.Id == bookId);

            if (bookFromStore == null)
            {
                return NotFound();
            }

            var bookToPatch = new BookForUpdateDto()
            {
                Title = bookFromStore.Title
            };

            patchDocument.ApplyTo(bookToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(bookToPatch))
            {
                return BadRequest(ModelState);
            }

            bookFromStore.Title = bookToPatch.Title;

            return NoContent();
        }

        [HttpDelete("{bookId}")]
        public ActionResult DeleteBook(int authorId, int bookId)
        {
            // find an author first
            var author = AuthorsDataStore.Current.Authors.FirstOrDefault(x => x.Id == authorId);

            if (author == null)
            {
                return NotFound();
            }

            // find a book
            var bookFromStore = author.Books.FirstOrDefault(x => x.Id == bookId);

            if (bookFromStore == null)
            {
                return NotFound();
            }

            author.Books.Remove(bookFromStore);
            return NoContent();
        }
    }
}
