using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Models
{
    public class BookForCreationDto
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
    }
}
