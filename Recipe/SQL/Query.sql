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
--(1, 1, N'Ngâm sò ra thau rửa nhiều lần cho sạch, chuẩn bị các nguyên liệu phụ sau đó.'),
--(1, 2, N'Cho dầu vào chảo, cho sả, ớt, gừng, sa tế, hành tím, 2 muỗng dầu hào, 2 muỗng đường vào xào thơm,cho cà rốt vào xào chín, sau đó cho tỏi vào đảo khoản 3 phút tiếp đó cho 1 ly nước lọc vào, cho vào 3 muỗng càphe rượu vào nấu sôi lần nữa, bột nêm vừa ăn, sau đó cho sò lụa vào đảo đều thấm gia vị vào, nấu khoản 5 phút lửa lớn cho sò mở đều, tắt bếp cho hành hoa hoặc rau thơm vào nhấc ra xơi.'),
--(2, 1, N'Rau nhặt lấy cọng non, rửa sạch. Tỏi lột vỏ cắt lát mỏng. Cho 2m canh dầu vào chảo, phi tỏi cho thơm'),		
--(2, 2, N'Tỏi vừa vàng cho rau vào đảo đều với lửa lớn, để tránh rau bị đỏ. Nêm gia vị cho vừa miệng, rau mềm tắt bếp. Vắt tý chanh và cắt ớt trộn đều vào rau'),

--(3, 1, N'Cơm nguội bóp cho tơi sau đó đập hết 3 quả trứng vịt vào bóp cho hạt cơm rời ra hết bỏ bột nghệ vào bóp cùng cho đều lấy màng bọc thực phẩm bọc lại để vào tủ lạnh.'),
--(3, 2, N'Carot bào vỏ xắt hạt lựu,đậu que cắt khúc nhỏ,bắc nồi nước lên bếp thêm chút muối bỏ carot vào luộc,khi carot gần chín thì bỏ đậu que vào luộc chín vớt ra rửa qua nước lạnh để ráo,xúc xích+lạp xưởng cắt hạt lựu'),
--(3, 3, N'Bắc chả lên bếp cho dầu ăn vào phi thơm tỏi bỏ xúc xích+lạp xưởng vào đảo đều sau khi lạp xưởng săn lại thì bỏ đậu que+carot đã luộc vào xào cùng,xào chín đổ ra tô bỏ qua 1 bên'),
--(3, 4, N'Lấy cơm từ trong tủ lạnh bóp lại 1 lần nữa cho hạt cơm tơi ra,phi thơm tỏi bỏ cơm vào chiên vặn nhỏ lửa đảo liên tục cho hạt cơm tơi ra, kg bị kết dính lại với nhau khi cơm tơi+ chín theo ý thích thì bỏ carot+đậu que+xúc xích+lạp xưởng vào đảo thêm 5p tắt bếp,múc ra dĩa trang trí với hành ngò xắt nhỏ,món này ăn kèm xì dầu ớt rất ngon nên mình kg nêm gia vị trong lúc chiên'),
-----next
(4, 1, N'Rửa sạch cổ gà (để da, bỏ da tùy người) bỏ da sau đó trộn với ngũ vị hương, muốn và ướp trong 30p'),
(4, 2, N'Sau khi ướp cho bột năng vào đảo đều với cổ gà'),
(4, 3, N'Bắt dầu ăn sôi lên và bỏ cổ ga vào chiên cho tới khi vàng giòn rụm vớt ra giấy thấm dầu'),
(4, 4, N'Sau đó bắm tỏi, ớt, hành tím đảo trên chảo nóng cho xém 1 chút và đổ gà vào đảo nhanh trong 1-2p lấy ra là được( lưu ý nhà có trẻ nhỏ thì không làm bước này, chúng ta làm nước chấm không quá mặn và chấm ăn'),
(4, 5, N'Chúc món ăn ngon (mình lại quên chụp thành quả) món này ăn kèm rau sống các loại'),

