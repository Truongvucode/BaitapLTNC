using System;
using System.Collections.Generic;
using QuanLySinhVienWF.Data.DAL;
using QuanLySinhVienWF.Data.Entity;

namespace QuanLySinhVienWF.Business
{
    /// <summary>
    /// Tầng Business cho SinhVien - Xử lý nghiệp vụ, gọi ValidationHelper trước khi thêm/sửa
    /// Ném ngoại lệ cho tầng View xử lý
    /// </summary>
    public class SinhVienBLL
    {
        private readonly SinhVienDAL _svDAL = new SinhVienDAL();
        private readonly LopHocDAL _lopDAL = new LopHocDAL();

        /// <summary>
        /// Lấy toàn bộ danh sách sinh viên
        /// Ném Exception nếu có lỗi truy vấn CSDL
        /// </summary>
        public List<SinhVien> GetAll()
        {
            try
            {
                return _svDAL.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi nghiệp vụ - Lấy danh sách sinh viên: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Tìm sinh viên theo mã
        /// Ném Exception nếu có lỗi truy vấn CSDL
        /// </summary>
        public SinhVien? GetById(string maSV)
        {
            try
            {
                return _svDAL.GetById(maSV);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi nghiệp vụ - Tìm sinh viên: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Kiểm tra mã sinh viên đã tồn tại chưa
        /// Ném Exception nếu có lỗi truy vấn CSDL
        /// </summary>
        public bool Exists(string maSV)
        {
            try
            {
                return _svDAL.Exists(maSV);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi nghiệp vụ - Kiểm tra sinh viên: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Lấy danh sách sinh viên theo mã lớp
        /// Ném Exception nếu có lỗi truy vấn CSDL
        /// </summary>
        public List<SinhVien> GetByMaLop(string maLop)
        {
            try
            {
                return _svDAL.GetByMaLop(maLop);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi nghiệp vụ - Lấy sinh viên theo lớp: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Tìm kiếm sinh viên theo từ khóa, mã lớp và điểm tối thiểu
        /// Ném Exception nếu có lỗi truy vấn CSDL
        /// </summary>
        public List<SinhVien> Search(string? keyword, string? maLop, double? diemTu)
        {
            try
            {
                return _svDAL.Search(keyword, maLop, diemTu);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi nghiệp vụ - Tìm kiếm sinh viên: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Thêm sinh viên mới - gọi ValidationHelper kiểm tra Data Annotations trước
        /// Ném Exception nếu có lỗi truy vấn CSDL
        /// </summary>
        public (bool Success, string Message) Add(SinhVien sv)
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception($"Lỗi nghiệp vụ - Thêm sinh viên: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Sửa thông tin sinh viên - gọi ValidationHelper kiểm tra trước
        /// Ném Exception nếu có lỗi truy vấn CSDL
        /// </summary>
        public (bool Success, string Message) Update(SinhVien sv)
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception($"Lỗi nghiệp vụ - Cập nhật sinh viên: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Xóa sinh viên
        /// Ném Exception nếu có lỗi truy vấn CSDL
        /// </summary>
        public (bool Success, string Message) Delete(string maSV)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(maSV))
                    return (false, "Mã sinh viên không được để trống!");

                if (!_svDAL.Exists(maSV))
                    return (false, $"Không tìm thấy sinh viên '{maSV}'!");

                return _svDAL.Delete(maSV)
                    ? (true, "Xóa sinh viên thành công!")
                    : (false, "Xóa sinh viên thất bại!");
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi nghiệp vụ - Xóa sinh viên: {ex.Message}", ex);
            }
        }
    }
}
