using System;
using System.ComponentModel.DataAnnotations;

namespace QuanLySinhVienWF.Data.Entity
{
    public class SinhVien
    {
        [Required(ErrorMessage = "Mã sinh viên không được để trống")]
        [RegularExpression(@"^SV\d{5}$", ErrorMessage = "Mã sinh viên phải có định dạng SVxxxxx")]
        public string MaSV { get; set; } = string.Empty;

        [Required(ErrorMessage = "Họ tên không được để trống")]
        public string HoTen { get; set; } = string.Empty;

        public DateTime NgaySinh { get; set; } = new DateTime(2003, 1, 1);

        /// <summary>
        /// true = Nam, false = Nữ
        /// </summary>
        public bool GioiTinh { get; set; } = true;

        /// <summary>
        /// Thuộc tính hiển thị giới tính dạng chuỗi (Nam/Nữ)
        /// </summary>
        public string GioiTinhHienThi => GioiTinh ? "Nam" : "Nữ";

        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        public string DienThoai { get; set; } = string.Empty;

        [Range(0.0, 10.0, ErrorMessage = "Điểm phải nằm trong khoảng từ 0.0 đến 10.0")]
        public double Diem { get; set; } = 0.0;

        [Required(ErrorMessage = "Vui lòng chọn lớp học")]
        public string MaLop { get; set; } = string.Empty;

        public string TrangThai { get; set; } = "Đang học";

        /// <summary>
        /// Navigation property: Sinh viên thuộc về 1 lớp học
        /// </summary>
        public LopHoc? LopHoc { get; set; }

        public SinhVien() { }

        public SinhVien(string maSV, string hoTen, DateTime ngaySinh, bool gioiTinh,
                        string email, string dienThoai, double diem, string maLop, string trangThai)
        {
            MaSV = maSV;
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;
            Email = email;
            DienThoai = dienThoai;
            Diem = diem;
            MaLop = maLop;
            TrangThai = trangThai;
        }

        public override string ToString()
        {
            return $"{MaSV} - {HoTen}";
        }
    }
}
