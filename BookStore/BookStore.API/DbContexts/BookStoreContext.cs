using BookStore.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.DbContexts
{
    public class BookStoreContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed Authors
            modelBuilder.Entity<Author>().HasData(
                new Author("Jane Austen") { Id = 1 },
                new Author("Mark Twain") { Id = 2 },
                new Author("George Orwell") { Id = 3 },
                new Author("Agatha Christie") { Id = 4 },
                new Author("J.K. Rowling") { Id = 5 }
            );

            // Seed Books
            modelBuilder.Entity<Book>().HasData(
                // Jane Austen
                new Book("Pride and Prejudice") { Id = 1, AuthorId = 1 },
                new Book("Sense and Sensibility") { Id = 2, AuthorId = 1 },
                new Book("Emma") { Id = 3, AuthorId = 1 },

                // Mark Twain
                new Book("Adventures of Huckleberry Finn") { Id = 4, AuthorId = 2 },
                new Book("The Adventures of Tom Sawyer") { Id = 5, AuthorId = 2 },
                new Book("A Connecticut Yankee in King Arthur's Court") { Id = 6, AuthorId = 2 },

                // George Orwell
                new Book("1984") { Id = 7, AuthorId = 3 },
                new Book("Animal Farm") { Id = 8, AuthorId = 3 },
                new Book("Homage to Catalonia") { Id = 9, AuthorId = 3 },

                // Agatha Christie
                new Book("Murder on the Orient Express") { Id = 10, AuthorId = 4 },
                new Book("The ABC Murders") { Id = 11, AuthorId = 4 },
                new Book("And Then There Were None") { Id = 12, AuthorId = 4 },

                // J.K. Rowling
                new Book("Harry Potter and the Sorcerer's Stone") { Id = 13, AuthorId = 5 },
                new Book("Harry Potter and the Chamber of Secrets") { Id = 14, AuthorId = 5 },
                new Book("Harry Potter and the Prisoner of Azkaban") { Id = 15, AuthorId = 5 }
            );


            base.OnModelCreating(modelBuilder);
        }
    }
}
