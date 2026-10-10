using System;
using System.Collections.Generic;
using System.Linq;
using QuanLySinhVienWF.Data.Entity;

namespace QuanLySinhVienWF.Data.DAL
{
    /// <summary>
    /// Tầng DataAccess cho SinhVien - Thao tác CRUD với nguồn dữ liệu In-memory
    /// </summary>
    public class SinhVienDAL
    {
        private static readonly List<SinhVien> _danhSachSV = new List<SinhVien>();
        private static bool _isSeeded = false;

        public SinhVienDAL()
        {
            if (!_isSeeded)
            {
                SeedData();
                _isSeeded = true;
            }
        }

        private void SeedData()
        {
            _danhSachSV.AddRange(new[]
            {
                new SinhVien("SV00001", "Nguyễn Văn An",    new DateTime(2003, 5, 15), true,
                             "an.nv@st.vju.ac.vn",    "0912345671", 8.5, "CNTT01", "Đang học"),
                new SinhVien("SV00002", "Trần Thị Bích",    new DateTime(2003, 8, 20), false,
                             "bich.tt@st.vju.ac.vn",  "0912345672", 9.0, "CNTT01", "Đang học"),
                new SinhVien("SV00003", "Lê Hoàng Cường",   new DateTime(2003, 1, 10), true,
                             "cuong.lh@st.vju.ac.vn", "0912345673", 7.2, "CNTT02", "Đang học"),
                new SinhVien("SV00004", "Phạm Thị Dung",    new DateTime(2004, 11, 25), false,
                             "dung.pt@st.vju.ac.vn",  "0912345674", 8.0, "KTPM01", "Đang học"),
                new SinhVien("SV00005", "Hoàng Đức Em",     new DateTime(2004, 3, 30), true,
                             "em.hd@st.vju.ac.vn",    "0912345675", 6.8, "KTPM01", "Tạm dừng"),
                new SinhVien("SV00006", "Vũ Thùy Linh",     new DateTime(2003, 7, 12), false,
                             "linh.vt@st.vju.ac.vn",  "0912345676", 9.5, "HTTT01", "Đang học"),
                new SinhVien("SV00007", "Đặng Minh Quang",  new DateTime(2003, 12, 5), true,
                             "quang.dm@st.vju.ac.vn", "0912345677", 4.9, "HTTT01", "Tạm dừng"),
                new SinhVien("SV00008", "Bùi Phương Thảo",  new DateTime(2004, 4, 18), false,
                             "thao.bp@st.vju.ac.vn",  "0912345678", 8.8, "KHMT01", "Đã tốt nghiệp")
            });
        }

        /// <summary>
        /// Lấy toàn bộ danh sách sinh viên
        /// </summary>
        public List<SinhVien> GetAll()
        {
            return _danhSachSV.ToList();
        }

        /// <summary>
        /// Tìm sinh viên theo mã sinh viên
        /// </summary>
        public SinhVien? GetById(string maSV)
        {
            if (string.IsNullOrWhiteSpace(maSV)) return null;
            return _danhSachSV.FirstOrDefault(
                s => string.Equals(s.MaSV, maSV.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Lấy danh sách sinh viên theo mã lớp
        /// </summary>
        public List<SinhVien> GetByMaLop(string maLop)
        {
            if (string.IsNullOrWhiteSpace(maLop)) return new List<SinhVien>();
            return _danhSachSV
                .Where(s => string.Equals(s.MaLop, maLop.Trim(), StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        /// <summary>
        /// Tìm kiếm sinh viên theo từ khóa, mã lớp và điểm tối thiểu
        /// </summary>
        public List<SinhVien> Search(string? keyword, string? maLop, double? diemTu)
        {
            IEnumerable<SinhVien> query = _danhSachSV;

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                string kw = keyword.Trim().ToLower();
                query = query.Where(s =>
                    s.MaSV.ToLower().Contains(kw) ||
                    s.HoTen.ToLower().Contains(kw) ||
                    s.Email.ToLower().Contains(kw) ||
                    s.DienThoai.Contains(kw));
            }

            if (!string.IsNullOrWhiteSpace(maLop))
            {
                query = query.Where(s =>
                    string.Equals(s.MaLop, maLop.Trim(), StringComparison.OrdinalIgnoreCase));
            }

            if (diemTu.HasValue)
            {
                query = query.Where(s => s.Diem >= diemTu.Value);
            }

            return query.ToList();
        }

        /// <summary>
        /// Kiểm tra mã sinh viên đã tồn tại chưa
        /// </summary>
        public bool Exists(string maSV)
        {
            if (string.IsNullOrWhiteSpace(maSV)) return false;
            return _danhSachSV.Any(
                s => string.Equals(s.MaSV, maSV.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        public bool Insert(SinhVien sv)
        {
            if (sv == null || Exists(sv.MaSV)) return false;
            _danhSachSV.Add(sv);
            return true;
        }

        public bool Update(SinhVien sv)
        {
            if (sv == null) return false;
            var existing = GetById(sv.MaSV);
            if (existing == null) return false;

            existing.HoTen = sv.HoTen;
            existing.NgaySinh = sv.NgaySinh;
            existing.GioiTinh = sv.GioiTinh;
            existing.Email = sv.Email;
            existing.DienThoai = sv.DienThoai;
            existing.Diem = sv.Diem;
            existing.MaLop = sv.MaLop;
            existing.TrangThai = sv.TrangThai;

            return true;
        }

        public bool Delete(string maSV)
        {
            var existing = GetById(maSV);
            if (existing == null) return false;
            _danhSachSV.Remove(existing);
            return true;
        }
    }
}
