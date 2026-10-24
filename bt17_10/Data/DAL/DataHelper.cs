using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace QuanLySinhVienWF.Data.DAL
{
    /// <summary>
    /// Lớp hỗ trợ thao tác với cơ sở dữ liệu SQL Server bằng ADO.NET
    /// Sử dụng parameterized queries để chống SQL Injection
    /// </summary>
    public class DataHelper
    {
        private readonly string _connectionString;

        public DataHelper()
        {
            _connectionString = @"Server=LAPTOP-6SN65NCS\HUECTMDB; Database=QLSV; Integrated Security=True; TrustServerCertificate=true";
        }

        /// <summary>
        /// Tạo và trả về một SqlConnection mới
        /// </summary>
        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        /// <summary>
        /// Thực thi câu lệnh SQL không trả về kết quả (INSERT, UPDATE, DELETE)
        /// Ném ngoại lệ nếu có lỗi
        /// </summary>
        /// <param name="sql">Câu lệnh SQL có tham số</param>
        /// <param name="parameters">Mảng các SqlParameter</param>
        /// <returns>Số dòng bị ảnh hưởng</returns>
        public int ExecuteNonQuery(string sql, SqlParameter[]? parameters = null)
        {
            try
            {
                using (SqlConnection con = GetConnection())
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        if (parameters != null)
                            cmd.Parameters.AddRange(parameters);

                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception($"Lỗi truy vấn CSDL: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi kết nối CSDL: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Thực thi câu lệnh SQL trả về một giá trị đơn (VD: COUNT, EXISTS)
        /// Ném ngoại lệ nếu có lỗi
        /// </summary>
        public object? ExecuteScalar(string sql, SqlParameter[]? parameters = null)
        {
            try
            {
                using (SqlConnection con = GetConnection())
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        if (parameters != null)
                            cmd.Parameters.AddRange(parameters);

                        return cmd.ExecuteScalar();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception($"Lỗi truy vấn CSDL: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi kết nối CSDL: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Thực thi câu lệnh SELECT và trả về DataTable
        /// Ném ngoại lệ nếu có lỗi
        /// </summary>
        public DataTable GetDataTable(string sql, SqlParameter[]? parameters = null)
        {
            try
            {
                using (SqlConnection con = GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        if (parameters != null)
                            cmd.Parameters.AddRange(parameters);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception($"Lỗi truy vấn CSDL: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi kết nối CSDL: {ex.Message}", ex);
            }
        }
    }
}
