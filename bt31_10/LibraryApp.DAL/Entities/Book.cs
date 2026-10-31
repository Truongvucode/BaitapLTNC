using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.DAL.Entities
{
    /// <summary>
    /// Thực thể Đầu sách
    /// </summary>
    [Table("Books")]
    public class Book
    {
        [Key]
        [MaxLength(20)]
        public string BookId { get; set; } = string.Empty;

        [Required(ErrorMessage = "Tên đầu sách không được để trống")]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Tác giả không được để trống")]
        [MaxLength(150)]
        public string Author { get; set; } = string.Empty;

        [MaxLength(150)]
        public string? Publisher { get; set; }

        [Column(TypeName = "decimal(18,0)")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá sách phải lớn hơn hoặc bằng 0")]
        public decimal Price { get; set; }

        public int? PublishYear { get; set; }

        [Required]
        public int CategoryId { get; set; }

        // Navigation properties
        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; } = null!;

        public virtual ICollection<BookCopy> Copies { get; set; } = new List<BookCopy>();

        [NotMapped]
        public int CopyCount => Copies?.Count ?? 0;
    }
}
