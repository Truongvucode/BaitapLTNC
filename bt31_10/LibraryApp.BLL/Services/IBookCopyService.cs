using LibraryApp.BLL.DTOs;
using LibraryApp.DAL.Enums;

namespace LibraryApp.BLL.Services
{
    public interface IBookCopyService
    {
        Task<IEnumerable<BookCopyDto>> GetCopiesByBookIdAsync(string bookId);
        Task<IEnumerable<BookCopyDto>> AddCopiesAsync(string bookId, int quantity, PhysicalCondition initialCondition);
        Task<BookCopyDto> AddSingleCopyAsync(string bookId, PhysicalCondition condition);
        Task<bool> UpdateCopyAsync(string copyId, CopyStatus status, PhysicalCondition condition);
        Task<bool> DeleteCopyAsync(string copyId);
    }
}
