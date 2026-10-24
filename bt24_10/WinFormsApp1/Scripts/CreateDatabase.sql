-- ==========================================
-- Script tạo CSDL QLSV cho SQL Server
-- Chạy script này trên SQL Server Management Studio
-- Kết nối đến Server: LAPTOP-6SN65NCS\HUECTMDB
-- ==========================================

-- Tạo database nếu chưa có
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'QLSV')
BEGIN
    CREATE DATABASE QLSV;
END
GO

USE QLSV;
GO

-- ==========================================
-- Tạo bảng LopHoc
-- ==========================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'LopHoc')
BEGIN
    CREATE TABLE LopHoc (
        MaLop   NVARCHAR(10)  PRIMARY KEY,
        TenLop  NVARCHAR(100) NOT NULL
    );
END
GO

-- ==========================================
-- Tạo bảng SinhVien
-- ==========================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'SinhVien')
BEGIN
    CREATE TABLE SinhVien (
        MaSV       NVARCHAR(10)   PRIMARY KEY,
        HoTen      NVARCHAR(100)  NOT NULL,
        NgaySinh   DATETIME       NOT NULL,
        GioiTinh   BIT            NOT NULL DEFAULT 1,  -- 1 = Nam, 0 = Nữ
        Email      NVARCHAR(100)  NOT NULL,
        DienThoai  NVARCHAR(15)   NOT NULL,
        Diem       FLOAT          NOT NULL DEFAULT 0,
        MaLop      NVARCHAR(10)   NOT NULL,
        TrangThai  NVARCHAR(50)   NOT NULL DEFAULT N'Đang học',

        CONSTRAINT FK_SinhVien_LopHoc FOREIGN KEY (MaLop) 
            REFERENCES LopHoc(MaLop)
    );
END
GO

-- ==========================================
-- Thêm dữ liệu mẫu cho LopHoc
-- ==========================================
IF NOT EXISTS (SELECT * FROM LopHoc)
BEGIN
    INSERT INTO LopHoc (MaLop, TenLop) VALUES
        (N'CNTT01', N'Công nghệ thông tin 01'),
        (N'CNTT02', N'Công nghệ thông tin 02'),
        (N'KTPM01', N'Kỹ thuật phần mềm 01'),
        (N'HTTT01', N'Hệ thống thông tin 01'),
        (N'KHMT01', N'Khoa học máy tính 01');
END
GO

-- ==========================================
-- Thêm dữ liệu mẫu cho SinhVien
-- ==========================================
IF NOT EXISTS (SELECT * FROM SinhVien)
BEGIN
    INSERT INTO SinhVien (MaSV, HoTen, NgaySinh, GioiTinh, Email, DienThoai, Diem, MaLop, TrangThai) VALUES
        (N'SV00001', N'Nguyễn Văn An',    '2003-05-15', 1, N'an.nv@st.vju.ac.vn',    N'0912345671', 8.5, N'CNTT01', N'Đang học'),
        (N'SV00002', N'Trần Thị Bích',    '2003-08-20', 0, N'bich.tt@st.vju.ac.vn',  N'0912345672', 9.0, N'CNTT01', N'Đang học'),
        (N'SV00003', N'Lê Hoàng Cường',   '2003-01-10', 1, N'cuong.lh@st.vju.ac.vn', N'0912345673', 7.2, N'CNTT02', N'Đang học'),
        (N'SV00004', N'Phạm Thị Dung',    '2004-11-25', 0, N'dung.pt@st.vju.ac.vn',  N'0912345674', 8.0, N'KTPM01', N'Đang học'),
        (N'SV00005', N'Hoàng Đức Em',     '2004-03-30', 1, N'em.hd@st.vju.ac.vn',    N'0912345675', 6.8, N'KTPM01', N'Tạm dừng'),
        (N'SV00006', N'Vũ Thùy Linh',     '2003-07-12', 0, N'linh.vt@st.vju.ac.vn',  N'0912345676', 9.5, N'HTTT01', N'Đang học'),
        (N'SV00007', N'Đặng Minh Quang',  '2003-12-05', 1, N'quang.dm@st.vju.ac.vn', N'0912345677', 4.9, N'HTTT01', N'Tạm dừng'),
        (N'SV00008', N'Bùi Phương Thảo',  '2004-04-18', 0, N'thao.bp@st.vju.ac.vn',  N'0912345678', 8.8, N'KHMT01', N'Đã tốt nghiệp');
END
GO

PRINT N'Tạo CSDL QLSV thành công!';
GO
