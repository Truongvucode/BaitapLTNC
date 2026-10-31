using Microsoft.EntityFrameworkCore;
using LibraryApp.DAL.Data;
using LibraryApp.DAL.Entities;

namespace LibraryApp.DAL.Repositories
{
    public class BookCopyRepository : IBookCopyRepository
    {
        private readonly LibraryDbContext _context;

        public BookCopyRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BookCopy>> GetByBookIdAsync(string bookId)
        {
            return await _context.BookCopies
                .Where(bc => bc.BookId == bookId)
                .AsNoTracking()
                .OrderBy(bc => bc.CopyId)
                .ToListAsync();
        }

        public async Task<BookCopy?> GetByIdAsync(string copyId)
        {
            return await _context.BookCopies.FindAsync(copyId);
        }

        public async Task<BookCopy> AddAsync(BookCopy copy)
        {
            await _context.BookCopies.AddAsync(copy);
            await _context.SaveChangesAsync();
            return copy;
        }

        public async Task<bool> AddRangeAsync(IEnumerable<BookCopy> copies)
        {
            await _context.BookCopies.AddRangeAsync(copies);
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<bool> UpdateAsync(BookCopy copy)
        {
            // Kiểm tra entity có đang được track không
            var entry = _context.Entry(copy);
            if (entry.State == Microsoft.EntityFrameworkCore.EntityState.Detached)
            {
                _context.BookCopies.Update(copy);
            }
            // Nếu đã tracked thì SaveChanges sẽ tự detect changes

            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<bool> DeleteAsync(string copyId)
        {
            var copy = await _context.BookCopies.FindAsync(copyId);
            if (copy == null) return false;

            _context.BookCopies.Remove(copy);
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<int> GetNextSequenceAsync(string bookId)
        {
            // Lấy tất cả CopyId hiện có của sách
            var copyIds = await _context.BookCopies
                .Where(bc => bc.BookId == bookId)
                .Select(bc => bc.CopyId)
                .ToListAsync();

            if (!copyIds.Any()) return 1;

            int maxSeq = 0;
            string prefix = $"{bookId}.";
            foreach (var cid in copyIds)
            {
                if (cid.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                {
                    string seqPart = cid.Substring(prefix.Length);
                    if (int.TryParse(seqPart, out int seq) && seq > maxSeq)
                    {
                        maxSeq = seq;
                    }
                }
            }

            return maxSeq + 1;
        }
    }
}
