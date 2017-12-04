
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/01/2017 17:11:32
-- Generated from EDMX file: C:\Users\quocq\Desktop\DACN\QuanLyThueXe\QuanLyThueXe\Models\QuanLyThueXe.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [QLTX];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CT_HoaDon_HoaDon]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CT_HoaDon] DROP CONSTRAINT [FK_CT_HoaDon_HoaDon];
GO
IF OBJECT_ID(N'[dbo].[FK_CT_HoaDon_HopDong]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CT_HoaDon] DROP CONSTRAINT [FK_CT_HoaDon_HopDong];
GO
IF OBJECT_ID(N'[dbo].[FK_CT_HopDongs_CongTy]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CT_HopDong] DROP CONSTRAINT [FK_CT_HopDongs_CongTy];
GO
IF OBJECT_ID(N'[dbo].[FK_CT_HopDongs_HopDong]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CT_HopDong] DROP CONSTRAINT [FK_CT_HopDongs_HopDong];
GO
IF OBJECT_ID(N'[dbo].[FK_CT_HopDongs_NhanVien1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CT_HopDong] DROP CONSTRAINT [FK_CT_HopDongs_NhanVien1];
GO
IF OBJECT_ID(N'[dbo].[FK_CT_HopDongs_Xe]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CT_HopDong] DROP CONSTRAINT [FK_CT_HopDongs_Xe];
GO
IF OBJECT_ID(N'[dbo].[FK_Gia_LoaiXe]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BangGia] DROP CONSTRAINT [FK_Gia_LoaiXe];
GO
IF OBJECT_ID(N'[dbo].[FK_Gia_LoTrinh]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BangGia] DROP CONSTRAINT [FK_Gia_LoTrinh];
GO
IF OBJECT_ID(N'[dbo].[FK_HoaDon_KhachHang]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HoaDon] DROP CONSTRAINT [FK_HoaDon_KhachHang];
GO
IF OBJECT_ID(N'[dbo].[FK_HoaDon_NhanVien]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HoaDon] DROP CONSTRAINT [FK_HoaDon_NhanVien];
GO
IF OBJECT_ID(N'[dbo].[FK_HopDong_HinhThucThanhToan]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HopDong] DROP CONSTRAINT [FK_HopDong_HinhThucThanhToan];
GO
IF OBJECT_ID(N'[dbo].[FK_HopDong_HinhThucThue]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HopDong] DROP CONSTRAINT [FK_HopDong_HinhThucThue];
GO
IF OBJECT_ID(N'[dbo].[FK_HopDong_KhachHang]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HopDong] DROP CONSTRAINT [FK_HopDong_KhachHang];
GO
IF OBJECT_ID(N'[dbo].[FK_HopDong_LoTrinh]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HopDong] DROP CONSTRAINT [FK_HopDong_LoTrinh];
GO
IF OBJECT_ID(N'[dbo].[FK_HopDong_NhanVien]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HopDong] DROP CONSTRAINT [FK_HopDong_NhanVien];
GO
IF OBJECT_ID(N'[dbo].[FK_HopDong_TrangThaiHopDong]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HopDong] DROP CONSTRAINT [FK_HopDong_TrangThaiHopDong];
GO
IF OBJECT_ID(N'[dbo].[FK_KhachHang_LoaiKH]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KhachHang] DROP CONSTRAINT [FK_KhachHang_LoaiKH];
GO
IF OBJECT_ID(N'[dbo].[FK_LoaiAction_Loaicontroller]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LoaiAction] DROP CONSTRAINT [FK_LoaiAction_Loaicontroller];
GO
IF OBJECT_ID(N'[dbo].[FK_LoaiNhanVien_Luong]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LoaiNhanVien] DROP CONSTRAINT [FK_LoaiNhanVien_Luong];
GO
IF OBJECT_ID(N'[dbo].[FK_NhanVien_LoaiBang]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[NhanVien] DROP CONSTRAINT [FK_NhanVien_LoaiBang];
GO
IF OBJECT_ID(N'[dbo].[FK_NhanVien_LoaiNhanVien]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[NhanVien] DROP CONSTRAINT [FK_NhanVien_LoaiNhanVien];
GO
IF OBJECT_ID(N'[dbo].[FK_NhanVien_Tinh_TP1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[NhanVien] DROP CONSTRAINT [FK_NhanVien_Tinh_TP1];
GO
IF OBJECT_ID(N'[dbo].[FK_PhanQuyen_LoaiAction]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PhanQuyen] DROP CONSTRAINT [FK_PhanQuyen_LoaiAction];
GO
IF OBJECT_ID(N'[dbo].[FK_PhanQuyen_Quyen]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PhanQuyen] DROP CONSTRAINT [FK_PhanQuyen_Quyen];
GO
IF OBJECT_ID(N'[dbo].[FK_PhieuChi_NhanVien]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PhieuChi] DROP CONSTRAINT [FK_PhieuChi_NhanVien];
GO
IF OBJECT_ID(N'[dbo].[FK_PhieuThu_NhanVien]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PhieuThu] DROP CONSTRAINT [FK_PhieuThu_NhanVien];
GO
IF OBJECT_ID(N'[dbo].[FK_TaiKhoan_NhanVien]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TaiKhoan] DROP CONSTRAINT [FK_TaiKhoan_NhanVien];
GO
IF OBJECT_ID(N'[dbo].[FK_TaiKhoan_Quyen]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TaiKhoan] DROP CONSTRAINT [FK_TaiKhoan_Quyen];
GO
IF OBJECT_ID(N'[dbo].[FK_Xe_CongTy]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Xe] DROP CONSTRAINT [FK_Xe_CongTy];
GO
IF OBJECT_ID(N'[dbo].[FK_Xe_LoaiXe]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Xe] DROP CONSTRAINT [FK_Xe_LoaiXe];
GO
IF OBJECT_ID(N'[dbo].[FK_Xe_ThuongHieuXe]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Xe] DROP CONSTRAINT [FK_Xe_ThuongHieuXe];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[BangGia]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BangGia];
GO
IF OBJECT_ID(N'[dbo].[ChiPhiPhatSinh]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChiPhiPhatSinh];
GO
IF OBJECT_ID(N'[dbo].[ChiTietChiPhiPhatSinh]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChiTietChiPhiPhatSinh];
GO
IF OBJECT_ID(N'[dbo].[CongTy]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CongTy];
GO
IF OBJECT_ID(N'[dbo].[CT_HoaDon]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CT_HoaDon];
GO
IF OBJECT_ID(N'[dbo].[CT_HopDong]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CT_HopDong];
GO
IF OBJECT_ID(N'[dbo].[HinhThucThanhToan]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HinhThucThanhToan];
GO
IF OBJECT_ID(N'[dbo].[HinhThucThue]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HinhThucThue];
GO
IF OBJECT_ID(N'[dbo].[HoaDon]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HoaDon];
GO
IF OBJECT_ID(N'[dbo].[HopDong]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HopDong];
GO
IF OBJECT_ID(N'[dbo].[KhachHang]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KhachHang];
GO
IF OBJECT_ID(N'[dbo].[LoaiAction]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LoaiAction];
GO
IF OBJECT_ID(N'[dbo].[LoaiBang]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LoaiBang];
GO
IF OBJECT_ID(N'[dbo].[LoaiController]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LoaiController];
GO
IF OBJECT_ID(N'[dbo].[LoaiKhachHang]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LoaiKhachHang];
GO
IF OBJECT_ID(N'[dbo].[LoaiNhanVien]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LoaiNhanVien];
GO
IF OBJECT_ID(N'[dbo].[LoaiXe]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LoaiXe];
GO
IF OBJECT_ID(N'[dbo].[LoTrinh]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LoTrinh];
GO
IF OBJECT_ID(N'[dbo].[Luong]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Luong];
GO
IF OBJECT_ID(N'[dbo].[NhanVien]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NhanVien];
GO
IF OBJECT_ID(N'[dbo].[PhanQuyen]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PhanQuyen];
GO
IF OBJECT_ID(N'[dbo].[PhieuChi]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PhieuChi];
GO
IF OBJECT_ID(N'[dbo].[PhieuThu]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PhieuThu];
GO
IF OBJECT_ID(N'[dbo].[Quyen]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Quyen];
GO
IF OBJECT_ID(N'[dbo].[TaiKhoan]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TaiKhoan];
GO
IF OBJECT_ID(N'[dbo].[ThuongHieuXe]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ThuongHieuXe];
GO
IF OBJECT_ID(N'[dbo].[Tinh_TP]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tinh_TP];
GO
IF OBJECT_ID(N'[dbo].[TrangThaiHopDong]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TrangThaiHopDong];
GO
IF OBJECT_ID(N'[dbo].[Xe]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Xe];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'BangGias'
CREATE TABLE [dbo].[BangGias] (
    [STT] int IDENTITY(1,1) NOT NULL,
    [MaBangGia] varchar(20)  NOT NULL,
    [MaLoaiXe] varchar(20)  NOT NULL,
    [MaKH] varchar(20)  NOT NULL,
    [MaLoTrinh] varchar(20)  NOT NULL,
    [Gia] decimal(18,0)  NULL,
    [ThoiGian] nvarchar(50)  NULL,
    [SoKM] decimal(18,0)  NULL,
    [Dang] bit  NULL
);
GO

-- Creating table 'ChiPhiPhatSinhs'
CREATE TABLE [dbo].[ChiPhiPhatSinhs] (
    [MaChiPhi] varchar(20)  NOT NULL,
    [TenChiPhi] nvarchar(150)  NULL,
    [PhiPhatSinh] decimal(18,0)  NULL,
    [Mota] nvarchar(max)  NULL,
    [SoLuong] int  NULL,
    [STT] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'ChiTietChiPhiPhatSinhs'
CREATE TABLE [dbo].[ChiTietChiPhiPhatSinhs] (
    [STT] int IDENTITY(1,1) NOT NULL,
    [SoHopDong] varchar(20)  NULL,
    [MaChiPhi] varchar(20)  NULL,
    [SoLuong] int  NULL,
    [DonGia] decimal(18,0)  NULL
);
GO

-- Creating table 'CongTies'
CREATE TABLE [dbo].[CongTies] (
    [MaCongTy] varchar(20)  NOT NULL,
    [TenCongTy] nvarchar(150)  NULL,
    [Email] varchar(150)  NULL,
    [DiaChi] nvarchar(150)  NULL,
    [SDT] varchar(20)  NULL,
    [Fax] varchar(20)  NULL,
    [NguoiLienHe] nvarchar(150)  NULL,
    [GhiChu] nvarchar(max)  NULL,
    [Dang] bit  NULL,
    [VAT] int  NULL,
    [MaSoThue] nvarchar(50)  NULL,
    [STT] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'CT_HoaDon'
CREATE TABLE [dbo].[CT_HoaDon] (
    [SoHopDong] varchar(50)  NOT NULL,
    [SoHoaDon] nvarchar(50)  NOT NULL,
    [TongSoXeThue] int  NULL,
    [SoTienTraTruoc] decimal(18,0)  NULL,
    [SoTienConLai] decimal(18,0)  NULL,
    [TongThanhToan] decimal(18,0)  NULL,
    [STT] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'CT_HopDong'
CREATE TABLE [dbo].[CT_HopDong] (
    [SoCTHopDong] int IDENTITY(1,1) NOT NULL,
    [SoHopDong] varchar(50)  NULL,
    [MaLoaiXe] varchar(20)  NULL,
    [MaXe] varchar(20)  NULL,
    [QuaDem] int  NULL,
    [SoLuongNguoi] int  NULL,
    [NgayDi] datetime  NOT NULL,
    [NgayVe] datetime  NOT NULL,
    [GioDon] datetime  NULL,
    [DiaDiemDon] nvarchar(150)  NULL,
    [Gia] decimal(18,0)  NULL,
    [MaChiPhi] varchar(50)  NULL,
    [MaTaiXe] varchar(20)  NULL,
    [BienSoXe] varchar(50)  NULL,
    [HuongDanVien] nvarchar(200)  NULL,
    [MaCongTy] varchar(20)  NULL,
    [GhiChu] nvarchar(max)  NULL,
    [SoLuong] int  NULL,
    [PhuXe] nvarchar(150)  NULL,
    [TaiXeNgoai] nvarchar(150)  NULL
);
GO

-- Creating table 'HinhThucThanhToans'
CREATE TABLE [dbo].[HinhThucThanhToans] (
    [MaHinhThucTT] varchar(20)  NOT NULL,
    [TenHinhThucTT] nvarchar(50)  NULL,
    [STT] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'HinhThucThues'
CREATE TABLE [dbo].[HinhThucThues] (
    [MaHinhThuc] varchar(20)  NOT NULL,
    [TenHinhThuc] nvarchar(100)  NULL,
    [Dang] bit  NULL,
    [STT] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'HoaDons'
CREATE TABLE [dbo].[HoaDons] (
    [SoHoaDon] nvarchar(50)  NOT NULL,
    [MaKH] varchar(20)  NULL,
    [MaNV] varchar(20)  NULL,
    [NgayLap] datetime  NULL,
    [STT] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'HopDongs'
CREATE TABLE [dbo].[HopDongs] (
    [SoHopDong] varchar(50)  NOT NULL,
    [NgayLapHD] datetime  NULL,
    [MaLoTrinh] varchar(20)  NULL,
    [MaKH] varchar(20)  NULL,
    [MaNV] varchar(20)  NULL,
    [MaHinhThucThue] varchar(20)  NULL,
    [MaHinhThucThanhToan] varchar(20)  NULL,
    [MaTrangThai] varchar(20)  NULL,
    [SoTienTraTruoc] decimal(18,0)  NULL,
    [SoTienConLai] decimal(18,0)  NULL,
    [GiamGia] decimal(18,0)  NULL,
    [GhiChu] nvarchar(500)  NULL,
    [STT] int IDENTITY(1,1) NOT NULL,
    [MaChiPhi] varchar(50)  NULL,
    [SoLuongCP] varchar(50)  NULL
);
GO

-- Creating table 'KhachHangs'
CREATE TABLE [dbo].[KhachHangs] (
    [MaKH] varchar(20)  NOT NULL,
    [MaLoaiKH] varchar(20)  NULL,
    [GioiTinh] bit  NULL,
    [Email] nvarchar(150)  NULL,
    [TenKH] nvarchar(150)  NULL,
    [TenCongTy] nvarchar(200)  NULL,
    [DiaChiKH] nvarchar(150)  NULL,
    [CMND] varchar(50)  NULL,
    [SDT] varchar(50)  NULL,
    [SDTCongTy] varchar(50)  NULL,
    [GhiChu] nvarchar(max)  NULL,
    [DiaChiCongTy] nvarchar(150)  NULL,
    [NguoiLienHe] nvarchar(200)  NULL,
    [GiamGia] decimal(18,0)  NULL,
    [MaSoThue] varchar(50)  NULL,
    [Dang] bit  NULL,
    [STT] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'LoaiActions'
CREATE TABLE [dbo].[LoaiActions] (
    [MaAction] int IDENTITY(1,1) NOT NULL,
    [TenAction] nvarchar(150)  NULL,
    [Mota] nvarchar(150)  NULL,
    [UrlAction] varchar(150)  NULL,
    [MaController] varchar(150)  NULL
);
GO

-- Creating table 'LoaiBangs'
CREATE TABLE [dbo].[LoaiBangs] (
    [MaBang] varchar(20)  NOT NULL,
    [TenBang] nvarchar(100)  NULL,
    [MoTa] nvarchar(max)  NULL,
    [STT] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'LoaiControllers'
CREATE TABLE [dbo].[LoaiControllers] (
    [MaController] varchar(150)  NOT NULL,
    [TenController] nvarchar(100)  NULL,
    [Icon] nvarchar(150)  NULL,
    [STT] int  NOT NULL
);
GO

-- Creating table 'LoaiKhachHangs'
CREATE TABLE [dbo].[LoaiKhachHangs] (
    [MaLoaiKH] varchar(20)  NOT NULL,
    [TenLoaiKH] nvarchar(50)  NULL,
    [STT] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'LoaiNhanViens'
CREATE TABLE [dbo].[LoaiNhanViens] (
    [MaLoaiNV] varchar(20)  NOT NULL,
    [Dang] bit  NULL,
    [TenLoaiNV] nvarchar(150)  NULL,
    [MaLuong] varchar(20)  NULL,
    [STT] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'LoaiXes'
CREATE TABLE [dbo].[LoaiXes] (
    [MaLoaiXe] varchar(20)  NOT NULL,
    [TenLoaiXe] nvarchar(50)  NULL,
    [Dang] bit  NULL,
    [STT] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'LoTrinhs'
CREATE TABLE [dbo].[LoTrinhs] (
    [MaLoTrinh] varchar(20)  NOT NULL,
    [TenLoTrinh] nvarchar(250)  NULL,
    [Dang] bit  NULL,
    [MaKH] varchar(20)  NULL,
    [STT] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Luongs'
CREATE TABLE [dbo].[Luongs] (
    [MaLuong] varchar(20)  NOT NULL,
    [Luong1] decimal(18,0)  NULL,
    [STT] int IDENTITY(1,1) NOT NULL,
    [Luong11] decimal(18,0)  NULL
);
GO

-- Creating table 'NhanViens'
CREATE TABLE [dbo].[NhanViens] (
    [MaNV] varchar(20)  NOT NULL,
    [HoTen] nvarchar(100)  NULL,
    [NgaySinh] datetime  NULL,
    [DiaChi] nvarchar(150)  NULL,
    [CMND] varchar(15)  NULL,
    [HinhAnh] varchar(150)  NULL,
    [Dang] bit  NULL,
    [MaLoaiNV] varchar(20)  NULL,
    [SDT] varchar(15)  NULL,
    [LuongThuong] decimal(18,0)  NULL,
    [ThongTinKhac] nvarchar(max)  NULL,
    [MaBang] varchar(20)  NULL,
    [Status] nvarchar(50)  NULL,
    [MaTinh] varchar(30)  NULL,
    [NgayNghi] datetime  NULL,
    [SoLan] int  NULL,
    [ThoiGianGanDay] datetime  NULL,
    [GioiTinh] bit  NULL,
    [Email] nvarchar(150)  NULL,
    [MaSoThue] nvarchar(100)  NULL,
    [STT] int IDENTITY(1,1) NOT NULL,
    [NgayHethan] datetime  NULL,
    [GPLX] nvarchar(150)  NULL
);
GO

-- Creating table 'PhanQuyens'
CREATE TABLE [dbo].[PhanQuyens] (
    [MaQuyen] varchar(50)  NOT NULL,
    [MaAction] int  NOT NULL,
    [MoTa] varchar(15)  NULL
);
GO

-- Creating table 'PhieuChis'
CREATE TABLE [dbo].[PhieuChis] (
    [SoPhieuChi] varchar(20)  NOT NULL,
    [MaNV] varchar(20)  NULL,
    [LyDo] nvarchar(max)  NULL,
    [NgayChi] datetime  NULL,
    [SoTienChi] decimal(18,0)  NULL,
    [STT] int IDENTITY(1,1) NOT NULL,
    [NguoiNhan] nvarchar(75)  NULL,
    [DiaChi] nvarchar(150)  NULL
);
GO

-- Creating table 'PhieuThus'
CREATE TABLE [dbo].[PhieuThus] (
    [SoPhieuThu] varchar(20)  NOT NULL,
    [LyDo] nvarchar(max)  NULL,
    [SoTienThu] decimal(18,0)  NULL,
    [NgayThu] datetime  NULL,
    [MaNV] varchar(20)  NULL,
    [STT] int IDENTITY(1,1) NOT NULL,
    [NguoiNop] nvarchar(100)  NULL,
    [DiaChi] nvarchar(150)  NULL
);
GO

-- Creating table 'Quyens'
CREATE TABLE [dbo].[Quyens] (
    [MaQuyen] varchar(50)  NOT NULL,
    [TenQuyen] nvarchar(100)  NULL,
    [STT] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'TaiKhoans'
CREATE TABLE [dbo].[TaiKhoans] (
    [TaiKhoanNV] varchar(20)  NOT NULL,
    [MatKhau] varchar(50)  NULL,
    [MaNV] varchar(20)  NULL,
    [MaQuyen] varchar(50)  NULL,
    [STT] int IDENTITY(1,1) NOT NULL,
    [Online] bit  NULL
);
GO

-- Creating table 'ThuongHieuXes'
CREATE TABLE [dbo].[ThuongHieuXes] (
    [MaThuongHieu] varchar(20)  NOT NULL,
    [TenThuongHieu] nvarchar(50)  NULL,
    [STT] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Tinh_TP'
CREATE TABLE [dbo].[Tinh_TP] (
    [MaTinh] varchar(30)  NOT NULL,
    [TenTinh] nvarchar(100)  NULL,
    [STT] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'TrangThaiHopDongs'
CREATE TABLE [dbo].[TrangThaiHopDongs] (
    [MaTrangThai] varchar(20)  NOT NULL,
    [TenTrangThai] nvarchar(50)  NULL,
    [STT] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Xes'
CREATE TABLE [dbo].[Xes] (
    [MaXe] varchar(20)  NOT NULL,
    [BienSo] varchar(20)  NULL,
    [Mota] nvarchar(max)  NULL,
    [MaLoaiXe] varchar(20)  NULL,
    [HinhAnh] varchar(150)  NULL,
    [Dang] bit  NULL,
    [MaCongTy] varchar(20)  NULL,
    [MaThuongHieu] varchar(20)  NULL,
    [NgayDangKiem] datetime  NULL,
    [GhiChu] nvarchar(max)  NULL,
    [Status] nvarchar(50)  NULL,
    [NgayBaoTriXe] datetime  NULL,
    [SoKm] decimal(18,0)  NULL,
    [SoLan] int  NULL,
    [ThoiGianGanDay] datetime  NULL,
    [MaNV] varchar(20)  NULL,
    [STT] int IDENTITY(1,1) NOT NULL,
    [BaoHiemTuNguyen] datetime  NULL,
    [BaoHiemBatBuoc] datetime  NULL,
    [NgayDangKi] datetime  NULL,
    [DangKiem] datetime  NULL,
    [HopDong] nvarchar(150)  NULL,
    [ChuXe] nvarchar(150)  NULL,
    [DiaChi] nvarchar(250)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [MaBangGia] in table 'BangGias'
ALTER TABLE [dbo].[BangGias]
ADD CONSTRAINT [PK_BangGias]
    PRIMARY KEY CLUSTERED ([MaBangGia] ASC);
GO

-- Creating primary key on [MaChiPhi] in table 'ChiPhiPhatSinhs'
ALTER TABLE [dbo].[ChiPhiPhatSinhs]
ADD CONSTRAINT [PK_ChiPhiPhatSinhs]
    PRIMARY KEY CLUSTERED ([MaChiPhi] ASC);
GO

-- Creating primary key on [STT] in table 'ChiTietChiPhiPhatSinhs'
ALTER TABLE [dbo].[ChiTietChiPhiPhatSinhs]
ADD CONSTRAINT [PK_ChiTietChiPhiPhatSinhs]
    PRIMARY KEY CLUSTERED ([STT] ASC);
GO

-- Creating primary key on [MaCongTy] in table 'CongTies'
ALTER TABLE [dbo].[CongTies]
ADD CONSTRAINT [PK_CongTies]
    PRIMARY KEY CLUSTERED ([MaCongTy] ASC);
GO

-- Creating primary key on [SoHopDong], [SoHoaDon] in table 'CT_HoaDon'
ALTER TABLE [dbo].[CT_HoaDon]
ADD CONSTRAINT [PK_CT_HoaDon]
    PRIMARY KEY CLUSTERED ([SoHopDong], [SoHoaDon] ASC);
GO

-- Creating primary key on [SoCTHopDong] in table 'CT_HopDong'
ALTER TABLE [dbo].[CT_HopDong]
ADD CONSTRAINT [PK_CT_HopDong]
    PRIMARY KEY CLUSTERED ([SoCTHopDong] ASC);
GO

-- Creating primary key on [MaHinhThucTT] in table 'HinhThucThanhToans'
ALTER TABLE [dbo].[HinhThucThanhToans]
ADD CONSTRAINT [PK_HinhThucThanhToans]
    PRIMARY KEY CLUSTERED ([MaHinhThucTT] ASC);
GO

-- Creating primary key on [MaHinhThuc] in table 'HinhThucThues'
ALTER TABLE [dbo].[HinhThucThues]
ADD CONSTRAINT [PK_HinhThucThues]
    PRIMARY KEY CLUSTERED ([MaHinhThuc] ASC);
GO

-- Creating primary key on [SoHoaDon] in table 'HoaDons'
ALTER TABLE [dbo].[HoaDons]
ADD CONSTRAINT [PK_HoaDons]
    PRIMARY KEY CLUSTERED ([SoHoaDon] ASC);
GO

-- Creating primary key on [SoHopDong] in table 'HopDongs'
ALTER TABLE [dbo].[HopDongs]
ADD CONSTRAINT [PK_HopDongs]
    PRIMARY KEY CLUSTERED ([SoHopDong] ASC);
GO

-- Creating primary key on [MaKH] in table 'KhachHangs'
ALTER TABLE [dbo].[KhachHangs]
ADD CONSTRAINT [PK_KhachHangs]
    PRIMARY KEY CLUSTERED ([MaKH] ASC);
GO

-- Creating primary key on [MaAction] in table 'LoaiActions'
ALTER TABLE [dbo].[LoaiActions]
ADD CONSTRAINT [PK_LoaiActions]
    PRIMARY KEY CLUSTERED ([MaAction] ASC);
GO

-- Creating primary key on [MaBang] in table 'LoaiBangs'
ALTER TABLE [dbo].[LoaiBangs]
ADD CONSTRAINT [PK_LoaiBangs]
    PRIMARY KEY CLUSTERED ([MaBang] ASC);
GO

-- Creating primary key on [MaController] in table 'LoaiControllers'
ALTER TABLE [dbo].[LoaiControllers]
ADD CONSTRAINT [PK_LoaiControllers]
    PRIMARY KEY CLUSTERED ([MaController] ASC);
GO

-- Creating primary key on [MaLoaiKH] in table 'LoaiKhachHangs'
ALTER TABLE [dbo].[LoaiKhachHangs]
ADD CONSTRAINT [PK_LoaiKhachHangs]
    PRIMARY KEY CLUSTERED ([MaLoaiKH] ASC);
GO

-- Creating primary key on [MaLoaiNV] in table 'LoaiNhanViens'
ALTER TABLE [dbo].[LoaiNhanViens]
ADD CONSTRAINT [PK_LoaiNhanViens]
    PRIMARY KEY CLUSTERED ([MaLoaiNV] ASC);
GO

-- Creating primary key on [MaLoaiXe] in table 'LoaiXes'
ALTER TABLE [dbo].[LoaiXes]
ADD CONSTRAINT [PK_LoaiXes]
    PRIMARY KEY CLUSTERED ([MaLoaiXe] ASC);
GO

-- Creating primary key on [MaLoTrinh] in table 'LoTrinhs'
ALTER TABLE [dbo].[LoTrinhs]
ADD CONSTRAINT [PK_LoTrinhs]
    PRIMARY KEY CLUSTERED ([MaLoTrinh] ASC);
GO

-- Creating primary key on [MaLuong] in table 'Luongs'
ALTER TABLE [dbo].[Luongs]
ADD CONSTRAINT [PK_Luongs]
    PRIMARY KEY CLUSTERED ([MaLuong] ASC);
GO

-- Creating primary key on [MaNV] in table 'NhanViens'
ALTER TABLE [dbo].[NhanViens]
ADD CONSTRAINT [PK_NhanViens]
    PRIMARY KEY CLUSTERED ([MaNV] ASC);
GO

-- Creating primary key on [MaQuyen], [MaAction] in table 'PhanQuyens'
ALTER TABLE [dbo].[PhanQuyens]
ADD CONSTRAINT [PK_PhanQuyens]
    PRIMARY KEY CLUSTERED ([MaQuyen], [MaAction] ASC);
GO

-- Creating primary key on [SoPhieuChi] in table 'PhieuChis'
ALTER TABLE [dbo].[PhieuChis]
ADD CONSTRAINT [PK_PhieuChis]
    PRIMARY KEY CLUSTERED ([SoPhieuChi] ASC);
GO

-- Creating primary key on [SoPhieuThu] in table 'PhieuThus'
ALTER TABLE [dbo].[PhieuThus]
ADD CONSTRAINT [PK_PhieuThus]
    PRIMARY KEY CLUSTERED ([SoPhieuThu] ASC);
GO

-- Creating primary key on [MaQuyen] in table 'Quyens'
ALTER TABLE [dbo].[Quyens]
ADD CONSTRAINT [PK_Quyens]
    PRIMARY KEY CLUSTERED ([MaQuyen] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [TaiKhoanNV] in table 'TaiKhoans'
ALTER TABLE [dbo].[TaiKhoans]
ADD CONSTRAINT [PK_TaiKhoans]
    PRIMARY KEY CLUSTERED ([TaiKhoanNV] ASC);
GO

-- Creating primary key on [MaThuongHieu] in table 'ThuongHieuXes'
ALTER TABLE [dbo].[ThuongHieuXes]
ADD CONSTRAINT [PK_ThuongHieuXes]
    PRIMARY KEY CLUSTERED ([MaThuongHieu] ASC);
GO

-- Creating primary key on [MaTinh] in table 'Tinh_TP'
ALTER TABLE [dbo].[Tinh_TP]
ADD CONSTRAINT [PK_Tinh_TP]
    PRIMARY KEY CLUSTERED ([MaTinh] ASC);
GO

-- Creating primary key on [MaTrangThai] in table 'TrangThaiHopDongs'
ALTER TABLE [dbo].[TrangThaiHopDongs]
ADD CONSTRAINT [PK_TrangThaiHopDongs]
    PRIMARY KEY CLUSTERED ([MaTrangThai] ASC);
GO

-- Creating primary key on [MaXe] in table 'Xes'
ALTER TABLE [dbo].[Xes]
ADD CONSTRAINT [PK_Xes]
    PRIMARY KEY CLUSTERED ([MaXe] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [MaLoaiXe] in table 'BangGias'
ALTER TABLE [dbo].[BangGias]
ADD CONSTRAINT [FK_Gia_LoaiXe]
    FOREIGN KEY ([MaLoaiXe])
    REFERENCES [dbo].[LoaiXes]
        ([MaLoaiXe])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Gia_LoaiXe'
CREATE INDEX [IX_FK_Gia_LoaiXe]
ON [dbo].[BangGias]
    ([MaLoaiXe]);
GO

-- Creating foreign key on [MaLoTrinh] in table 'BangGias'
ALTER TABLE [dbo].[BangGias]
ADD CONSTRAINT [FK_Gia_LoTrinh]
    FOREIGN KEY ([MaLoTrinh])
    REFERENCES [dbo].[LoTrinhs]
        ([MaLoTrinh])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Gia_LoTrinh'
CREATE INDEX [IX_FK_Gia_LoTrinh]
ON [dbo].[BangGias]
    ([MaLoTrinh]);
GO

-- Creating foreign key on [MaCongTy] in table 'CT_HopDong'
ALTER TABLE [dbo].[CT_HopDong]
ADD CONSTRAINT [FK_CT_HopDong_CongTy]
    FOREIGN KEY ([MaCongTy])
    REFERENCES [dbo].[CongTies]
        ([MaCongTy])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CT_HopDong_CongTy'
CREATE INDEX [IX_FK_CT_HopDong_CongTy]
ON [dbo].[CT_HopDong]
    ([MaCongTy]);
GO

-- Creating foreign key on [MaCongTy] in table 'Xes'
ALTER TABLE [dbo].[Xes]
ADD CONSTRAINT [FK_Xe_CongTy]
    FOREIGN KEY ([MaCongTy])
    REFERENCES [dbo].[CongTies]
        ([MaCongTy])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Xe_CongTy'
CREATE INDEX [IX_FK_Xe_CongTy]
ON [dbo].[Xes]
    ([MaCongTy]);
GO

-- Creating foreign key on [SoHoaDon] in table 'CT_HoaDon'
ALTER TABLE [dbo].[CT_HoaDon]
ADD CONSTRAINT [FK_CT_HoaDon_HoaDon]
    FOREIGN KEY ([SoHoaDon])
    REFERENCES [dbo].[HoaDons]
        ([SoHoaDon])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CT_HoaDon_HoaDon'
CREATE INDEX [IX_FK_CT_HoaDon_HoaDon]
ON [dbo].[CT_HoaDon]
    ([SoHoaDon]);
GO

-- Creating foreign key on [SoHopDong] in table 'CT_HoaDon'
ALTER TABLE [dbo].[CT_HoaDon]
ADD CONSTRAINT [FK_CT_HoaDon_HopDong]
    FOREIGN KEY ([SoHopDong])
    REFERENCES [dbo].[HopDongs]
        ([SoHopDong])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [SoHopDong] in table 'CT_HopDong'
ALTER TABLE [dbo].[CT_HopDong]
ADD CONSTRAINT [FK_CT_HopDong_HopDong]
    FOREIGN KEY ([SoHopDong])
    REFERENCES [dbo].[HopDongs]
        ([SoHopDong])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CT_HopDong_HopDong'
CREATE INDEX [IX_FK_CT_HopDong_HopDong]
ON [dbo].[CT_HopDong]
    ([SoHopDong]);
GO

-- Creating foreign key on [MaTaiXe] in table 'CT_HopDong'
ALTER TABLE [dbo].[CT_HopDong]
ADD CONSTRAINT [FK_CT_HopDong_NhanVien1]
    FOREIGN KEY ([MaTaiXe])
    REFERENCES [dbo].[NhanViens]
        ([MaNV])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CT_HopDong_NhanVien1'
CREATE INDEX [IX_FK_CT_HopDong_NhanVien1]
ON [dbo].[CT_HopDong]
    ([MaTaiXe]);
GO

-- Creating foreign key on [MaXe] in table 'CT_HopDong'
ALTER TABLE [dbo].[CT_HopDong]
ADD CONSTRAINT [FK_CT_HopDong_Xe]
    FOREIGN KEY ([MaXe])
    REFERENCES [dbo].[Xes]
        ([MaXe])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CT_HopDong_Xe'
CREATE INDEX [IX_FK_CT_HopDong_Xe]
ON [dbo].[CT_HopDong]
    ([MaXe]);
GO

-- Creating foreign key on [MaHinhThucThanhToan] in table 'HopDongs'
ALTER TABLE [dbo].[HopDongs]
ADD CONSTRAINT [FK_HopDong_HinhThucThanhToan]
    FOREIGN KEY ([MaHinhThucThanhToan])
    REFERENCES [dbo].[HinhThucThanhToans]
        ([MaHinhThucTT])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HopDong_HinhThucThanhToan'
CREATE INDEX [IX_FK_HopDong_HinhThucThanhToan]
ON [dbo].[HopDongs]
    ([MaHinhThucThanhToan]);
GO

-- Creating foreign key on [MaHinhThucThue] in table 'HopDongs'
ALTER TABLE [dbo].[HopDongs]
ADD CONSTRAINT [FK_HopDong_HinhThucThue]
    FOREIGN KEY ([MaHinhThucThue])
    REFERENCES [dbo].[HinhThucThues]
        ([MaHinhThuc])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HopDong_HinhThucThue'
CREATE INDEX [IX_FK_HopDong_HinhThucThue]
ON [dbo].[HopDongs]
    ([MaHinhThucThue]);
GO

-- Creating foreign key on [MaKH] in table 'HoaDons'
ALTER TABLE [dbo].[HoaDons]
ADD CONSTRAINT [FK_HoaDon_KhachHang]
    FOREIGN KEY ([MaKH])
    REFERENCES [dbo].[KhachHangs]
        ([MaKH])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HoaDon_KhachHang'
CREATE INDEX [IX_FK_HoaDon_KhachHang]
ON [dbo].[HoaDons]
    ([MaKH]);
GO

-- Creating foreign key on [MaNV] in table 'HoaDons'
ALTER TABLE [dbo].[HoaDons]
ADD CONSTRAINT [FK_HoaDon_NhanVien]
    FOREIGN KEY ([MaNV])
    REFERENCES [dbo].[NhanViens]
        ([MaNV])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HoaDon_NhanVien'
CREATE INDEX [IX_FK_HoaDon_NhanVien]
ON [dbo].[HoaDons]
    ([MaNV]);
GO

-- Creating foreign key on [MaKH] in table 'HopDongs'
ALTER TABLE [dbo].[HopDongs]
ADD CONSTRAINT [FK_HopDong_KhachHang]
    FOREIGN KEY ([MaKH])
    REFERENCES [dbo].[KhachHangs]
        ([MaKH])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HopDong_KhachHang'
CREATE INDEX [IX_FK_HopDong_KhachHang]
ON [dbo].[HopDongs]
    ([MaKH]);
GO

-- Creating foreign key on [MaLoTrinh] in table 'HopDongs'
ALTER TABLE [dbo].[HopDongs]
ADD CONSTRAINT [FK_HopDong_LoTrinh]
    FOREIGN KEY ([MaLoTrinh])
    REFERENCES [dbo].[LoTrinhs]
        ([MaLoTrinh])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HopDong_LoTrinh'
CREATE INDEX [IX_FK_HopDong_LoTrinh]
ON [dbo].[HopDongs]
    ([MaLoTrinh]);
GO

-- Creating foreign key on [MaNV] in table 'HopDongs'
ALTER TABLE [dbo].[HopDongs]
ADD CONSTRAINT [FK_HopDong_NhanVien]
    FOREIGN KEY ([MaNV])
    REFERENCES [dbo].[NhanViens]
        ([MaNV])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HopDong_NhanVien'
CREATE INDEX [IX_FK_HopDong_NhanVien]
ON [dbo].[HopDongs]
    ([MaNV]);
GO

-- Creating foreign key on [MaTrangThai] in table 'HopDongs'
ALTER TABLE [dbo].[HopDongs]
ADD CONSTRAINT [FK_HopDong_TrangThaiHopDong]
    FOREIGN KEY ([MaTrangThai])
    REFERENCES [dbo].[TrangThaiHopDongs]
        ([MaTrangThai])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HopDong_TrangThaiHopDong'
CREATE INDEX [IX_FK_HopDong_TrangThaiHopDong]
ON [dbo].[HopDongs]
    ([MaTrangThai]);
GO

-- Creating foreign key on [MaLoaiKH] in table 'KhachHangs'
ALTER TABLE [dbo].[KhachHangs]
ADD CONSTRAINT [FK_KhachHang_LoaiKH]
    FOREIGN KEY ([MaLoaiKH])
    REFERENCES [dbo].[LoaiKhachHangs]
        ([MaLoaiKH])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KhachHang_LoaiKH'
CREATE INDEX [IX_FK_KhachHang_LoaiKH]
ON [dbo].[KhachHangs]
    ([MaLoaiKH]);
GO

-- Creating foreign key on [MaController] in table 'LoaiActions'
ALTER TABLE [dbo].[LoaiActions]
ADD CONSTRAINT [FK_LoaiAction_Loaicontroller]
    FOREIGN KEY ([MaController])
    REFERENCES [dbo].[LoaiControllers]
        ([MaController])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LoaiAction_Loaicontroller'
CREATE INDEX [IX_FK_LoaiAction_Loaicontroller]
ON [dbo].[LoaiActions]
    ([MaController]);
GO

-- Creating foreign key on [MaAction] in table 'PhanQuyens'
ALTER TABLE [dbo].[PhanQuyens]
ADD CONSTRAINT [FK_PhanQuyen_LoaiAction]
    FOREIGN KEY ([MaAction])
    REFERENCES [dbo].[LoaiActions]
        ([MaAction])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PhanQuyen_LoaiAction'
CREATE INDEX [IX_FK_PhanQuyen_LoaiAction]
ON [dbo].[PhanQuyens]
    ([MaAction]);
GO

-- Creating foreign key on [MaBang] in table 'NhanViens'
ALTER TABLE [dbo].[NhanViens]
ADD CONSTRAINT [FK_NhanVien_LoaiBang]
    FOREIGN KEY ([MaBang])
    REFERENCES [dbo].[LoaiBangs]
        ([MaBang])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_NhanVien_LoaiBang'
CREATE INDEX [IX_FK_NhanVien_LoaiBang]
ON [dbo].[NhanViens]
    ([MaBang]);
GO

-- Creating foreign key on [MaLuong] in table 'LoaiNhanViens'
ALTER TABLE [dbo].[LoaiNhanViens]
ADD CONSTRAINT [FK_LoaiNhanVien_Luong]
    FOREIGN KEY ([MaLuong])
    REFERENCES [dbo].[Luongs]
        ([MaLuong])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LoaiNhanVien_Luong'
CREATE INDEX [IX_FK_LoaiNhanVien_Luong]
ON [dbo].[LoaiNhanViens]
    ([MaLuong]);
GO

-- Creating foreign key on [MaLoaiNV] in table 'NhanViens'
ALTER TABLE [dbo].[NhanViens]
ADD CONSTRAINT [FK_NhanVien_LoaiNhanVien]
    FOREIGN KEY ([MaLoaiNV])
    REFERENCES [dbo].[LoaiNhanViens]
        ([MaLoaiNV])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_NhanVien_LoaiNhanVien'
CREATE INDEX [IX_FK_NhanVien_LoaiNhanVien]
ON [dbo].[NhanViens]
    ([MaLoaiNV]);
GO

-- Creating foreign key on [MaLoaiXe] in table 'Xes'
ALTER TABLE [dbo].[Xes]
ADD CONSTRAINT [FK_Xe_LoaiXe]
    FOREIGN KEY ([MaLoaiXe])
    REFERENCES [dbo].[LoaiXes]
        ([MaLoaiXe])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Xe_LoaiXe'
CREATE INDEX [IX_FK_Xe_LoaiXe]
ON [dbo].[Xes]
    ([MaLoaiXe]);
GO

-- Creating foreign key on [MaTinh] in table 'NhanViens'
ALTER TABLE [dbo].[NhanViens]
ADD CONSTRAINT [FK_NhanVien_Tinh_TP1]
    FOREIGN KEY ([MaTinh])
    REFERENCES [dbo].[Tinh_TP]
        ([MaTinh])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_NhanVien_Tinh_TP1'
CREATE INDEX [IX_FK_NhanVien_Tinh_TP1]
ON [dbo].[NhanViens]
    ([MaTinh]);
GO

-- Creating foreign key on [MaNV] in table 'PhieuChis'
ALTER TABLE [dbo].[PhieuChis]
ADD CONSTRAINT [FK_PhieuChi_NhanVien]
    FOREIGN KEY ([MaNV])
    REFERENCES [dbo].[NhanViens]
        ([MaNV])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PhieuChi_NhanVien'
CREATE INDEX [IX_FK_PhieuChi_NhanVien]
ON [dbo].[PhieuChis]
    ([MaNV]);
GO

-- Creating foreign key on [MaNV] in table 'PhieuThus'
ALTER TABLE [dbo].[PhieuThus]
ADD CONSTRAINT [FK_PhieuThu_NhanVien]
    FOREIGN KEY ([MaNV])
    REFERENCES [dbo].[NhanViens]
        ([MaNV])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PhieuThu_NhanVien'
CREATE INDEX [IX_FK_PhieuThu_NhanVien]
ON [dbo].[PhieuThus]
    ([MaNV]);
GO

-- Creating foreign key on [MaNV] in table 'TaiKhoans'
ALTER TABLE [dbo].[TaiKhoans]
ADD CONSTRAINT [FK_TaiKhoan_NhanVien]
    FOREIGN KEY ([MaNV])
    REFERENCES [dbo].[NhanViens]
        ([MaNV])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TaiKhoan_NhanVien'
CREATE INDEX [IX_FK_TaiKhoan_NhanVien]
ON [dbo].[TaiKhoans]
    ([MaNV]);
GO

-- Creating foreign key on [MaQuyen] in table 'PhanQuyens'
ALTER TABLE [dbo].[PhanQuyens]
ADD CONSTRAINT [FK_PhanQuyen_Quyen]
    FOREIGN KEY ([MaQuyen])
    REFERENCES [dbo].[Quyens]
        ([MaQuyen])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [MaQuyen] in table 'TaiKhoans'
ALTER TABLE [dbo].[TaiKhoans]
ADD CONSTRAINT [FK_TaiKhoan_Quyen]
    FOREIGN KEY ([MaQuyen])
    REFERENCES [dbo].[Quyens]
        ([MaQuyen])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TaiKhoan_Quyen'
CREATE INDEX [IX_FK_TaiKhoan_Quyen]
ON [dbo].[TaiKhoans]
    ([MaQuyen]);
GO

-- Creating foreign key on [MaThuongHieu] in table 'Xes'
ALTER TABLE [dbo].[Xes]
ADD CONSTRAINT [FK_Xe_ThuongHieuXe]
    FOREIGN KEY ([MaThuongHieu])
    REFERENCES [dbo].[ThuongHieuXes]
        ([MaThuongHieu])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Xe_ThuongHieuXe'
CREATE INDEX [IX_FK_Xe_ThuongHieuXe]
ON [dbo].[Xes]
    ([MaThuongHieu]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------