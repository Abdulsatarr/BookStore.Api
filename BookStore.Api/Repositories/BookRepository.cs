using BookStore.Api.Data;
using BookStore.Api.Models;
using BookStore.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _db;
        public BookRepository(AppDbContext db) => _db = db;

        public async Task<Book> AddAsync(Book book)
        {
            await _db.Books.AddAsync(book);
            return book;
        }

        public async Task DeleteAsync(Book book)
        {
            _db.Books.Remove(book);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _db.Books.AsNoTracking().ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _db.Books.FindAsync(id);
        }

        public async Task<IEnumerable<Book>> SearchByTitleAsync(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                return Enumerable.Empty<Book>();

            return await _db.Books
                .AsNoTracking()
                .Where(b => EF.Functions.Like(b.Title, $"%{title}%"))
                .ToListAsync();
        }

        public async Task UpdateAsync(Book book)
        {
            _db.Books.Update(book);
            await Task.CompletedTask;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _db.SaveChangesAsync()) > 0;
        }
    }
}
