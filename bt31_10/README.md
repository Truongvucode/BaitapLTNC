# HỆ THỐNG QUẢN LÝ ĐẦU SÁCH VÀ BẢN SAO (LIBRARY MANAGEMENT)

Ứng dụng Windows Forms (.NET 8) quản lý thư viện áp dụng mô hình 3 lớp (3-Tier Architecture), Entity Framework Core (Code First), SQL Server LocalDB.

---

## 1. Cấu Trúc Dự Án (3 Tầng)

```
bt31_10/
├── LibraryApp.sln                      # Solution chứa 3 dự án
│
├── LibraryApp.DAL/                     # Data Access Layer
│   ├── LibraryApp.DAL.csproj
│   ├── Entities/                       # Thực thể Code First
│   │   ├── Category.cs                 # Thể loại (CategoryId, CategoryName, Description)
│   │   ├── Book.cs                     # Đầu sách (BookId, Title, Author, Price, CopyCount...)
│   │   └── BookCopy.cs                 # Bản sao (CopyId, Status, PhysicalCondition)
│   ├── Enums/                          # Enum định nghĩa trạng thái & tình trạng
│   │   ├── CopyStatus.cs               # Sẵn sàng, Đang mượn, Mất, Bảo trì
│   │   ├── PhysicalCondition.cs        # Mới, Tốt, Cũ, Hỏng
│   │   └── EnumExtensions.cs           # Chuyển đổi tên hiển thị tiếng Việt
│   ├── Data/
│   │   ├── LibraryDbContext.cs         # EF Core DbContext, Fluent API, Seed Data
│   │   └── LibraryDbContextFactory.cs  # Hỗ trợ CLI/PMC migrations
│   └── Repositories/                   # Generic & Specific Repositories (async/await)
│       ├── ICategoryRepository.cs / CategoryRepository.cs
│       ├── IBookRepository.cs / BookRepository.cs
│       └── IBookCopyRepository.cs / BookCopyRepository.cs
│
├── LibraryApp.BLL/                     # Business Logic Layer
│   ├── LibraryApp.BLL.csproj
│   ├── DTOs/                           # Data Transfer Objects
│   │   ├── CategoryDto.cs
│   │   ├── BookDto.cs
│   │   └── BookCopyDto.cs
│   ├── Exceptions/
│   │   └── BusinessException.cs        # Ngoại lệ nghiệp vụ
│   └── Services/                       # Nghiệp vụ & Validation
│       ├── ICategoryService.cs / CategoryService.cs
│       ├── IBookService.cs / BookService.cs
│       └── IBookCopyService.cs / BookCopyService.cs
│
└── LibraryApp.UI/                      # Presentation Layer (WinForms .NET 8)
    ├── LibraryApp.UI.csproj
    ├── appsettings.json                # Chuỗi kết nối LocalDB
    ├── Program.cs                      # Cấu hình DI & Khởi tạo database
    └── Forms/
        ├── FrmBookManagement.cs        # Màn hình chính quản lý đầu sách & bản sao
        ├── FrmBookManagement.Designer.cs
        ├── FrmAddCopies.cs             # Dialog nhập bổ sung nhiều bản sao
        ├── FrmAddCopies.Designer.cs
        ├── FrmUpdateCopy.cs            # Dialog cập nhật trạng thái bản sao
        └── FrmUpdateCopy.Designer.cs
```

---

## 2. Gói NuGet Được Sử Dụng

### `LibraryApp.DAL`
- `Microsoft.EntityFrameworkCore` (8.0.8)
- `Microsoft.EntityFrameworkCore.SqlServer` (8.0.8)
- `Microsoft.EntityFrameworkCore.Design` (8.0.8)
- `Microsoft.EntityFrameworkCore.Tools` (8.0.8)
- `Microsoft.Extensions.Configuration.Json` (8.0.0)

### `LibraryApp.UI`
- `Microsoft.EntityFrameworkCore.Design` (8.0.8)
- `Microsoft.Extensions.DependencyInjection` (8.0.0)
- `Microsoft.Extensions.Configuration.Json` (8.0.0)

---

## 3. Hướng Dẫn Tạo Migration & Cập Nhật Database

### Cách 1: Sử dụng Package Manager Console trong Visual Studio
1. Mở Visual Studio và mở file solution `LibraryApp.sln`.
2. Mở menu **Tools** -> **NuGet Package Manager** -> **Package Manager Console**.
3. Tại ô **Default project**, chọn `LibraryApp.DAL`.
4. Chạy 2 lệnh sau:
```powershell
Add-Migration InitialCreate -StartupProject LibraryApp.UI
Update-Database -StartupProject LibraryApp.UI
```

### Cách 2: Sử dụng .NET CLI (Terminal)
Từ thư mục gốc `bt31_10`, chạy các lệnh:
```bash
dotnet tool install --global dotnet-ef

dotnet ef migrations add InitialCreate --project LibraryApp.DAL --startup-project LibraryApp.UI
dotnet ef database update --project LibraryApp.DAL --startup-project LibraryApp.UI
```

> **Ghi chú tự động:** Trong `Program.cs`, ứng dụng đã tích hợp lệnh `dbContext.Database.EnsureCreated()`. Nếu bạn chỉ cần chạy thử nghiệm ngay lập tức, chỉ cần nhấn **F5** trong Visual Studio, cơ sở dữ liệu `LibraryDb` trên `(localdb)\mssqllocaldb` cùng toàn bộ 6 thể loại, 16 đầu sách mẫu và các bản sao sẽ tự động được khởi tạo!

---

## 4. Dữ Liệu Khởi Tạo (Seed Data)
- **6 Thể loại**: Văn học, Lịch sử, Kinh tế, Khoa học tự nhiên, Công nghệ, Thiếu nhi.
- **16 Đầu sách mẫu** (mã từ `B001` đến `B016`) với đầy đủ tiêu đề, tác giả, giá, nhà xuất bản, năm xuất bản.
- **Bản sao sách**: Mỗi đầu sách có từ 3 đến 5 bản sao với mã dạng `{BookId}.001`, `{BookId}.002`,... phân bổ trạng thái (Sẵn sàng, Đang mượn, Bảo trì) và tình trạng vật lý (Mới, Tốt, Cũ, Hỏng).

---

## 5. Các Quy Tắc Nghiệp Vụ Chính
1. **Thêm đầu sách**: Bắt buộc nhập Mã sách, Tên sách, Tác giả, Thể loại; kiểm tra không trùng mã sách; giá sách >= 0; năm xuất bản <= năm hiện tại.
2. **Lưu chỉnh sửa**: Không cho phép sửa Mã sách, cập nhật các trường còn lại.
3. **Xóa đầu sách**: Hiển thị xác nhận; ngăn chặn việc xóa nếu có bất kỳ bản sao nào đang ở trạng thái **Đang mượn**. Nếu hợp lệ, tự động xóa theo tầng (Cascade delete) toàn bộ bản sao liên quan.
4. **Nhập bổ sung bản sao**: Mở hộp thoại nhập số lượng (1 - 100), chọn tình trạng vật lý mặc định, tự động tăng mã bản sao dạng `{BookId}.{số thứ tự 3 chữ số}` tiếp theo số lớn nhất hiện có.
5. **Cập nhật & Xóa bản sao**: Cho phép chuyển đổi trạng thái (Sẵn sàng, Đang mượn, Mất, Bảo trì) và tình trạng vật lý (Mới, Tốt, Cũ, Hỏng). Ngăn chặn xóa bản sao đang ở trạng thái **Đang mượn**.
