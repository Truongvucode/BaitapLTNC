using Microsoft.EntityFrameworkCore;
using LibraryApp.DAL.Entities;
using LibraryApp.DAL.Enums;

namespace LibraryApp.DAL.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext()
        {
        }

        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<BookCopy> BookCopies { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Chuỗi kết nối mặc định LocalDB nếu chưa được cấu hình qua DI
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=LibraryDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cấu hình Category
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.CategoryId);
                entity.Property(c => c.CategoryName).IsRequired().HasMaxLength(100);
                entity.Property(c => c.Description).HasMaxLength(255);
                entity.HasIndex(c => c.CategoryName).IsUnique();

                // Quan hệ 1 - N: Category -> Books (Restrict: không cho xóa thể loại đang có sách)
                entity.HasMany(c => c.Books)
                      .WithOne(b => b.Category)
                      .HasForeignKey(b => b.CategoryId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Cấu hình Book
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(b => b.BookId);
                entity.Property(b => b.BookId).HasMaxLength(20);
                entity.Property(b => b.Title).IsRequired().HasMaxLength(200);
                entity.Property(b => b.Author).IsRequired().HasMaxLength(150);
                entity.Property(b => b.Publisher).HasMaxLength(150);
                entity.Property(b => b.Price).HasColumnType("decimal(18,0)");

                // Quan hệ 1 - N: Book -> BookCopies (Cascade: xóa sách thì xóa toàn bộ bản sao)
                entity.HasMany(b => b.Copies)
                      .WithOne(bc => bc.Book)
                      .HasForeignKey(bc => bc.BookId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Cấu hình BookCopy
            modelBuilder.Entity<BookCopy>(entity =>
            {
                entity.HasKey(bc => bc.CopyId);
                entity.Property(bc => bc.CopyId).HasMaxLength(30);
                entity.Property(bc => bc.BookId).IsRequired().HasMaxLength(20);

                // Lưu enum dưới dạng string trong DB
                entity.Property(bc => bc.Status)
                      .HasConversion<string>()
                      .HasMaxLength(20)
                      .IsRequired();

                entity.Property(bc => bc.PhysicalCondition)
                      .HasConversion<string>()
                      .HasMaxLength(20)
                      .IsRequired();
            });

            // Seed Data
            SeedData(modelBuilder);
        }

        private static void SeedData(ModelBuilder modelBuilder)
        {
            // 1. Seed 6 Categories
            var categories = new List<Category>
            {
                new Category { CategoryId = 1, CategoryName = "Văn học", Description = "Tiểu thuyết, truyện ngắn, thơ ca Việt Nam và thế giới" },
                new Category { CategoryId = 2, CategoryName = "Lịch sử", Description = "Sách nghiên cứu, tài liệu lịch sử dựng nước và giữ nước" },
                new Category { CategoryId = 3, CategoryName = "Kinh tế", Description = "Quản trị kinh doanh, tài chính, khởi nghiệp, marketing" },
                new Category { CategoryId = 4, CategoryName = "Khoa học tự nhiên", Description = "Toán học, Vật lý, Hóa học, Sinh học và Thiên văn học" },
                new Category { CategoryId = 5, CategoryName = "Công nghệ", Description = "Lập trình, CNTT, Trí tuệ nhân tạo, Khoa học dữ liệu" },
                new Category { CategoryId = 6, CategoryName = "Thiếu nhi", Description = "Truyện tranh, cổ tích, khoa học vui dành cho lứa tuổi nhỏ" }
            };
            modelBuilder.Entity<Category>().HasData(categories);

            // 2. Seed 16 Books (B001 -> B016)
            var books = new List<Book>
            {
                new Book { BookId = "B001", Title = "Mắt Biếc", Author = "Nguyễn Nhật Ánh", Publisher = "NXB Trẻ", Price = 110000m, PublishYear = 2019, CategoryId = 1 },
                new Book { BookId = "B002", Title = "Số Đỏ", Author = "Vũ Trọng Phụng", Publisher = "NXB Văn Học", Price = 85000m, PublishYear = 2020, CategoryId = 1 },
                new Book { BookId = "B003", Title = "Đại Việt Sử Ký Toàn Thư", Author = "Ngô Sĩ Liên", Publisher = "NXB Thời Đại", Price = 350000m, PublishYear = 2018, CategoryId = 2 },
                new Book { BookId = "B004", Title = "Việt Nam Sử Lược", Author = "Trần Trọng Kim", Publisher = "NXB Kim Đồng", Price = 150000m, PublishYear = 2021, CategoryId = 2 },
                new Book { BookId = "B005", Title = "Cha Giàu Cha Nghèo", Author = "Robert Kiyosaki", Publisher = "NXB Trẻ", Price = 135000m, PublishYear = 2020, CategoryId = 3 },
                new Book { BookId = "B006", Title = "Kinh Tế Học Hài Hước", Author = "Steven D. Levitt", Publisher = "NXB Lao Động", Price = 145000m, PublishYear = 2019, CategoryId = 3 },
                new Book { BookId = "B007", Title = "Lược Sử Thời Gian", Author = "Stephen Hawking", Publisher = "NXB Trẻ", Price = 160000m, PublishYear = 2017, CategoryId = 4 },
                new Book { BookId = "B008", Title = "Vũ Trụ Trong Vỏ Hạt Dẻ", Author = "Stephen Hawking", Publisher = "NXB Trẻ", Price = 175000m, PublishYear = 2019, CategoryId = 4 },
                new Book { BookId = "B009", Title = "Clean Code", Author = "Robert C. Martin", Publisher = "Prentice Hall", Price = 450000m, PublishYear = 2018, CategoryId = 5 },
                new Book { BookId = "B010", Title = "C# in Depth (4th Edition)", Author = "Jon Skeet", Publisher = "Manning", Price = 520000m, PublishYear = 2019, CategoryId = 5 },
                new Book { BookId = "B011", Title = "Design Patterns", Author = "Gang of Four", Publisher = "Addison-Wesley", Price = 480000m, PublishYear = 2016, CategoryId = 5 },
                new Book { BookId = "B012", Title = "Dế Mèn Phiêu Lưu Ký", Author = "Tô Hoài", Publisher = "NXB Kim Đồng", Price = 65000m, PublishYear = 2022, CategoryId = 6 },
                new Book { BookId = "B013", Title = "Hoàng Tử Bé", Author = "Antoine de Saint-Exupéry", Publisher = "NXB Hội Nhà Văn", Price = 75000m, PublishYear = 2021, CategoryId = 6 },
                new Book { BookId = "B014", Title = "Chiếc Thuyền Ngoài Xa", Author = "Nguyễn Minh Châu", Publisher = "NXB Giáo Dục", Price = 60000m, PublishYear = 2020, CategoryId = 1 },
                new Book { BookId = "B015", Title = "Tư Duy Nhanh Và Chậm", Author = "Daniel Kahneman", Publisher = "NXB Thế Giới", Price = 210000m, PublishYear = 2021, CategoryId = 3 },
                new Book { BookId = "B016", Title = "Refactoring", Author = "Martin Fowler", Publisher = "Addison-Wesley", Price = 490000m, PublishYear = 2019, CategoryId = 5 }
            };
            modelBuilder.Entity<Book>().HasData(books);

            // 3. Seed 3-5 BookCopies per book
            var copies = new List<BookCopy>();
            int[] copyCounts = { 3, 4, 3, 5, 4, 3, 4, 3, 5, 4, 3, 5, 4, 3, 4, 3 };

            for (int i = 0; i < books.Count; i++)
            {
                var book = books[i];
                int count = copyCounts[i];
                for (int c = 1; c <= count; c++)
                {
                    string copyId = $"{book.BookId}.{c:D3}";
                    // Phân bổ trạng thái và tình trạng thực tế
                    CopyStatus status = CopyStatus.Available;
                    PhysicalCondition condition = PhysicalCondition.Good;

                    if (c == 1)
                    {
                        condition = PhysicalCondition.New;
                    }
                    else if (c == 2 && (i % 2 == 0))
                    {
                        status = CopyStatus.Borrowed;
                        condition = PhysicalCondition.Good;
                    }
                    else if (c == 3 && (i % 5 == 0))
                    {
                        status = CopyStatus.Maintenance;
                        condition = PhysicalCondition.Worn;
                    }
                    else if (c == 4 && (i % 4 == 0))
                    {
                        condition = PhysicalCondition.Worn;
                    }

                    copies.Add(new BookCopy
                    {
                        CopyId = copyId,
                        BookId = book.BookId,
                        Status = status,
                        PhysicalCondition = condition
                    });
                }
            }
            modelBuilder.Entity<BookCopy>().HasData(copies);
        }
    }
}
