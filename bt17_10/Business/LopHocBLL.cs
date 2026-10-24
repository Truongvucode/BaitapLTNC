using System;
using System.Collections.Generic;
using QuanLySinhVienWF.Data.DAL;
using QuanLySinhVienWF.Data.Entity;

namespace QuanLySinhVienWF.Business
{
    /// <summary>
    /// Tầng Business cho LopHoc - Xử lý nghiệp vụ, gọi ValidationHelper trước khi thêm/sửa
    /// Ném ngoại lệ cho tầng View xử lý
    /// </summary>
    public class LopHocBLL
    {
        private readonly LopHocDAL _dal = new LopHocDAL();

        /// <summary>
        /// Lấy toàn bộ danh sách lớp học
        /// Ném Exception nếu có lỗi truy vấn CSDL
        /// </summary>
        public List<LopHoc> GetAll()
        {
            try
            {
                return _dal.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi nghiệp vụ - Lấy danh sách lớp học: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Tìm lớp học theo mã lớp
        /// Ném Exception nếu có lỗi truy vấn CSDL
        /// </summary>
        public LopHoc? GetById(string maLop)
        {
            try
            {
                return _dal.GetById(maLop);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi nghiệp vụ - Tìm lớp học: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Kiểm tra mã lớp đã tồn tại chưa
        /// Ném Exception nếu có lỗi truy vấn CSDL
        /// </summary>
        public bool Exists(string maLop)
        {
            try
            {
                return _dal.Exists(maLop);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi nghiệp vụ - Kiểm tra lớp học: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Thêm lớp học mới - kiểm tra validation và trùng mã trước khi thêm
        /// Ném Exception nếu có lỗi truy vấn CSDL
        /// </summary>
        public (bool Success, string Message) Add(LopHoc lop)
        {
            try
            {
                // Kiểm tra validation bằng Data Annotations
                var (isValid, errors) = ValidationHelper.ValidateObject(lop);
                if (!isValid)
                    return (false, string.Join("\n", errors));

                if (_dal.Exists(lop.MaLop))
                    return (false, $"Mã lớp '{lop.MaLop}' đã tồn tại!");

                return _dal.Insert(lop)
                    ? (true, "Thêm lớp học thành công!")
                    : (false, "Thêm lớp học thất bại!");
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi nghiệp vụ - Thêm lớp học: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Cập nhật thông tin lớp học - kiểm tra validation trước khi cập nhật
        /// Ném Exception nếu có lỗi truy vấn CSDL
        /// </summary>
        public (bool Success, string Message) Update(LopHoc lop)
        {
            try
            {
                var (isValid, errors) = ValidationHelper.ValidateObject(lop);
                if (!isValid)
                    return (false, string.Join("\n", errors));

                if (!_dal.Exists(lop.MaLop))
                    return (false, $"Không tìm thấy lớp '{lop.MaLop}'!");

                return _dal.Update(lop)
                    ? (true, "Cập nhật lớp học thành công!")
                    : (false, "Cập nhật lớp học thất bại!");
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi nghiệp vụ - Cập nhật lớp học: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Xóa lớp học - kiểm tra ràng buộc sinh viên trước khi xóa
        /// Ném Exception nếu có lỗi truy vấn CSDL
        /// </summary>
        public (bool Success, string Message) Delete(string maLop)
        {
            try
            {
                if (!_dal.Exists(maLop))
                    return (false, $"Không tìm thấy lớp '{maLop}'!");

                // Kiểm tra ràng buộc: nếu lớp có sinh viên thì không cho xóa
                var svDAL = new SinhVienDAL();
                var svTrongLop = svDAL.GetByMaLop(maLop);
                if (svTrongLop.Count > 0)
                    return (false, $"Không thể xóa lớp '{maLop}' vì đang có {svTrongLop.Count} sinh viên!");

                return _dal.Delete(maLop)
                    ? (true, "Xóa lớp học thành công!")
                    : (false, "Xóa lớp học thất bại!");
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi nghiệp vụ - Xóa lớp học: {ex.Message}", ex);
            }
        }
    }
}
