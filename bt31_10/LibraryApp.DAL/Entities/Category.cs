using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.DAL.Entities
{
    /// <summary>
    /// Thực thể Thể loại sách
    /// </summary>
    [Table("Categories")]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Tên thể loại không được để trống")]
        [MaxLength(100)]
        public string CategoryName { get; set; } = string.Empty;

        [MaxLength(255)]
        public string? Description { get; set; }

        // Navigation property: Danh sách đầu sách thuộc thể loại này
        public virtual ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
