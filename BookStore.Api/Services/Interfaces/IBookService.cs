using BookStore.Api.DTO;

namespace BookStore.Api.Services.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookReadDto>> GetAllAsync();
        Task<BookReadDto?> GetByIdAsync(int id);
        Task<IEnumerable<BookReadDto>> SearchAsync(string? title);
        Task<BookReadDto> CreateAsync(BookCreateDto dto);
        Task<bool> UpdateAsync(int id, BookUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
