using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LibraryApp.DAL.Enums;

namespace LibraryApp.DAL.Entities
{
    /// <summary>
    /// Thực thể Bản sao sách
    /// </summary>
    [Table("BookCopies")]
    public class BookCopy
    {
        [Key]
        [MaxLength(30)]
        public string CopyId { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string BookId { get; set; } = string.Empty;

        [ForeignKey(nameof(BookId))]
        public virtual Book Book { get; set; } = null!;

        [Required]
        public CopyStatus Status { get; set; } = CopyStatus.Available;

        [Required]
        public PhysicalCondition PhysicalCondition { get; set; } = PhysicalCondition.Good;
    }
}
