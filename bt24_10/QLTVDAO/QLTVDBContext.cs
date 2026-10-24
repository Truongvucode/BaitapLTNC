using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MySql.EntityFrameworkCore.Extensions;
using QLTVDAO.Entities;

namespace QLTVDAO
{
    /// <summary>
    /// DbContext quản lý cơ sở dữ liệu cho chức năng Quản lý thư viện sử dụng MySQL
    /// </summary>
    public class QLTVDBContext : DbContext
    {
        // Chuỗi kết nối MySQL mặc định
        public static string ConnectionString { get; set; } = "Server=localhost;Port=3306;Database=QLTV;Uid=root;Pwd=root;";

        public QLTVDBContext()
        {
        }

        public QLTVDBContext(DbContextOptions<QLTVDBContext> options) : base(options)
        {
        }

        // 3 DbSet theo yêu cầu
        public DbSet<Book> Books => Set<Book>();
        public DbSet<BookCopy> BookCopies => Set<BookCopy>();
        public DbSet<Category> Categories => Set<Category>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cấu hình bảng Category
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Categories");
                entity.HasKey(c => c.CategoryId);
                entity.Property(c => c.CategoryName).IsRequired().HasMaxLength(150);
                entity.Property(c => c.Description).HasMaxLength(500);
            });

            // Cấu hình bảng Book & Quan hệ Category (1) - (N) Book
            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Books");
                entity.HasKey(b => b.BookId);
                entity.Property(b => b.Title).IsRequired().HasMaxLength(250);
                entity.Property(b => b.Author).HasMaxLength(150);
                entity.Property(b => b.ISBN).HasMaxLength(50);

                entity.HasOne(b => b.Category)
                      .WithMany(c => c.Books)
                      .HasForeignKey(b => b.CategoryId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Cấu hình bảng BookCopy & Quan hệ Book (1) - (N) BookCopy
            modelBuilder.Entity<BookCopy>(entity =>
            {
                entity.ToTable("BookCopies");
                entity.HasKey(bc => bc.BookCopyId);
                entity.Property(bc => bc.CopyCode).IsRequired().HasMaxLength(50);
                entity.Property(bc => bc.Status).IsRequired().HasMaxLength(50);

                entity.HasOne(bc => bc.Book)
                      .WithMany(b => b.BookCopies)
                      .HasForeignKey(bc => bc.BookId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }

    /// <summary>
    /// Factory tạo DbContext lúc Design-time để hỗ trợ lệnh dotnet ef
    /// </summary>
    public class QLTVDBContextFactory : IDesignTimeDbContextFactory<QLTVDBContext>
    {
        public QLTVDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<QLTVDBContext>();
            optionsBuilder.UseMySQL(QLTVDBContext.ConnectionString);
            return new QLTVDBContext(optionsBuilder.Options);
        }
    }
}
