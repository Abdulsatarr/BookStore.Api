using BookStore.Api.Models;

namespace BookStore.Api.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(int id);
        Task<IEnumerable<Book>> SearchByTitleAsync(string title);
        Task<Book> AddAsync(Book book);
        Task UpdateAsync(Book book);
        Task DeleteAsync(Book book);
        Task<bool> SaveChangesAsync();
    }
}
