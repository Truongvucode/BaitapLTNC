using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using LibraryApp.BLL.Services;
using LibraryApp.DAL.Data;
using LibraryApp.DAL.Repositories;
using LibraryApp.UI.Forms;

namespace LibraryApp.UI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Khởi tạo Configuration đọc từ appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            string connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? "Server=(localdb)\\mssqllocaldb;Database=LibraryDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;";

            // Cấu hình Dependency Injection Container
            var services = new ServiceCollection();

            // 1. Đăng ký DbContext
            services.AddDbContext<LibraryDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            // 2. Đăng ký DAL Repositories
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookCopyRepository, BookCopyRepository>();

            // 3. Đăng ký BLL Services
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBookCopyService, BookCopyService>();

            // 4. Đăng ký UI Forms
            services.AddTransient<FrmBookManagement>();

            var serviceProvider = services.BuildServiceProvider();

            // Tự động kiểm tra và khởi tạo Database + Seed Data nếu chưa có
            try
            {
                using var scope = serviceProvider.CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<LibraryDbContext>();
                dbContext.Database.EnsureCreated();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Không thể tự động kết nối cơ sở dữ liệu LocalDB: {ex.Message}\n\nBạn có thể chạy lệnh 'Update-Database' trong Package Manager Console.",
                    "Cảnh báo kết nối Database",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            // Chạy Form chính
            var mainForm = serviceProvider.GetRequiredService<FrmBookManagement>();
            Application.Run(mainForm);
        }
    }
}