(5, 1, N'Rửa sạch sườn non bằng nước muối để ráo. Lấy nồi cho dầu ăn vào cho nóng rồi cho tỏi đập giập vào tao vàng cho thơm,kế tiếp cho sườn non vào đảo liên tục cho săn.'),
(5, 2, N'Hoà 1/2 chén mắm+3m canh đường vàng+ 2m cf bột ngọt +1mcf tiêu rồi cho vào nồi thịt đảo tiếp rồi cho 2 chén nước để nước xắp cắp bề mặt nồi thịt kho,để sôi vài dạo rồi hạ lửa nhỏ để thịt sôi riu riu kho cho đến khi keo sệt lại và chuyển màu nâu vàng. Lúc mùi thơm ngào ngạt tỏa ra...(ái chà đói bụng quá thôi)'),
(5, 3, N'Múc ra dĩa ăn với cơm nóng...món này hao cơm lắm luôn.Nước chấm rau muống luộc nhé.'),

(6, 1, N'Cá làm sạch cắt bỏ đầu đuôi. Thịt ba chỉ (ba rọi) lựa phần nhiều mỡ, thái lát hơi dày.'),
(6, 2, N'Cho 1 muỗng canh đường thốt nốt hoặc đường vành vào nồi, để lửa vừa 6/9 cho đường chảy ra, khi vừa chuyển màu cánh gián đậm thì lấy nồi ra khỏi bếp và cho thịt vào, đảo đều để thịt thấm đường, đường không bị cháy.'),
(6, 3, N'Để thịt lót dưới đáy nồi rồi xếp cá lên trên. Cho vào: 5 muỗng canh nước mắm, ít tiêu xay, vài trái ớt đỏ đập dập hoặc để nguyên trái nếu không ăn cay. Ướp 30’.'),
(6, 4, N'Mở lửa lớn cho nước ướp cá sôi bùng lên, cho 1/2 nước trái dừa vào, nước sôi rồi hạ xuống 6/9, để 5’ cho cá săn bên ngoài lại rồi hạ xuống 3/9, để liu riu cho cá thấm đều. Trong lúc kho phải mở nắp nồi và tuyệt đối không đảo/lật cá để giữ được lớp phấn óng ánh trên mình cá thì mới đẹp. Chỉ thỉnh thoảng lắc nhẹ nồi. Sau 30’ tắt bếp, gọi là kho 1 lửa. Nếu hôm sau mới ăn thì để nguội rồi cất cả nồi cá vào tủ lạnh, hôm sau kho thêm lửa nữa'),
(6, 5, N'Kho cá là phải 2 lửa mới ngon: bắt nồi cá đã kho 1 lửa lên bếp, nấu sôi rồi hạ lửa 5/9, nêm lại xem có vừa miệng chưa, thích đậm đà hơn thì nêm thêm nước mắm, nhưng nhớ trừ hao vì khi sệt nước cá sẽ mặn thêm chút nữa. Bạn cứ mở nắp nồi, kho lửa vừa như vậy đến khi thấy nước sền sệt là được. Khi gần được, bạn 1 muỗng canh dầu ăn lên cá cho bóng đẹp rồi 5’ sau tắt bếp.'),

(7, 1, N'Cà tím xào thịt: phi thơm hành khô và tỏi.sau đó cho cà tím vào đảo đều tay tới khi cà tai tái thì nêm ít bột nêm, dầu hào vừa khẩu vị. Cuối cùng rắc hành lá lên là xong.👌'),
(7, 2, N'Canh kim chi: thịt nên luộc qua 1 lần nước. Roi vớt thịt ra giữ lại nước luộc. Sau đó bắc chảo dầu lên đun sôi đổ thịt vào đảo khoảng 2’(đảo vs mỡ trc thì khi ninh vs kim chi thịt sẽ nhanh nhừ) rồi đổ kim chi vào đảo cùng với thịt.'),
(7, 3, N'Đảo đều tay khoảng 1-2’ xong đổ nước luộc thịt và chút nước ép kim chi vào ninh tới khi kim chi và thịt mềm. giảm nhiệt đun sôi trong 15-20’.'),
(7, 4, N'Cuối cùng đổ đậu phụ,bột nêm, chút nước mắm vừa đủ. Kim chi cũng hơi mặn do đó mắm chỉ nên cho vừa phải. Đun khoảng 5 phút thì tắt bếp.'),

