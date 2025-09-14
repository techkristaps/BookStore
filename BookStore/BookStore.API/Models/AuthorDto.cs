namespace BookStore.API.Models
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<BookDto> Books { get; set; } = new List<BookDto>();
    }
}
