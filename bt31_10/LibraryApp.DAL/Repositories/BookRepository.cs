using Microsoft.EntityFrameworkCore;
using LibraryApp.DAL.Data;
using LibraryApp.DAL.Entities;

namespace LibraryApp.DAL.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _context;

        public BookRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Books
                .Include(b => b.Category)
                .Include(b => b.Copies)
                .AsNoTracking()
                .OrderBy(b => b.BookId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Book>> SearchAsync(string? keyword, int? categoryId)
        {
            var query = _context.Books
                .Include(b => b.Category)
                .Include(b => b.Copies)
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                string kw = keyword.Trim().ToLower();
                query = query.Where(b => b.BookId.ToLower().Contains(kw) ||
                                         b.Title.ToLower().Contains(kw) ||
                                         b.Author.ToLower().Contains(kw));
            }

            if (categoryId.HasValue && categoryId.Value > 0)
            {
                query = query.Where(b => b.CategoryId == categoryId.Value);
            }

            return await query.OrderBy(b => b.BookId).ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(string bookId)
        {
            return await _context.Books
                .Include(b => b.Category)
                .Include(b => b.Copies)
                .FirstOrDefaultAsync(b => b.BookId == bookId);
        }

        public async Task<Book> AddAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<bool> UpdateAsync(Book book)
        {
            // Kiểm tra entity có đang được track không
            var entry = _context.Entry(book);
            if (entry.State == Microsoft.EntityFrameworkCore.EntityState.Detached)
            {
                // Nếu entity bị detach, attach lại và đánh dấu đã thay đổi
                _context.Books.Update(book);
            }
            // Nếu đã tracked (Modified) thì chỉ cần SaveChanges

            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<bool> DeleteAsync(string bookId)
        {
            var book = await _context.Books
                .Include(b => b.Copies)
                .FirstOrDefaultAsync(b => b.BookId == bookId);

            if (book == null) return false;

            _context.Books.Remove(book);
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<bool> ExistsAsync(string bookId)
        {
            return await _context.Books.AnyAsync(b => b.BookId.ToLower() == bookId.Trim().ToLower());
        }
    }
}