(8, 1, N'Cắt bỏ 2 đầu của quả khổ qua (mướp đắng), cắt khúc dài vừa ăn, sử dụng thìa nhỏ để loại bỏ phần ruột ở trong. Ngâm khổ qua với nước muối pha loãng khoảng 10 phút rồi xả sạch để ráo, Hành lá nhặt rửa sạch thái nhỏ để riêng. Hành lá nhặt rửa sạch thái nhỏ để riêng. Trứng vịt đập lấy nhân để riêng ra bát. Hành khô, tỏi bóc vỏ và băm nhuyễn.'),
(8, 2, N'Cho thịt xay nhuyễn trộn đều cùng các loại gia vị gồm tỏi , hành băm nhuyễn với muối, bột ngọt, nước mắm sao cho vừa ăn. Lưu ý để nhân được nhuyễn bạn có thể chọn thịt dính chút mỡ để nhân có độ ngậy, mềm và mịn. Sau đó bạn cho mộc nhĩ, trứng vịt vào trộn đều. Bạn nhồi chặt nhân vào ruột trái khổ qua.'),
(8, 3, N' Cho nước vào nồi sao cho vừa ăn rồi đun sôi, sau đó nêm nếm gia vị muối, mắm, đường, nấm hương sao cho vừa ăn. Đặt khúc khổ qua nhồi thịt đậy vung nấu trong 20 phút đến khi chín mềm thì tắt bếp. Khi chín bạn cho ra tô rồi trang trí với hành lá cắt nhỏ cùng rau mùi rắc tiêu lên trên để thưởng thức.'),

(9, 1, N'Rửa sạch cá mú chỉ cắt vây và đuôi,để nguyên vảy khi chiên vảy sẽ xù lên trông rất ngon. Cắt đôi con cá,chiên khúc đuôi cá.'),
(9, 2, N'Bắt chảo cho dầu cho nóng rồi cho 1m cf muối vào xong mới cho khúc đuôi cá vào chiên giòn.Để lửa lớn dầu thật nóng thì vảy cá mới xù bung lên.Cá vàng, lật mặt cá lại chiên giòn mặt kia.Cá chín giòn tắt bếp vớt cá ra,làm 1 chén mắm ngọt ăn với cá(1:1:1 tức 1m canh mắm +1m canh đường + 1m canh nước tỏi ớt xay nhuyễn)'),
(9, 3, N'Chuẩn bị thưởng thức thôi các bạn')

GO

-- Hinh anh 
INSERT INTO HinhAnh VALUES 
--(1, 'Resource/Images/Product/BL_So_Lua_Xao_1.jpg'),
--(1, 'Resource/Images/Product/BL_So_Lua_Xao_2.jpg'),
--(1, 'Resource/Images/Product/BL_So_Lua_Xao_3.jpg'),
--(1, 'Resource/Images/Product/BL_So_Lua_Xao_4.jpg'),
--(1, 'Resource/Images/Product/BL_So_Lua_Xao_5.jpg'),

--(2, 'Resource/Images/Product/BL_Rau_Muong_Xao_Toi_1.jpg'),
--(2, 'Resource/Images/Product/BL_Rau_Muong_Xao_Toi_2.jpg'),
--(2, 'Resource/Images/Product/BL_Rau_Muong_Xao_Toi_3.jpg'),
--(2, 'Resource/Images/Product/BL_Rau_Muong_Xao_Toi_4.jpg'),
--(2, 'Resource/Images/Product/BL_Rau_Muong_Xao_Toi_5.jpg'),

