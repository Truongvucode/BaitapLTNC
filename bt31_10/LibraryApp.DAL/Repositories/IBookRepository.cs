using LibraryApp.DAL.Entities;

namespace LibraryApp.DAL.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<IEnumerable<Book>> SearchAsync(string? keyword, int? categoryId);
        Task<Book?> GetByIdAsync(string bookId);
        Task<Book> AddAsync(Book book);
        Task<bool> UpdateAsync(Book book);
        Task<bool> DeleteAsync(string bookId);
        Task<bool> ExistsAsync(string bookId);
    }
}
