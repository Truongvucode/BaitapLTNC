namespace LibraryApp.BLL.DTOs
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int BookCount { get; set; }

        public override string ToString()
        {
            return CategoryName;
        }
    }
}
