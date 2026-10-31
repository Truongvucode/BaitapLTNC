using LibraryApp.DAL.Enums;

namespace LibraryApp.BLL.DTOs
{
    public class BookCopyDto
    {
        public string CopyId { get; set; } = string.Empty;
        public string BookId { get; set; } = string.Empty;
        public CopyStatus Status { get; set; }
        public string StatusDisplay => Status.ToVietnamese();
        public PhysicalCondition PhysicalCondition { get; set; }
        public string PhysicalConditionDisplay => PhysicalCondition.ToVietnamese();
    }
}
