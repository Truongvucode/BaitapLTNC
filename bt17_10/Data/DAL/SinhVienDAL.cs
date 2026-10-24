using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using QuanLySinhVienWF.Data.Entity;

namespace QuanLySinhVienWF.Data.DAL
{
    /// <summary>
    /// Tầng DataAccess cho SinhVien - Thao tác CRUD với cơ sở dữ liệu SQL Server bằng ADO.NET
    /// Tất cả phương thức đều ném ngoại lệ (Exception) khi có lỗi CSDL
    /// </summary>
    public class SinhVienDAL
    {
        private readonly DataHelper _db = new DataHelper();

        /// <summary>
        /// Lấy toàn bộ danh sách sinh viên từ CSDL
        /// Ném Exception nếu có lỗi truy vấn
        /// </summary>
        public List<SinhVien> GetAll()
        {
            try
            {
                List<SinhVien> danhSach = new List<SinhVien>();
                string sql = @"SELECT MaSV, HoTen, NgaySinh, GioiTinh, Email, 
                               DienThoai, Diem, MaLop, TrangThai 
                               FROM SinhVien";
                DataTable dt = _db.GetDataTable(sql);

                foreach (DataRow row in dt.Rows)
                {
                    danhSach.Add(MapRowToSinhVien(row));
                }
                return danhSach;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách sinh viên: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Tìm sinh viên theo mã sinh viên
        /// Ném Exception nếu có lỗi truy vấn
        /// </summary>
        public SinhVien? GetById(string maSV)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(maSV)) return null;

                string sql = @"SELECT MaSV, HoTen, NgaySinh, GioiTinh, Email, 
                               DienThoai, Diem, MaLop, TrangThai 
                               FROM SinhVien WHERE MaSV = @MaSV";
                SqlParameter[] parameters = { new SqlParameter("@MaSV", maSV.Trim()) };

                DataTable dt = _db.GetDataTable(sql, parameters);

                if (dt.Rows.Count == 0) return null;
                return MapRowToSinhVien(dt.Rows[0]);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tìm sinh viên '{maSV}': {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Lấy danh sách sinh viên theo mã lớp
        /// Ném Exception nếu có lỗi truy vấn
        /// </summary>
        public List<SinhVien> GetByMaLop(string maLop)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(maLop)) return new List<SinhVien>();

                string sql = @"SELECT MaSV, HoTen, NgaySinh, GioiTinh, Email, 
                               DienThoai, Diem, MaLop, TrangThai 
                               FROM SinhVien WHERE MaLop = @MaLop";
                SqlParameter[] parameters = { new SqlParameter("@MaLop", maLop.Trim()) };

                DataTable dt = _db.GetDataTable(sql, parameters);
                List<SinhVien> danhSach = new List<SinhVien>();

                foreach (DataRow row in dt.Rows)
                {
                    danhSach.Add(MapRowToSinhVien(row));
                }
                return danhSach;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy sinh viên theo lớp '{maLop}': {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Tìm kiếm sinh viên theo từ khóa, mã lớp và điểm tối thiểu
        /// Ném Exception nếu có lỗi truy vấn
        /// </summary>
        public List<SinhVien> Search(string? keyword, string? maLop, double? diemTu)
        {
            try
            {
                string sql = @"SELECT MaSV, HoTen, NgaySinh, GioiTinh, Email, 
                               DienThoai, Diem, MaLop, TrangThai 
                               FROM SinhVien WHERE 1=1";

                List<SqlParameter> paramList = new List<SqlParameter>();

                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    sql += @" AND (MaSV LIKE @Keyword 
                              OR HoTen LIKE @Keyword 
                              OR Email LIKE @Keyword 
                              OR DienThoai LIKE @Keyword)";
                    paramList.Add(new SqlParameter("@Keyword", $"%{keyword.Trim()}%"));
                }

                if (!string.IsNullOrWhiteSpace(maLop))
                {
                    sql += " AND MaLop = @MaLop";
                    paramList.Add(new SqlParameter("@MaLop", maLop.Trim()));
                }

                if (diemTu.HasValue)
                {
                    sql += " AND Diem >= @DiemTu";
                    paramList.Add(new SqlParameter("@DiemTu", diemTu.Value));
                }

                DataTable dt = _db.GetDataTable(sql, paramList.ToArray());
                List<SinhVien> danhSach = new List<SinhVien>();

                foreach (DataRow row in dt.Rows)
                {
                    danhSach.Add(MapRowToSinhVien(row));
                }
                return danhSach;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tìm kiếm sinh viên: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Kiểm tra mã sinh viên đã tồn tại trong CSDL chưa
        /// Ném Exception nếu có lỗi truy vấn
        /// </summary>
        public bool Exists(string maSV)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(maSV)) return false;

                string sql = "SELECT COUNT(*) FROM SinhVien WHERE MaSV = @MaSV";
                SqlParameter[] parameters = { new SqlParameter("@MaSV", maSV.Trim()) };

                object? result = _db.ExecuteScalar(sql, parameters);
                return Convert.ToInt32(result) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi kiểm tra sinh viên '{maSV}': {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Thêm sinh viên mới vào CSDL
        /// Ném Exception nếu có lỗi truy vấn
        /// </summary>
        public bool Insert(SinhVien sv)
        {
            try
            {
                if (sv == null)
                    throw new ArgumentNullException(nameof(sv), "Đối tượng sinh viên không được null");

                string sql = @"INSERT INTO SinhVien 
                               (MaSV, HoTen, NgaySinh, GioiTinh, Email, DienThoai, Diem, MaLop, TrangThai) 
                               VALUES 
                               (@MaSV, @HoTen, @NgaySinh, @GioiTinh, @Email, @DienThoai, @Diem, @MaLop, @TrangThai)";

                SqlParameter[] parameters =
                {
                    new SqlParameter("@MaSV", sv.MaSV),
                    new SqlParameter("@HoTen", sv.HoTen),
                    new SqlParameter("@NgaySinh", sv.NgaySinh),
                    new SqlParameter("@GioiTinh", sv.GioiTinh),
                    new SqlParameter("@Email", sv.Email),
                    new SqlParameter("@DienThoai", sv.DienThoai),
                    new SqlParameter("@Diem", sv.Diem),
                    new SqlParameter("@MaLop", sv.MaLop),
                    new SqlParameter("@TrangThai", sv.TrangThai)
                };

                int rowsAffected = _db.ExecuteNonQuery(sql, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm sinh viên '{sv?.MaSV}': {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Cập nhật thông tin sinh viên trong CSDL
        /// Ném Exception nếu có lỗi truy vấn
        /// </summary>
        public bool Update(SinhVien sv)
        {
            try
            {
                if (sv == null)
                    throw new ArgumentNullException(nameof(sv), "Đối tượng sinh viên không được null");

                string sql = @"UPDATE SinhVien SET 
                               HoTen = @HoTen, 
                               NgaySinh = @NgaySinh, 
                               GioiTinh = @GioiTinh, 
                               Email = @Email, 
                               DienThoai = @DienThoai, 
                               Diem = @Diem, 
                               MaLop = @MaLop, 
                               TrangThai = @TrangThai 
                               WHERE MaSV = @MaSV";

                SqlParameter[] parameters =
                {
                    new SqlParameter("@HoTen", sv.HoTen),
                    new SqlParameter("@NgaySinh", sv.NgaySinh),
                    new SqlParameter("@GioiTinh", sv.GioiTinh),
                    new SqlParameter("@Email", sv.Email),
                    new SqlParameter("@DienThoai", sv.DienThoai),
                    new SqlParameter("@Diem", sv.Diem),
                    new SqlParameter("@MaLop", sv.MaLop),
                    new SqlParameter("@TrangThai", sv.TrangThai),
                    new SqlParameter("@MaSV", sv.MaSV)
                };

                int rowsAffected = _db.ExecuteNonQuery(sql, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật sinh viên '{sv?.MaSV}': {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Xóa sinh viên khỏi CSDL theo mã sinh viên
        /// Ném Exception nếu có lỗi truy vấn
        /// </summary>
        public bool Delete(string maSV)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(maSV))
                    throw new ArgumentException("Mã sinh viên không được để trống", nameof(maSV));

                string sql = "DELETE FROM SinhVien WHERE MaSV = @MaSV";
                SqlParameter[] parameters = { new SqlParameter("@MaSV", maSV.Trim()) };

                int rowsAffected = _db.ExecuteNonQuery(sql, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa sinh viên '{maSV}': {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Chuyển đổi DataRow thành đối tượng SinhVien
        /// </summary>
        private SinhVien MapRowToSinhVien(DataRow row)
        {
            return new SinhVien
            {
                MaSV = row["MaSV"].ToString() ?? string.Empty,
                HoTen = row["HoTen"].ToString() ?? string.Empty,
                NgaySinh = row["NgaySinh"] != DBNull.Value
                    ? Convert.ToDateTime(row["NgaySinh"])
                    : new DateTime(2003, 1, 1),
                GioiTinh = row["GioiTinh"] != DBNull.Value && Convert.ToBoolean(row["GioiTinh"]),
                Email = row["Email"].ToString() ?? string.Empty,
                DienThoai = row["DienThoai"].ToString() ?? string.Empty,
                Diem = row["Diem"] != DBNull.Value
                    ? Convert.ToDouble(row["Diem"])
                    : 0.0,
                MaLop = row["MaLop"].ToString() ?? string.Empty,
                TrangThai = row["TrangThai"].ToString() ?? "Đang học"
            };
        }
    }
}
