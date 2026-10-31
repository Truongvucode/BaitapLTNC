using System.ComponentModel.DataAnnotations;

namespace LibraryApp.DAL.Enums
{
    /// <summary>
    /// Tình trạng vật lý của bản sao sách
    /// </summary>
    public enum PhysicalCondition
    {
        [Display(Name = "Mới")]
        New,

        [Display(Name = "Tốt")]
        Good,

        [Display(Name = "Cũ")]
        Worn,

        [Display(Name = "Hỏng")]
        Damaged
    }
}
