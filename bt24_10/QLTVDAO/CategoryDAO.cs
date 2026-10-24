using Microsoft.EntityFrameworkCore;
using QLTVDAO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QLTVDAO
{
    /// <summary>
    /// Lớp DAO hỗ trợ thao tác CRUD với thực thể Category bằng EF Core
    /// </summary>
    public class CategoryDAO
    {
        /// <summary>
        /// Đảm bảo database và các bảng đã được tạo trong MySQL
        /// </summary>
        public static bool EnsureDatabaseCreated()
        {
            try
            {
                using var context = new QLTVDBContext();
                return context.Database.EnsureCreated();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi khởi tạo database: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Kiểm tra kết nối tới MySQL Database
        /// </summary>
        public static bool CanConnect()
        {
            try
            {
                using var context = new QLTVDBContext();
                return context.Database.CanConnect();
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Lấy tất cả các thể loại sách (kèm danh sách sách nếu cần)
        /// </summary>
        public static List<Category> GetAll(bool includeBooks = false)
        {
            using var context = new QLTVDBContext();
            if (includeBooks)
            {
                return context.Categories.Include(c => c.Books).ToList();
            }
            return context.Categories.ToList();
        }

        /// <summary>
        /// Lấy thể loại theo CategoryId
        /// </summary>
        public static Category? GetById(int categoryId)
        {
            using var context = new QLTVDBContext();
            return context.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
        }

        /// <summary>
        /// Thêm mới một thể loại
        /// </summary>
        public static bool Add(Category category)
        {
            try
            {
                using var context = new QLTVDBContext();
                context.Categories.Add(category);
                return context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi thêm thể loại: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Cập nhật thông tin thể loại
        /// </summary>
        public static bool Update(Category category)
        {
            try
            {
                using var context = new QLTVDBContext();
                var existing = context.Categories.Find(category.CategoryId);
                if (existing == null) return false;

                existing.CategoryName = category.CategoryName;
                existing.Description = category.Description;

                return context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi cập nhật thể loại: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Xóa một thể loại theo CategoryId
        /// </summary>
        public static bool Delete(int categoryId)
        {
            try
            {
                using var context = new QLTVDBContext();
                var existing = context.Categories.Find(categoryId);
                if (existing == null) return false;

                context.Categories.Remove(existing);
                return context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi xóa thể loại: {ex.Message}", ex);
            }
        }
    }
}