--(3, 'Resource/Images/Product/BL_Com_Chien_1.jpg'),
--(3, 'Resource/Images/Product/BL_Com_Chien_2.jpg'),
--(3, 'Resource/Images/Product/BL_Com_Chien_2.jpg'),
--(3, 'Resource/Images/Product/BL_Com_Chien_3.jpg'),
--(3, 'Resource/Images/Product/BL_Com_Chien_4.jpg'),
----next

(4, 'Resource/Images/Product/BL_GaChien_1.jpg'),
(4, 'Resource/Images/Product/BL_GaChien_2.jpg'),
(4, 'Resource/Images/Product/BL_GaChien_3.jpg'),
(4, 'Resource/Images/Product/BL_GaChien_4.jpg'),

(5, 'Resource/Images/Product/BL_SuonKho_1.jpg'),
(5, 'Resource/Images/Product/BL_SuonKho_2.jpg'),
(5, 'Resource/Images/Product/BL_SuonKho_3.jpg'),
(5, 'Resource/Images/Product/BL_SuonKho_4.jpg'),
(5, 'Resource/Images/Product/BL_SuonKho_5.jpg'),

(6, 'Resource/Images/Product/BL_CaLocKho_1.jpg'),
(6, 'Resource/Images/Product/BL_CaLocKho_2.jpg'),
(6, 'Resource/Images/Product/BL_CaLocKho_3.jpg'),
(6, 'Resource/Images/Product/BL_CaLocKho_4.jpg'),
(6, 'Resource/Images/Product/BL_CaLocKho_5.jpg'),
(6, 'Resource/Images/Product/BL_CaLocKho_6.jpg'),
(6, 'Resource/Images/Product/BL_CaLocKho_7.jpg'),
(6, 'Resource/Images/Product/BL_CaLocKho_8.jpg'),

(7, 'Resource/Images/Product/BL_CanhHanQuoc_1.jpg'),
(7, 'Resource/Images/Product/BL_CanhHanQuoc_2.jpg'),
(7, 'Resource/Images/Product/BL_CanhHanQuoc_3.jpg'),
(7, 'Resource/Images/Product/BL_CanhHanQuoc_4.jpg'),
(7, 'Resource/Images/Product/BL_CanhHanQuoc_5.jpg'),

(8, 'Resource/Images/Product/BL_CanhKhoQua_1.jpg'),
(8, 'Resource/Images/Product/BL_CanhKhoQua_2.jpg'),
(8, 'Resource/Images/Product/BL_CanhKhoQua_3.jpg'),


(9, 'Resource/Images/Product/BL_CaChienXu_1.jpg'),
(9, 'Resource/Images/Product/BL_CaChienXu_2.jpg'),
(9, 'Resource/Images/Product/BL_CaChienXu_3.jpg'),
(9, 'Resource/Images/Product/BL_CaChienXu_4.jpg')
GO


-- thêm dữ liệu cho món xào

