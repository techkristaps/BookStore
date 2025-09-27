using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.API.Entities
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        // navigation property
        [ForeignKey("AuthorId")]
        public Author? Author { get; set; }

        //foreign key
        public int AuthorId { get; set; }

        public Book(string title)
        {
            Title = title;
        }
    }
}
