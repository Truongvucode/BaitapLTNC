using System.ComponentModel.DataAnnotations;

namespace LibraryApp.DAL.Enums
{
    /// <summary>
    /// Trạng thái của bản sao sách
    /// </summary>
    public enum CopyStatus
    {
        [Display(Name = "Sẵn sàng")]
        Available,

        [Display(Name = "Đang mượn")]
        Borrowed,

        [Display(Name = "Mất")]
        Lost,

        [Display(Name = "Bảo trì")]
        Maintenance
    }
}
