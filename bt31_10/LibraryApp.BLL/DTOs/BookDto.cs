namespace LibraryApp.BLL.DTOs
{
    public class BookDto
    {
        public string BookId { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string? Publisher { get; set; }
        public decimal Price { get; set; }
        public int? PublishYear { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public int CopyCount { get; set; }
    }
}
