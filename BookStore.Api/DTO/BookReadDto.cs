namespace BookStore.Api.DTO
{
    public class BookReadDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; } 
        public string? Genre { get; set; } 
    }
}
