using BookStore.Api.DTO;
using BookStore.Api.Models;
using BookStore.Api.Repositories.Interfaces;
using BookStore.Api.Services.Interfaces;

namespace BookStore.Api.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repo;
        public BookService(IBookRepository repo) => _repo = repo;

        public async Task<BookReadDto> CreateAsync(BookCreateDto dto)
        {
            var book = new Book
            {
                Title = dto.Title.Trim(),
                Author = dto.Author.Trim(),
                Genre = dto.Genre.Trim()
            };

            await _repo.AddAsync(book);
            await _repo.SaveChangesAsync();

            return new BookReadDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Genre = book.Genre
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var book = await _repo.GetByIdAsync(id);
            if (book == null) return false;
            await _repo.DeleteAsync(book);
            return await _repo.SaveChangesAsync();
        }

        public async Task<IEnumerable<BookReadDto>> GetAllAsync()
        {
            var books = await _repo.GetAllAsync();
            return books.Select(b => new BookReadDto
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                Genre = b.Genre
            });
        }

        public async Task<BookReadDto?> GetByIdAsync(int id)
        {
            var b = await _repo.GetByIdAsync(id);
            if (b == null) return null;
            return new BookReadDto { Id = b.Id, Title = b.Title, Author = b.Author, Genre = b.Genre };
        }

        public async Task<IEnumerable<BookReadDto>> SearchAsync(string? title)
        {
            if (string.IsNullOrWhiteSpace(title))
                return Enumerable.Empty<BookReadDto>();

            var books = await _repo.SearchByTitleAsync(title.Trim());
            return books.Select(b => new BookReadDto
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                Genre = b.Genre
            });
        }

        public async Task<bool> UpdateAsync(int id, BookUpdateDto dto)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return false;

            // Update only if value is not null or empty
            if (!string.IsNullOrWhiteSpace(dto.Title))
                existing.Title = dto.Title.Trim();

            if (!string.IsNullOrWhiteSpace(dto.Author))
                existing.Author = dto.Author.Trim();

            if (!string.IsNullOrWhiteSpace(dto.Genre))
                existing.Genre = dto.Genre.Trim();

            await _repo.UpdateAsync(existing);
            return await _repo.SaveChangesAsync();
        }
    }
}
