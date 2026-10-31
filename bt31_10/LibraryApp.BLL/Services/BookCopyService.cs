using LibraryApp.BLL.DTOs;
using LibraryApp.BLL.Exceptions;
using LibraryApp.DAL.Entities;
using LibraryApp.DAL.Enums;
using LibraryApp.DAL.Repositories;

namespace LibraryApp.BLL.Services
{
    public class BookCopyService : IBookCopyService
    {
        private readonly IBookCopyRepository _bookCopyRepository;
        private readonly IBookRepository _bookRepository;

        public BookCopyService(IBookCopyRepository bookCopyRepository, IBookRepository bookRepository)
        {
            _bookCopyRepository = bookCopyRepository;
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<BookCopyDto>> GetCopiesByBookIdAsync(string bookId)
        {
            var copies = await _bookCopyRepository.GetByBookIdAsync(bookId);
            return copies.Select(MapToDto);
        }

        public async Task<IEnumerable<BookCopyDto>> AddCopiesAsync(string bookId, int quantity, PhysicalCondition initialCondition)
        {
            if (string.IsNullOrWhiteSpace(bookId))
            {
                throw new BusinessException("Mã sách không hợp lệ!");
            }

            var book = await _bookRepository.GetByIdAsync(bookId);
            if (book == null)
            {
                throw new BusinessException($"Đầu sách có mã '{bookId}' không tồn tại!");
            }

            if (quantity <= 0)
            {
                throw new BusinessException("Số lượng bản sao cần nhập phải lớn hơn 0!");
            }

            if (quantity > 100)
            {
                throw new BusinessException("Mỗi lần nhập tối đa không quá 100 bản sao!");
            }

            int startSeq = await _bookCopyRepository.GetNextSequenceAsync(bookId);
            var newCopies = new List<BookCopy>();

            for (int i = 0; i < quantity; i++)
            {
                int currentSeq = startSeq + i;
                string copyId = $"{bookId}.{currentSeq:D3}";

                newCopies.Add(new BookCopy
                {
                    CopyId = copyId,
                    BookId = bookId,
                    Status = CopyStatus.Available, // Mặc định là Sẵn sàng
                    PhysicalCondition = initialCondition
                });
            }

            await _bookCopyRepository.AddRangeAsync(newCopies);
            return newCopies.Select(MapToDto);
        }

        public async Task<BookCopyDto> AddSingleCopyAsync(string bookId, PhysicalCondition condition)
        {
            var result = await AddCopiesAsync(bookId, 1, condition);
            return result.First();
        }

        public async Task<bool> UpdateCopyAsync(string copyId, CopyStatus status, PhysicalCondition condition)
        {
            var copy = await _bookCopyRepository.GetByIdAsync(copyId);
            if (copy == null)
            {
                throw new BusinessException($"Không tìm thấy bản sao '{copyId}'!");
            }

            copy.Status = status;
            copy.PhysicalCondition = condition;

            return await _bookCopyRepository.UpdateAsync(copy);
        }

        public async Task<bool> DeleteCopyAsync(string copyId)
        {
            var copy = await _bookCopyRepository.GetByIdAsync(copyId);
            if (copy == null)
            {
                throw new BusinessException($"Không tìm thấy bản sao '{copyId}'!");
            }

            // Nghiệp vụ: Không xóa bản "Đang mượn"
            if (copy.Status == CopyStatus.Borrowed)
            {
                throw new BusinessException($"Không thể xóa bản sao '{copyId}' vì đang ở trạng thái 'Đang mượn'!");
            }

            return await _bookCopyRepository.DeleteAsync(copyId);
        }

        private static BookCopyDto MapToDto(BookCopy c)
        {
            return new BookCopyDto
            {
                CopyId = c.CopyId,
                BookId = c.BookId,
                Status = c.Status,
                PhysicalCondition = c.PhysicalCondition
            };
        }
    }
}
