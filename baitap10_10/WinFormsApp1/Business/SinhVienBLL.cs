using System;
using System.Collections.Generic;
using QuanLySinhVienWF.Data.DAL;
using QuanLySinhVienWF.Data.Entity;

namespace QuanLySinhVienWF.Business
{
    /// <summary>
    /// Tầng Business cho SinhVien - Xử lý nghiệp vụ, gọi ValidationHelper trước khi thêm/sửa
    /// </summary>
    public class SinhVienBLL
    {
        private readonly SinhVienDAL _svDAL = new SinhVienDAL();
        private readonly LopHocDAL _lopDAL = new LopHocDAL();

        public List<SinhVien> GetAll()
        {
            return _svDAL.GetAll();
        }

        public SinhVien? GetById(string maSV)
        {
            return _svDAL.GetById(maSV);
        }

        public bool Exists(string maSV)
        {
            return _svDAL.Exists(maSV);
        }

        public List<SinhVien> GetByMaLop(string maLop)
        {
            return _svDAL.GetByMaLop(maLop);
        }

        public List<SinhVien> Search(string? keyword, string? maLop, double? diemTu)
        {
            return _svDAL.Search(keyword, maLop, diemTu);
        }

        /// <summary>
        /// Thêm sinh viên mới - gọi ValidationHelper kiểm tra Data Annotations trước
        /// </summary>
        public (bool Success, string Message) Add(SinhVien sv)
        {
            // 1. Kiểm tra validation bằng Data Annotations thông qua ValidationHelper
            var (isValid, errors) = ValidationHelper.ValidateObject(sv);
            if (!isValid)
                return (false, string.Join("\n", errors));

            // 2. Kiểm tra trùng mã
            if (_svDAL.Exists(sv.MaSV))
                return (false, $"Mã sinh viên '{sv.MaSV}' đã tồn tại!");

            // 3. Kiểm tra lớp học có tồn tại không
            if (!_lopDAL.Exists(sv.MaLop))
                return (false, $"Mã lớp '{sv.MaLop}' không tồn tại!");

            return _svDAL.Insert(sv)
                ? (true, "Thêm sinh viên thành công!")
                : (false, "Thêm sinh viên thất bại!");
        }

        /// <summary>
        /// Sửa thông tin sinh viên - gọi ValidationHelper kiểm tra trước
        /// </summary>
        public (bool Success, string Message) Update(SinhVien sv)
        {
            var (isValid, errors) = ValidationHelper.ValidateObject(sv);
            if (!isValid)
                return (false, string.Join("\n", errors));

            if (!_svDAL.Exists(sv.MaSV))
                return (false, $"Không tìm thấy sinh viên '{sv.MaSV}'!");

            if (!_lopDAL.Exists(sv.MaLop))
                return (false, $"Mã lớp '{sv.MaLop}' không tồn tại!");

            return _svDAL.Update(sv)
                ? (true, "Cập nhật sinh viên thành công!")
                : (false, "Cập nhật sinh viên thất bại!");
        }

        /// <summary>
        /// Xóa sinh viên
        /// </summary>
        public (bool Success, string Message) Delete(string maSV)
        {
            if (string.IsNullOrWhiteSpace(maSV))
                return (false, "Mã sinh viên không được để trống!");

            if (!_svDAL.Exists(maSV))
                return (false, $"Không tìm thấy sinh viên '{maSV}'!");

            return _svDAL.Delete(maSV)
                ? (true, "Xóa sinh viên thành công!")
                : (false, "Xóa sinh viên thất bại!");
        }
    }
}
