namespace QLTVDAO.Entities
{
    /// <summary>
    /// Thực thể Đầu sách
    /// </summary>
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Author { get; set; }
        public string? ISBN { get; set; }

        /// <summary>
        /// Khóa ngoại liên kết tới Category
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Navigation property: Một cuốn sách thuộc về 1 Thể loại
        /// </summary>
        public Category? Category { get; set; }

        /// <summary>
        /// Navigation property: Một cuốn sách có nhiều bản sao BookCopy (Quan hệ 1 - N)
        /// </summary>
        public ICollection<BookCopy> BookCopies { get; set; } = new List<BookCopy>();
    }
}