INSERT INTO SanPham VALUES 
							--(1, N'Sò lụa xào sa tế tỏi', N'https://www.youtube.com/watch?v=ofJHMtUcg4k',
							--55, 1, NULL, N'Resource/Images/Product/So_Lua_Xao.jpg', 
							--N'1 kg sò lụa - 4 cây Sả - 1/2 hủ Sa tế tôm - 1 củ cà rốt - 2 củ tỏi lớn - Gừng, hành tím, rau thơm, hành lá - Bột nêm, dầu hào, đường, rượu', 7, 20),

							--(1, N'Rau muống xào tỏi', N'https://www.youtube.com/watch?v=Fvzz4bZTjRc',
							--70, 1, N'Rau muống ở đây thật đắc, mắc hơn cả thịt cá, gần $7 một bó bé tý, nhưng tại con gái thích món ăn này, nên mẹ mua xào ngay với tỏi.',
							--'Resource/Images/Product/Avatar_Rau_Muong_Xao_Toi.jpg',
							--N'1 bó rau muống - 1 củ tỏi - Gia vị, chanh ớt', 3, 10),

							--(2, N'Cơm chiên', 'https://www.youtube.com/watch?v=6u5wA6YNw5Q',
							--100, 0, N'Món ăn trưa', 'Avatar_Com_Chien.jpg',
							--N'Cơm nguội 1 tô to - 3 quả trứng vịt - 1/2 muỗng cafe bột nghệ - Carot - Đậu que - Xúc xích - Lạp xưởng - Hành ngò xắt nhỏ - Tiêu - Tỏi', 10, 15),
							----next
							(2, N'Cổ gà ướp ngũ vị hương chiên giòn', 'https://www.youtube.com/watch?v=YRXkcQocFWo',
							1100, 1, N'Bữa ăn thường ngày', 'Resource/Images/Product/Avatar_GaChien.jpg',
							N'1/2 con cá mú', 1, 20),

							(2, N'Cá mú chiên xù', 'https://www.youtube.com/watch?v=qCeIOfgazO8',
							850, 1, N'Bữa giờ ở NT đang giải cứu cá mú mọi người ạ....ủng hộ các bác nông dân thôi,mà cũng không nghĩ ra món gì mới mẻ vậy thì làm đơn giản nhất cá mú chiên xù', 'Resource/Images/Product/Avatar_CaChienXu.jpg',
							N'0.5 kg cổ gà - 1 thìa ngũ vị hương - 3 nhánh tỏi, 2 củ hành tím, 1 trái ớt, tiêu xay - 3 thìa bột năng - 1/2 thìa bột canh hoặc muối', 5, 45),

							(3, N'Sườn non kho tiêu', 'https://www.youtube.com/watch?v=aqXBFIq1uUA',
							760, 1, N'Trưa nay mình mới làm cho con gái,sườn kho mình kho ngọt ngọt thơm ngon nên con rất thích',
							'Resource/Images/Product/Avatar_SuonKho.jpg',
							N'1/2 kg sườn non - Mắm, tiêu, bột ngọt, đường cát vàng', 5, 30),

							(3, N'Cá nục kho thịt ba chỉ kiểu quê', 'https://www.youtube.com/watch?v=hLg3KPDD3go',
							1200, 0, N'Ngày xưa bà nội mình hay kho một nồi cá nục to với thịt ba chỉ nhiều mỡ, kho một lúc cả ký. Lúc còn nhỏ chẳng bao giờ ăn, thấy món này chả có gì hấp dẫn, vậy mà giờ lại thấy ngon, trời mưa lâm râm ăn cá kho cơm nóng còn gì bằng ;)',
							'Resource/Images/Product/Avatar_CaLocKho.jpg',
							N'500 g cá nục suôn - 100 g thịt ba chỉ - 1/2 trái Nước dừa', 3, 30),


							(4, N'Cà tím xào thịt, canh kim chi(김치찌개)', 'https://www.youtube.com/watch?v=_F_oXWWFeHs',
							900, 1, NULL,
							'Resource/Images/Product/Avatar_CanhHanQuoc.jpg',
							N'Thịt ba chỉ - Kim chi đã chín(kimchi chua roi) - Đậu phụ - Cà tím - Tỏi, hành khô, nêm,hành lá, dầu hào', 5, 45),

							(4, N'Canh mướp đắng dồn thịt', 'https://www.youtube.com/watch?v=Vlrz9gm1oTw',
							2000, 1, N'Món này ăn vào những ngày hè rất ngon',
							'Resource/Images/Product/Avatar_CanhKhoQua.jpg',
							N'2 quả Mướp đắng bỏ ruột cắt khoan tròn vừa ăn - 2 lạng Thịt lợn xay nhỏ - 3 tai Mọc nhĩ, ngâm nở thái nhỏ vụn - 3 cái Nấm hương ngâm thái nhỏ vụn - nửa thanh Đậu - Gia vị, mắm, muối, tiêu, hành tùy khẩu vị - Nấm kim châm nửa gói rửa sạch thái làm 5 cho nhỏ - Hành lá bằm nhỏ cả phần trắng và phần lá xanh', 7, 60)
GO

SELECT * FROM CTSP WHERE MaSP=1 ORDER BY STT
select * from HinhAnh where MaSP=1