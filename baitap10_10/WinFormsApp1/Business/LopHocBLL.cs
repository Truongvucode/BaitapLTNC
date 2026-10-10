using System;
using System.Collections.Generic;
using QuanLySinhVienWF.Data.DAL;
using QuanLySinhVienWF.Data.Entity;

namespace QuanLySinhVienWF.Business
{
    /// <summary>
    /// Tầng Business cho LopHoc - Xử lý nghiệp vụ, gọi ValidationHelper trước khi thêm/sửa
    /// </summary>
    public class LopHocBLL
    {
        private readonly LopHocDAL _dal = new LopHocDAL();

        public List<LopHoc> GetAll()
        {
            return _dal.GetAll();
        }

        public LopHoc? GetById(string maLop)
        {
            return _dal.GetById(maLop);
        }

        public bool Exists(string maLop)
        {
            return _dal.Exists(maLop);
        }

        public (bool Success, string Message) Add(LopHoc lop)
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

        public (bool Success, string Message) Update(LopHoc lop)
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

        public (bool Success, string Message) Delete(string maLop)
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
    }
}
