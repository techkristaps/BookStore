using BookStore.API.Models;

namespace BookStore.API
{
    public class AuthorsDataStore
    {
        public List<AuthorDto> Authors { get; set; }
        //public static AuthorsDataStore Current { get; set; } = new AuthorsDataStore();

        public AuthorsDataStore()
        {
            Authors = new List<AuthorDto>()
            {
                new AuthorDto()
                {
                    Id = 1,
                    Name = "Jane Austen",
                    Books = new List<BookDto>()
                    {
                        new BookDto() { Id = 1, Title = "Pride and Prejudice" },
                        new BookDto() { Id = 2, Title = "Sense and Sensibility" },
                        new BookDto() { Id = 3, Title = "Emma" }
                    }
                },
                new AuthorDto()
                {
                    Id = 2,
                    Name = "Mark Twain",
                    Books = new List<BookDto>()
                    {
                        new BookDto() { Id = 4, Title = "Adventures of Huckleberry Finn" },
                        new BookDto() { Id = 5, Title = "The Adventures of Tom Sawyer" },
                        new BookDto() { Id = 6, Title = "A Connecticut Yankee in King Arthur's Court" }
                    }
                },
                new AuthorDto()
                {
                    Id = 3,
                    Name = "George Orwell",
                    Books = new List<BookDto>()
                    {
                        new BookDto() { Id = 7, Title = "1984" },
                        new BookDto() { Id = 8, Title = "Animal Farm" },
                        new BookDto() { Id = 9, Title = "Homage to Catalonia" }
                    }
                },
                new AuthorDto()
                {
                    Id = 4,
                    Name = "Agatha Christie",
                    Books = new List<BookDto>()
                    {
                        new BookDto() { Id = 10, Title = "Murder on the Orient Express" },
                        new BookDto() { Id = 11, Title = "The ABC Murders" },
                        new BookDto() { Id = 12, Title = "And Then There Were None" }
                    }
                },
                new AuthorDto()
                {
                    Id = 5,
                    Name = "J.K. Rowling",
                    Books = new List<BookDto>()
                    {
                        new BookDto() { Id = 13, Title = "Harry Potter and the Sorcerer's Stone" },
                        new BookDto() { Id = 14, Title = "Harry Potter and the Chamber of Secrets" },
                        new BookDto() { Id = 15, Title = "Harry Potter and the Prisoner of Azkaban" }
                    }
                },
            };
        }

    }
}
