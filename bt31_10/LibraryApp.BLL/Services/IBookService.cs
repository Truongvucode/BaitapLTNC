using LibraryApp.BLL.DTOs;

namespace LibraryApp.BLL.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetAllBooksAsync();
        Task<IEnumerable<BookDto>> SearchBooksAsync(string? keyword, int? categoryId);
        Task<BookDto?> GetBookByIdAsync(string bookId);
        Task<BookDto> AddBookAsync(BookDto bookDto);
        Task<bool> UpdateBookAsync(BookDto bookDto);
        Task<bool> DeleteBookAsync(string bookId);
    }
}
