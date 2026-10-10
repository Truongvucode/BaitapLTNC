using System;
using System.Collections.Generic;
using System.Linq;
using QuanLySinhVienWF.Data.Entity;

namespace QuanLySinhVienWF.Data.DAL
{
    /// <summary>
    /// Tầng DataAccess cho LopHoc - Thao tác CRUD với nguồn dữ liệu In-memory
    /// </summary>
    public class LopHocDAL
    {
        private static readonly List<LopHoc> _danhSachLop = new List<LopHoc>();
        private static bool _isSeeded = false;

        public LopHocDAL()
        {
            if (!_isSeeded)
            {
                SeedData();
                _isSeeded = true;
            }
        }

        private void SeedData()
        {
            _danhSachLop.AddRange(new[]
            {
                new LopHoc("CNTT01", "Công nghệ thông tin 01"),
                new LopHoc("CNTT02", "Công nghệ thông tin 02"),
                new LopHoc("KTPM01", "Kỹ thuật phần mềm 01"),
                new LopHoc("HTTT01", "Hệ thống thông tin 01"),
                new LopHoc("KHMT01", "Khoa học máy tính 01")
            });
        }

        /// <summary>
        /// Lấy toàn bộ danh sách lớp học
        /// </summary>
        public List<LopHoc> GetAll()
        {
            return _danhSachLop.ToList();
        }

        /// <summary>
        /// Tìm lớp học theo mã lớp
        /// </summary>
        public LopHoc? GetById(string maLop)
        {
            if (string.IsNullOrWhiteSpace(maLop)) return null;
            return _danhSachLop.FirstOrDefault(
                l => string.Equals(l.MaLop, maLop.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Kiểm tra mã lớp đã tồn tại chưa
        /// </summary>
        public bool Exists(string maLop)
        {
            if (string.IsNullOrWhiteSpace(maLop)) return false;
            return _danhSachLop.Any(
                l => string.Equals(l.MaLop, maLop.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        public bool Insert(LopHoc lop)
        {
            if (lop == null || Exists(lop.MaLop)) return false;
            _danhSachLop.Add(lop);
            return true;
        }

        public bool Update(LopHoc lop)
        {
            if (lop == null) return false;
            var existing = GetById(lop.MaLop);
            if (existing == null) return false;
            existing.TenLop = lop.TenLop;
            return true;
        }

        public bool Delete(string maLop)
        {
            var existing = GetById(maLop);
            if (existing == null) return false;
            _danhSachLop.Remove(existing);
            return true;
        }
    }
}
