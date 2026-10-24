namespace QLTVDAO.Entities
{
    /// <summary>
    /// Thực thể Thể loại sách
    /// </summary>
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string? Description { get; set; }

        /// <summary>
        /// Navigation property: Một Category có nhiều Book (Quan hệ 1 - N)
        /// </summary>
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
