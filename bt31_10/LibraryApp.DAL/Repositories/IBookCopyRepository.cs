using LibraryApp.DAL.Entities;

namespace LibraryApp.DAL.Repositories
{
    public interface IBookCopyRepository
    {
        Task<IEnumerable<BookCopy>> GetByBookIdAsync(string bookId);
        Task<BookCopy?> GetByIdAsync(string copyId);
        Task<BookCopy> AddAsync(BookCopy copy);
        Task<bool> AddRangeAsync(IEnumerable<BookCopy> copies);
        Task<bool> UpdateAsync(BookCopy copy);
        Task<bool> DeleteAsync(string copyId);
        Task<int> GetNextSequenceAsync(string bookId);
    }
}
