using LibraryApp.BLL.DTOs;
using LibraryApp.BLL.Exceptions;
using LibraryApp.DAL.Entities;
using LibraryApp.DAL.Enums;
using LibraryApp.DAL.Repositories;

namespace LibraryApp.BLL.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICategoryRepository _categoryRepository;

        public BookService(IBookRepository bookRepository, ICategoryRepository categoryRepository)
        {
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<BookDto>> GetAllBooksAsync()
        {
            var books = await _bookRepository.GetAllAsync();
            return books.Select(MapToDto);
        }

        public async Task<IEnumerable<BookDto>> SearchBooksAsync(string? keyword, int? categoryId)
        {
            var books = await _bookRepository.SearchAsync(keyword, categoryId);
            return books.Select(MapToDto);
        }

        public async Task<BookDto?> GetBookByIdAsync(string bookId)
        {
            var book = await _bookRepository.GetByIdAsync(bookId);
            return book != null ? MapToDto(book) : null;
        }

        public async Task<BookDto> AddBookAsync(BookDto bookDto)
        {
            ValidateBook(bookDto, isNew: true);

            // Kiểm tra trùng mã sách
            if (await _bookRepository.ExistsAsync(bookDto.BookId))
            {
                throw new BusinessException($"Mã sách '{bookDto.BookId}' đã tồn tại trong hệ thống. Vui lòng chọn mã khác!");
            }

            // Kiểm tra thể loại có hợp lệ không
            var category = await _categoryRepository.GetByIdAsync(bookDto.CategoryId);
            if (category == null)
            {
                throw new BusinessException("Thể loại đã chọn không tồn tại!");
            }

            var book = new Book
            {
                BookId = bookDto.BookId.Trim().ToUpper(),
                Title = bookDto.Title.Trim(),
                Author = bookDto.Author.Trim(),
                Publisher = string.IsNullOrWhiteSpace(bookDto.Publisher) ? null : bookDto.Publisher.Trim(),
                Price = bookDto.Price,
                PublishYear = bookDto.PublishYear,
                CategoryId = bookDto.CategoryId
            };

            await _bookRepository.AddAsync(book);
            book.Category = category;

            return MapToDto(book);
        }

        public async Task<bool> UpdateBookAsync(BookDto bookDto)
        {
            ValidateBook(bookDto, isNew: false);

            var existing = await _bookRepository.GetByIdAsync(bookDto.BookId);
            if (existing == null)
            {
                throw new BusinessException($"Không tìm thấy đầu sách có mã '{bookDto.BookId}' để cập nhật!");
            }

            var category = await _categoryRepository.GetByIdAsync(bookDto.CategoryId);
            if (category == null)
            {
                throw new BusinessException("Thể loại đã chọn không tồn tại!");
            }

            existing.Title = bookDto.Title.Trim();
            existing.Author = bookDto.Author.Trim();
            existing.Publisher = string.IsNullOrWhiteSpace(bookDto.Publisher) ? null : bookDto.Publisher.Trim();
            existing.Price = bookDto.Price;
            existing.PublishYear = bookDto.PublishYear;
            existing.CategoryId = bookDto.CategoryId;

            return await _bookRepository.UpdateAsync(existing);
        }

        public async Task<bool> DeleteBookAsync(string bookId)
        {
            var book = await _bookRepository.GetByIdAsync(bookId);
            if (book == null)
            {
                throw new BusinessException($"Không tìm thấy đầu sách có mã '{bookId}'!");
            }

            // Nghiệp vụ: Không cho xóa nếu còn bản sao đang ở trạng thái "Đang mượn"
            if (book.Copies != null && book.Copies.Any(c => c.Status == CopyStatus.Borrowed))
            {
                throw new BusinessException($"Không thể xóa đầu sách '{book.Title}' vì có bản sao đang ở trạng thái 'Đang mượn'!");
            }

            return await _bookRepository.DeleteAsync(bookId);
        }

        private static void ValidateBook(BookDto bookDto, bool isNew)
        {
            if (isNew)
            {
                if (string.IsNullOrWhiteSpace(bookDto.BookId))
                {
                    throw new BusinessException("Mã sách không được để trống!");
                }
                if (bookDto.BookId.Trim().Length > 20)
                {
                    throw new BusinessException("Mã sách không được vượt quá 20 ký tự!");
                }
            }

            if (string.IsNullOrWhiteSpace(bookDto.Title))
            {
                throw new BusinessException("Tên đầu sách không được để trống!");
            }
            if (bookDto.Title.Trim().Length > 200)
            {
                throw new BusinessException("Tên đầu sách không được vượt quá 200 ký tự!");
            }

            if (string.IsNullOrWhiteSpace(bookDto.Author))
            {
                throw new BusinessException("Tác giả không được để trống!");
            }
            if (bookDto.Author.Trim().Length > 150)
            {
                throw new BusinessException("Tên tác giả không được vượt quá 150 ký tự!");
            }

            if (bookDto.CategoryId <= 0)
            {
                throw new BusinessException("Vui lòng chọn thể loại cho đầu sách!");
            }

            if (bookDto.Price < 0)
            {
                throw new BusinessException("Giá sách phải lớn hơn hoặc bằng 0!");
            }

            if (bookDto.PublishYear.HasValue)
            {
                int currentYear = DateTime.Now.Year;
                if (bookDto.PublishYear.Value < 1000 || bookDto.PublishYear.Value > currentYear)
                {
                    throw new BusinessException($"Năm xuất bản không hợp lệ (phải từ năm 1000 đến năm {currentYear})!");
                }
            }
        }

        private static BookDto MapToDto(Book b)
        {
            return new BookDto
            {
                BookId = b.BookId,
                Title = b.Title,
                Author = b.Author,
                Publisher = b.Publisher,
                Price = b.Price,
                PublishYear = b.PublishYear,
                CategoryId = b.CategoryId,
                CategoryName = b.Category?.CategoryName ?? string.Empty,
                CopyCount = b.Copies?.Count ?? 0
            };
        }
    }
}
