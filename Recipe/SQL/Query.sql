Create table DanhMuc
(
	MADM int not null identity(1,1) primary key,
	TenDM nvarchar(30),
)

Create table SanPham
(
	MaSP int not null identity primary key,
	MADM int,
	TenSp varchar(30),
	Video nvarchar(Max),
	LuotXem int,
	yeuThich bit,
	MoTa nvarchar(Max),
	AnhDaiDien varchar(max),
	NguyenLieu nvarchar(max)
)

create table HinhAnh
(
	MaSP int,
	HinhAnh varchar(Max),

)

create table CTSP
(
	MaSP int,
	STT int,
	Buoclam nvarchar(max)
)

alter table dbo.SanPham add constraint FK_SanPham_DanhMuc foreign key (MADM) references dbo.DanhMuc(MADM) 
alter table dbo.HinhAnh add constraint FK_HinhAnh_SanPham foreign key (MaSP) references dbo.SanPham(MaSP) 
alter table dbo.CTSP add constraint FK_CTSP_SanPham foreign key (MaSP) references dbo.SanPham(MaSP) 

alter table CTSP drop constraint FK_CTSP_SanPham
drop table CTSP
