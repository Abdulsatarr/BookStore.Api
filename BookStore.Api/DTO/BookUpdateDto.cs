using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.DTO
{
    public class BookUpdateDto
    {
        public string? Title { get; set; } 


        public string? Author { get; set; } 

        public string? Genre { get; set; } 
    }
}
