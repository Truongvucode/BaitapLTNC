using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuanLySinhVienWF.Data.Entity
{
    public class LopHoc
    {
        [Required(ErrorMessage = "Mã lớp không được để trống")]
        public string MaLop { get; set; } = string.Empty;

        [Required(ErrorMessage = "Tên lớp không được để trống")]
        public string TenLop { get; set; } = string.Empty;

        /// <summary>
        /// Navigation property: Một lớp học có nhiều sinh viên (quan hệ 1-n)
        /// </summary>
        public List<SinhVien> DanhSachSinhVien { get; set; } = new List<SinhVien>();

        public LopHoc() { }

        public LopHoc(string maLop, string tenLop)
        {
            MaLop = maLop;
            TenLop = tenLop;
        }

        public override string ToString()
        {
            return $"{MaLop} - {TenLop}";
        }
    }
}
