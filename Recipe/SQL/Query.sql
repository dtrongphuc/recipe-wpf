Create table DanhMuc
(
	MaDM int not null identity(1,1) primary key,
	TenDM nvarchar(30),
)

Create table SanPham
(
	MaSP int not null identity primary key,
	MADM int,
	TenSp nvarchar(50),
	Video varchar(Max),
	LuotXem int,
	yeuThich bit,
	MoTa nvarchar(Max),
	AnhDaiDien varchar(max),
	NguyenLieu nvarchar(max),
	SoThanhPhan int,
	ThoiGian nvarchar(10)
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

	constraint PK_CTSP
	primary key (MaSp,STT)
)

alter table dbo.SanPham add constraint FK_SanPham_DanhMuc foreign key (MADM) references dbo.DanhMuc(MADM) 
alter table dbo.HinhAnh add constraint FK_HinhAnh_SanPham foreign key (MaSP) references dbo.SanPham(MaSP) 
alter table dbo.CTSP add constraint FK_CTSP_SanPham foreign key (MaSP) references dbo.SanPham(MaSP) 

alter table SanPham drop constraint FK_SanPham_DanhMuc
drop table CTSP



-- thêm danh mục 
INSERT INTO DanhMuc VALUES  ("Món Xào"), 
							("Món Chiên"), 
							("Món Kho"), 
							("Món Canh")
GO

INSERT INTO CTSP VALUES 
(1, 1, N'Ngâm sò ra thau rửa nhiều lần cho sạch, chuẩn bị các nguyên liệu phụ sau đó.'),
(1, 2, N'Cho dầu vào chảo, cho sả, ớt, gừng, sa tế, hành tím, 2 muỗng dầu hào, 2 muỗng đường vào xào thơm,cho cà rốt vào xào chín, sau đó cho tỏi vào đảo khoản 3 phút tiếp đó cho 1 ly nước lọc vào, cho vào 3 muỗng càphe rượu vào nấu sôi lần nữa, bột nêm vừa ăn, sau đó cho sò lụa vào đảo đều thấm gia vị vào, nấu khoản 5 phút lửa lớn cho sò mở đều, tắt bếp cho hành hoa hoặc rau thơm vào nhấc ra xơi.'),
(2, 1, N'Rau nhặt lấy cọng non, rửa sạch. Tỏi lột vỏ cắt lát mỏng. Cho 2m canh dầu vào chảo, phi tỏi cho thơm'),		
(2, 2, N'Tỏi vừa vàng cho rau vào đảo đều với lửa lớn, để tránh rau bị đỏ. Nêm gia vị cho vừa miệng, rau mềm tắt bếp. Vắt tý chanh và cắt ớt trộn đều vào rau'),

(3, 1, N'Cơm nguội bóp cho tơi sau đó đập hết 3 quả trứng vịt vào bóp cho hạt cơm rời ra hết bỏ bột nghệ vào bóp cùng cho đều lấy màng bọc thực phẩm bọc lại để vào tủ lạnh.'),
(3, 2, N'Carot bào vỏ xắt hạt lựu,đậu que cắt khúc nhỏ,bắc nồi nước lên bếp thêm chút muối bỏ carot vào luộc,khi carot gần chín thì bỏ đậu que vào luộc chín vớt ra rửa qua nước lạnh để ráo,xúc xích+lạp xưởng cắt hạt lựu'),
(3, 3, N'Bắc chả lên bếp cho dầu ăn vào phi thơm tỏi bỏ xúc xích+lạp xưởng vào đảo đều sau khi lạp xưởng săn lại thì bỏ đậu que+carot đã luộc vào xào cùng,xào chín đổ ra tô bỏ qua 1 bên'),
(3, 4, N'Lấy cơm từ trong tủ lạnh bóp lại 1 lần nữa cho hạt cơm tơi ra,phi thơm tỏi bỏ cơm vào chiên vặn nhỏ lửa đảo liên tục cho hạt cơm tơi ra, kg bị kết dính lại với nhau khi cơm tơi+ chín theo ý thích thì bỏ carot+đậu que+xúc xích+lạp xưởng vào đảo thêm 5p tắt bếp,múc ra dĩa trang trí với hành ngò xắt nhỏ,món này ăn kèm xì dầu ớt rất ngon nên mình kg nêm gia vị trong lúc chiên')

GO

-- Hinh anh 
INSERT INTO HinhAnh VALUES (1, 'Resource/Images/Product/BL_So_Lua_Xao_1.jpg'),
(1, 'Resource/Images/Product/BL_So_Lua_Xao_2.jpg'),
(1, 'Resource/Images/Product/BL_So_Lua_Xao_3.jpg'),
(1, 'Resource/Images/Product/BL_So_Lua_Xao_4.jpg'),
(1, 'Resource/Images/Product/BL_So_Lua_Xao_5.jpg'),

(2, 'Resource/Images/Product/BL_Rau_Muong_Xao_Toi_1.jpg'),
(2, 'Resource/Images/Product/BL_Rau_Muong_Xao_Toi_2.jpg'),
(2, 'Resource/Images/Product/BL_Rau_Muong_Xao_Toi_3.jpg'),
(2, 'Resource/Images/Product/BL_Rau_Muong_Xao_Toi_4.jpg'),
(2, 'Resource/Images/Product/BL_Rau_Muong_Xao_Toi_5.jpg'),

(3, 'Resource/Images/Product/BL_Com_Chien_1.jpg'),
(3, 'Resource/Images/Product/BL_Com_Chien_2.jpg'),
(3, 'Resource/Images/Product/BL_Com_Chien_2.jpg'),
(3, 'Resource/Images/Product/BL_Com_Chien_3.jpg'),
(3, 'Resource/Images/Product/BL_Com_Chien_4.jpg')
GO


-- thêm dữ liệu cho món xào

INSERT INTO SanPham VALUES 
							(1, N'Sò lụa xào sa tế tỏi', N'https://www.youtube.com/watch?v=ofJHMtUcg4k',
							55, 1, NULL, N'Resource/Images/Product/So_Lua_Xao.jpg', 
							N'1 kg sò lụa - 4 cây Sả - 1/2 hủ Sa tế tôm - 1 củ cà rốt - 2 củ tỏi lớn - Gừng, hành tím, rau thơm, hành lá - Bột nêm, dầu hào, đường, rượu', 7, 20),

							(1, N'Rau muống xào tỏi', N'https://www.youtube.com/watch?v=Fvzz4bZTjRc',
							70, 1, N'Rau muống ở đây thật đắc, mắc hơn cả thịt cá, gần $7 một bó bé tý, nhưng tại con gái thích món ăn này, nên mẹ mua xào ngay với tỏi.',
							'Resource/Images/Product/Avatar_Rau_Muong_Xao_Toi.jpg',
							N'1 bó rau muống - 1 củ tỏi - Gia vị, chanh ớt', 3, 10),

							(2, N'Cơm chiên', 'https://www.youtube.com/watch?v=6u5wA6YNw5Q',
							100, 0, N'Món ăn trưa', 'Avatar_Com_Chien.jpg',
							N'Cơm nguội 1 tô to - 3 quả trứng vịt - 1/2 muỗng cafe bột nghệ - Carot - Đậu que - Xúc xích - Lạp xưởng - Hành ngò xắt nhỏ - Tiêu - Tỏi', 10, 15)


