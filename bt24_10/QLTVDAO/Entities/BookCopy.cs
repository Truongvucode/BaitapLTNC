namespace QLTVDAO.Entities
{
    /// <summary>
    /// Thực thể Bản sao sách (Cuốn sách cụ thể trong thư viện)
    /// </summary>
    public class BookCopy
    {
        public int BookCopyId { get; set; }

        /// <summary>
        /// Khóa ngoại liên kết tới Book
        /// </summary>
        public int BookId { get; set; }

        /// <summary>
        /// Navigation property: Bản sao thuộc về 1 đầu sách cụ thể
        /// </summary>
        public Book? Book { get; set; }

        /// <summary>
        /// Mã định danh của bản sao (Barcode/Mã cá biệt)
        /// </summary>
        public string CopyCode { get; set; } = string.Empty;

        /// <summary>
        /// Trạng thái bản sao (Available, Borrowed, Damaged, Lost...)
        /// </summary>
        public string Status { get; set; } = "Available";
    }
}
