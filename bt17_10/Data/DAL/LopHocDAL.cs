using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using QuanLySinhVienWF.Data.Entity;

namespace QuanLySinhVienWF.Data.DAL
{
    /// <summary>
    /// Tầng DataAccess cho LopHoc - Thao tác CRUD với cơ sở dữ liệu SQL Server bằng ADO.NET
    /// Tất cả phương thức đều ném ngoại lệ (Exception) khi có lỗi CSDL
    /// </summary>
    public class LopHocDAL
    {
        private readonly DataHelper _db = new DataHelper();

        /// <summary>
        /// Lấy toàn bộ danh sách lớp học từ CSDL
        /// Ném Exception nếu có lỗi truy vấn
        /// </summary>
        public List<LopHoc> GetAll()
        {
            try
            {
                List<LopHoc> danhSach = new List<LopHoc>();
                DataTable dt = _db.GetDataTable("SELECT MaLop, TenLop FROM LopHoc");

                foreach (DataRow row in dt.Rows)
                {
                    LopHoc lop = new LopHoc
                    {
                        MaLop = row["MaLop"].ToString() ?? string.Empty,
                        TenLop = row["TenLop"].ToString() ?? string.Empty
                    };
                    danhSach.Add(lop);
                }
                return danhSach;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách lớp học: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Tìm lớp học theo mã lớp
        /// Ném Exception nếu có lỗi truy vấn
        /// </summary>
        public LopHoc? GetById(string maLop)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(maLop)) return null;

                string sql = "SELECT MaLop, TenLop FROM LopHoc WHERE MaLop = @MaLop";
                SqlParameter[] parameters = { new SqlParameter("@MaLop", maLop.Trim()) };

                DataTable dt = _db.GetDataTable(sql, parameters);

                if (dt.Rows.Count == 0) return null;

                DataRow row = dt.Rows[0];
                return new LopHoc
                {
                    MaLop = row["MaLop"].ToString() ?? string.Empty,
                    TenLop = row["TenLop"].ToString() ?? string.Empty
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tìm lớp học '{maLop}': {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Kiểm tra mã lớp đã tồn tại trong CSDL chưa
        /// Ném Exception nếu có lỗi truy vấn
        /// </summary>
        public bool Exists(string maLop)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(maLop)) return false;

                string sql = "SELECT COUNT(*) FROM LopHoc WHERE MaLop = @MaLop";
                SqlParameter[] parameters = { new SqlParameter("@MaLop", maLop.Trim()) };

                object? result = _db.ExecuteScalar(sql, parameters);
                return Convert.ToInt32(result) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi kiểm tra lớp học '{maLop}': {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Thêm lớp học mới vào CSDL
        /// Ném Exception nếu có lỗi truy vấn
        /// </summary>
        public bool Insert(LopHoc lop)
        {
            try
            {
                if (lop == null)
                    throw new ArgumentNullException(nameof(lop), "Đối tượng lớp học không được null");

                string sql = "INSERT INTO LopHoc (MaLop, TenLop) VALUES (@MaLop, @TenLop)";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@MaLop", lop.MaLop),
                    new SqlParameter("@TenLop", lop.TenLop)
                };

                int rowsAffected = _db.ExecuteNonQuery(sql, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm lớp học '{lop?.MaLop}': {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Cập nhật thông tin lớp học trong CSDL
        /// Ném Exception nếu có lỗi truy vấn
        /// </summary>
        public bool Update(LopHoc lop)
        {
            try
            {
                if (lop == null)
                    throw new ArgumentNullException(nameof(lop), "Đối tượng lớp học không được null");

                string sql = "UPDATE LopHoc SET TenLop = @TenLop WHERE MaLop = @MaLop";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@TenLop", lop.TenLop),
                    new SqlParameter("@MaLop", lop.MaLop)
                };

                int rowsAffected = _db.ExecuteNonQuery(sql, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật lớp học '{lop?.MaLop}': {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Xóa lớp học khỏi CSDL theo mã lớp
        /// Ném Exception nếu có lỗi truy vấn
        /// </summary>
        public bool Delete(string maLop)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(maLop))
                    throw new ArgumentException("Mã lớp không được để trống", nameof(maLop));

                string sql = "DELETE FROM LopHoc WHERE MaLop = @MaLop";
                SqlParameter[] parameters = { new SqlParameter("@MaLop", maLop.Trim()) };

                int rowsAffected = _db.ExecuteNonQuery(sql, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa lớp học '{maLop}': {ex.Message}", ex);
            }
        }
    }
}
