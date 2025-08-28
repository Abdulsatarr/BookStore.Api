using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.DTO
{
    public class BookCreateDto
    {
        [Required, MaxLength(250)]
        public string? Title { get; set; }

        [Required, MaxLength(150)]
        public string? Author { get; set; } 

        [Required, MaxLength(100)]
        public string? Genre { get; set; } 
    }
}
