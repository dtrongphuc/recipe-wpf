
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
	yeuThich INT,
	MoTa nvarchar(Max),
	AnhDaiDien varchar(max),
	NguyenLieu nvarchar(max),
	SoThanhPhan int,
	ThoiGian int
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

ALTER TABLE CTSP DROP CONSTRAINT FK_CTSP_SanPham
DROP TABLE HinhAnh

-- thêm danh mục 
INSERT INTO DanhMuc VALUES  (N'Món Xào'), 
							(N'Món Chiên'), 
							(N'Món Kho'), 
							(N'Món Canh')
GO
select* from SanPham
--them món ăn
INSERT INTO SanPham
VALUES	
--BATDAU
--XÀO
--1
	(1, N'Nuôi xào rau củ', 'https://www.youtube.com/watch?v=kDFLmMe6i0o',
		100, 0, N'Cách làm nui xào xúc xích đơn giản thơm ngon, nui hay còn gọi là mì ống vừa dễ tìm mua vừa có thể làm được nhiều món ngon, hôm nay thì mình sẽ xào nui với xúc xích nhé các bạn, rất là ngon và nhanh gọn cho 1 bữa sáng cùng gia đình ^^',
		'Resource/Images/Product/Avatar_CanhHanQuoc.jpg',
		N'Cà rốt\n Nuôi gạo\n Đậu phụ - Rau cải\n Nấm đông cô\n Ớt chuông\n Dầu hào, nước tương\n', 4, 30),
--2
	(1, N'Thịt bò xào măng & ớt chuông', 'youtube.com/watch?v=sBxg_TAy85w',
		2005, 1, N'Thịt bò có nhiều cách để xào, xào cùng dưa leo thì ăn nhiều cũng chán nên mình tìm thêm vài công thức khác để xào thịt bò ngon và lạ miệng hơn. Hôm nay mình chia sẻ với mọi người công thức thịt bò xào với măng và ớt chuông nhé.',
		'Resource/Images/Product/Avatar_ThitBoXaoMang.jpg',
		N'200 g thịt bò\n 200 g măng ngâm\n 1 quả ớt chuông\n 1 lòng trắng trứng gà\n Bột năng, dầu hào\n Gốc hành lá, gừng\n Gia vị: muối, tiêu\n Nước lọc\n', 8, 40),

--3	
	(1, N'Súp lơ xào trứng (gà, cút) và cá (Keto)', 'https://www.youtube.com/watch?v=rgRI8ooRxBU',
		1201, 0, N'Hôm nay mình chia sẻ đến các bạn món trứng chiên bông cải xanh, món này ăn có vị béo của trứng, giòn giòn của bông cải xanh, thơm của hành phi..rất giàu dinh dưỡng, mà cách nấu cũng nhanh.!',
		'Resource/Images/Product/Avatar_SupLoXaoTrung.jpg',
		N'Xà lách\n Cà chua bi\n Dưa leo ăn kèm\n Muối, tiêu, chút tương ớt, gia vị.', 4, 18),

--4
	(1, N'Hạt sen xào bắp nấm', 'https://www.youtube.com/watch?v=v-4uM-5MK7I',
		395, 0, N'Nếu đã chán ngấy những món ăn từ thịt, cá thì món HẠT SEN XÀO NẤM CHAY mà hôm nay TasteShare chia sẻ là món ăn vô cùng thơm ngon và thích hợp để chống ngấy đấy. Đây là món ăn thích hợp để bồi bổ sức khỏe. Bạn cũng không cần mất quá nhiều thời gian để nấu món ăn này đâu nhé. Món ăn này không chỉ ăn ngon, dưỡng thần mà còn hỗ trợ tăng khí huyết, ngủ ngon và phục hồi sức khỏe nữa đấy nhé. Chúc gia đình bạn ngon miệng!',
		'Resource/Images/Product/Avatar_HatSenXao.jpg',
		N'Hạt sen tươi\n Bắp ngọt\n Nấm linh chi (nấm thuỷ tiên hoặc nấm đông cô tươi)\n Hạt nêm chay, muối\n Rau mùi ta (ngò rí)', 5, 20),

--5
	(1, N'Ức gà xào', 'https://www.youtube.com/watch?v=sAUzJbncEdo',
		3501, 1, N'Mấy nay quá bận ăn uống thất thường cảm giác không thoả mái tẹo nào. Thôi thì cố gắng chút thời gian nấu ăn thôi à',
		'Resource/Images/Product/Avatar_UcGaXao.jpg',
		N'100 gr ức gà\n 100 gr Bông cải\n 50 gr ớt chuông\n Tỏi, tiêu, nước tương, xíu muối', 4, 30),

--CHIEN
--6
(2, N'Cơm chiên thái lan cay nồng', 'https://www.youtube.com/watch?v=p14AwGlbMQ4',
		5000, 1, N'Có những ngày mưa dai ẩm ướt, nằm nhà với cái bụng đói meo nhưng lại ngại phải ra đường vì mưa.. Và thế là lại lục đục xuống bếp để làm món cơm chiên thái lan cay nồng đậm vị, cực kì thích hợp cho những ngày mưa lạnh lẽo!!!',
		'Resource/Images/Product/Avatar_ComChienThaiLan.jpg',
		N'3 chén cơm trắng\n 100 g thịt băm\n 100 g rau củ hỗn hợp cắt hạt lựu (bao gồm bắp mỹ, đậu que, đậu hà lan, cà rốt)\n Dầu hào, hạt nêm nấm hương, dầu màu điều, dầu mè, tiêu, muối, đường, bột ngọt\n Trứng vịt\n Hành tím và tỏi băm\n Bột ớt, bột cà ri, bột tỏi', 7, 30),

--7
(2, N'Cánh gà chiên mắm', 'https://www.youtube.com/watch?v=NiGSU1hUZRg',
		5000, 0, N'Cánh gà chiên mắm có vị mằn mặn của nước mắm, vị ngọt của đường hòa quyện với mùi thơm của thịt gà chiên và tỏi thì đây là món ăn mà ăn với cơm hay dùng không cũng đều hợp. Ngoài ra, cách chế biến món này cũng không quá cầu kỳ, nguyên liệu lại đơn giản, có sẵn trong gian bếp của nhiều gia đình hoặc cũng dễ tìm mua ở các chợ, siêu thị gần nhà.',
		'Resource/Images/Product/Avatar_CanhGaChienNcMam.jpg',
		N'Cánh gà: 4 – 5 cánh.\n Tỏi: 2 củ\n Gừng, ớt tươi: 1 củ\n Rượu trắng, muối hạt\n Trứng vịt\n Gia vị: nước mắm, bột ngọt, hạt tiêu, dầu ăn.', 5, 20),

--8
(2, N'khoai tây que', 'https://www.youtube.com/watch?v=NiGSU1hUZRg',
		4500, 1, N'Hễ cuối tuần là con tôi đòi mẹ làm khoai tây que cho ăn vì cả 2 đứa đều thích mê',
		'Resource/Images/Product/Avatar_KhoaiTayQueChien.png',
		N'350g khoai tây\n 30g bột gạo\n 60g bột bắp\n 25g bơ (1 muỗng canh)\n Hành ngò băm nhuyễn', 5, 20),

--9
(2, N'Thịt viên chiên', 'https://www.youtube.com/watch?v=gXJwWngPEeM',
		4500, 0, N'Thịt viên mà thơm ngon thế này thì nhất định phải học cách làm ngay thôi! Từng miếng thịt viên thơm mềm đậm đà mà lại rất dễ làm. Chỉ với chút sáng tạo nhỏ là bạn đã có ngay một món thịt viên lạ miệng cực kì rồi đấy!',
		'Resource/Images/Product/Avatar_ThitVienChien.jpg',
		N'200g thịt băm\n 3 thìa canh yến mạch\n 3 thìa canh bột thì là\n 1 thìa canh vừng đen\n 3 thìa cà phê ngũ vị hương, 30ml nước tương, 15g đường cát, 2g muối, một ít dầu ăn', 5, 30),

--10
(2, N'Thịt chiên giòn', 'https://www.youtube.com/watch?v=koPXXsAI-x4',
		4500, 1, N'Thịt chiên giòn bên ngoài, bên trong vẫn giữ độ ẩm mềm, hoà cùng xốt chua ngọt kích thích vị giác vô cùng!',
		'Resource/Images/Product/Avatar_ThitChienGion.png',
		N'200g thịt băm400g thịt heo (dùng phần cốt lết hoặc thịt dăm)\n 1/4 trái ớt chuông xanh\n 1/4 trái ớt chuông đỏ\n Bột chiên giòn, bột chiên xù, bột năng\n Trứng gà \nGiấm, tương ớt, tỏi băm.', 6, 40),

--11
(3, N'Kho Quẹt', 'https://www.youtube.com/watch?time_continue=5&v=CnZ-LL14E2Y&feature=emb_logo',
		6000, 1, N'Vị mặn mặn, ngọt ngọt của mắm đường, giòn sựt của top mỡ chiên giòn, thêm một chút tôm khô - linh hồn của món kho quẹt chắc chắn sẽ là món khoái khẩu của mọi thành viên trong gia đình. Chúc các bạn làm kho quẹt thành công!',
		'Resource/Images/Product/Avatar_KhoQuet.jpg',
		N' 50 g tôm khô.\n 200 g thịt ba chỉ.\n Dầu ăn, nước mắm, đường, hạt nêm, tiêu, ớt.\n 1 củ hành tím. \n Hành lá cắt nhỏ.\n  Rau, củ luộc ăn kèm kho quẹt.', 6, 25),

--12
(3, N'Thịt kho tiêu', 'https://www.youtube.com/watch?v=lg56Z8zOzeg',
		1200, 1, N'Mình sẽ chia sẽ đến các bạn cách nấu thịt kho tiêu và chia sẽ cách thắng nước màu để nấu thịt để thịt có màu đẹp',
		'Resource/Images/Product/Avatar_ThitKhoTieu.jpg',
		N'Thịt ba chỉ: 400gr\n Hành lá, hành tím, tỏi băm\n Nước kẹo đắng\n 2 củ hành khô băm nhỏ\n Hành tươi thái nhỏ\n Gia vị: bột ngọt, tiêu, đường, nước mắm.', 6, 30),

--13
(3, N'Thịt kho Tàu', 'https://www.youtube.com/watch?v=Q5V0uEkdTPg',
		2500, 1, N'Thịt kho nước dừa hột vịt hay còn gọi là thịt kho Tàu là món ăn rất được ưa chuộng cả trong bữa cơm hàng ngày. Món ăn ngon, đậm đà, béo ngậy được dùng ăn chung với cơm trắng rất tuyệt. Cùng vào bếp nấu món ăn cực ngon này nhé.',
		'Resource/Images/Product/Avatar_ThitKhoTau.jpg',
		N'Thịt lợn ba chỉ 500g.\n Trứng cút 10 quả, 3 quả trứng gà\n  Nước mắm ngon\n Nước dừa tươi (01 quả)\n Tỏi, ớt, hành lá, đường\nGia vị kho thịt: Muối, mì chính, hạt tiêu, dầu ăn.', 6, 50),

--14
(3, N'Vịt kho gừng', 'https://www.youtube.com/watch?v=7Hj8j4sEyJg',
		1065, 1, N'Một trong những nguyên liệu kết hợp rất tuyệt vời cùng thịt vịt đó chính là gừng, vị cay và thơm của gừng cùng thịt vịt vốn tính hàn sẽ trung hòa và cân bằng hương vị của nhau. Bài viết dưới đây sẽ hướng dẫn cách làm món vịt kho gừng đưa cơm thơm ngon đơn giản tại nhà.',
		'Resource/Images/Product/Avatar_VitKhoGung.jpg',
		N'1/2 con vịt được làm sạch.\n  1 củ gừng, 1 trái ớt sừng.\n Tỏi băm, hành khô băm.\n Nước mắm ngon, nước màu đường, gia vị.', 4, 35),

--15
(3, N'Cá ngừ kho', 'https://www.youtube.com/watch?v=7-KU3IdvdtM',
		1065, 1, N'Cá ngừ kho vừa thơm ngon lại giàu dinh dưỡng sẽ là lựa chọn lý tưởng cho thực đơn nhà bạn. Hãy cùng Điện máy XANH tham khảo 5 cách làm món cá ngừ kho ngon cơm, đậm vị bổ dưỡng trong bài viết dưới đây nhé!',
		'Resource/Images/Product/Avatar_CaNguKho.jpg',
		N'4 lát cá ngừ\n 1/2 quả thơm\n 600 ml nước dừa\n Hành tím: 2 củ\n  Ớt: 1 quả, dầu ăn, gia vị', 5, 30),

--16
(4, N'Canh hến bí đao', 'https://www.youtube.com/watch?v=p9fQkbd5nhc',
		1065, 1, N'Chỉ với hai nguyên liệu là bí đao và hến nhưng khi kết hợp với nhau lại tạo nên món canh vừa có vị ngọt nhẹ vừa thanh mát, thơm ngon.',
		'Resource/Images/Product/Avatar_CanhBiHen.jpg',
		N'1 hoặc 2 trái bí xanh.\n 200g hến\n Gừng, hành lá, ngò rí, tiêu, muối, hạt nêm, đường, ớt bột.', 3, 20),

--17
(4, N'Canh chua cá lóc', 'https://www.youtube.com/watch?v=LAR2Ft5Mm98&feature=emb_logo',
		1065, 1, N'Canh chua cá lóc là món ăn dân gian, dễ ăn, dễ ghiền,... Bài viết sau Điện máy XANH sẽ hướng dẫn bạn cách nấu canh chua cá lóc đúng chuẩn mẹ nấu, ngon ngất ngây, cùng vào bếp thực hiện nhé!',
		'Resource/Images/Product/Avatar_CanhChuaCaLoc.jpg',
		N'Cá lóc (cá quả): 500 gr.\n Thơm: 1/4 trái.\n Cà chua: 2 trái.\n Đậu bắp: 50gr.\n Bạc hà: 50gr.\n Me vắt: 20gr.\n Giá đỗ: 50gr. \n Rau ngỗ (ngò gai): 10gr. \n Gia vị: nước mắm, muối, đường, hạt nêm, tiêu bột, ớt,...', 9, 40),

--18
(4, N'Canh chân giò nấu đu đủ', 'https://www.youtube.com/watch?v=4uuFbOuqGXw',
		1065, 1, N'Món ăn này gia đình mình thường nấu vào những ngày nghỉ cuối tuần để cải thiện bữa ăn cho gia đình.',
		'Resource/Images/Product/Avatar_CanhDuDuGioHeo.jpg',
		N'1,2-1,5 kg chân giò heo \n 0,5 kg đu đủ hườm, ớt tươi, hành ngò tươi \n Hạt nêm, nước mắm, bột ngọt, đường, tiêu', 3, 60),

--19
(4, N'Gà ác tiềm thuốc bắc', 'https://www.youtube.com/watch?v=NFC-TBHpBaA',
		1065, 1, N'Từ nguyên liệu gà sẽ có nhiều cách chế biến. Tuy nhiên, một món ăn giàu dinh dưỡng, được nhiều người yêu thích từ gà đó là gà ác tần thuốc bắc. Món gà ác tần thuốc bắc là sự kết hợp hòa quyện giữa thịt gà ác và các vị thuốc bắc nên lành tính và rất tốt cho người mới ốm dậy.',
		'Resource/Images/Product/Avatar_CanhGaAcHamThuocBac.jpg',
		N'2 con gà ác khoảng 600gr-700gr/con \n 1 quả dừa tươi \n Các vị thuốc bắc: kỳ tử, long nhãn, hạt sen, táo tàu, táo đỏ khô, đẳng sâm, đương quy, hoàng quỳ, nấm đông trùng hạ thảo khô \n Ngải cứu tươi một nắm to \n Gia vị: bột nêm,hạt tiêu,xì dầu...', 5, 60),

--20
(4, N'Canh gà tiềm ớt hiểm', 'https://www.youtube.com/watch?v=BwuEgHIukvQ',
		1065, 1, N'Lẩu gà là món ăn quen thuộc được nhiều người yêu thích, lẩu gà có nhiều biến tấu hấp dẫn, nào là lẩu gà nấu nấm, lẩu gà nấu măng chua, lẩu gà lá giang, lẩu gà thuốc bắc… và gần đây nhất là sự xuất hiện của món lẩu gà ớt hiểm. Lẩu gà ớt hiểm với hương vị cay cay của ớt và thịt gà dai ngon được chiên vàng trước khi nấu, ăn cùng các loại rau tươi xanh mát sẽ đem đến cho bạn một cảm giác hoàn toàn mới lạ.',
		'Resource/Images/Product/Avatar_CanhGaTimOtHiem.jpg',
		N'Gà ta: 1 con \n Sả: 4 nhánh \n Ớt hiểm: 40gr \n Nấm đông cô: 20gr \n Kỷ tử: 50 gr (Kỷ tử được dùng phổ biến như vị thuốc quý trong đông y, thường ở dạng quả phơi khô, có thể tìm mua ở các tiệm thuốc bắc). \n 1 trái dừa tươi \n 1 củ Hành tây \n Củ cải trắng: 1 củ \n Nấm tuyết, cải thảo, xà lách xong, mồng tơi, bông hẹ, tần ô, cải bẹ xanh con … \n Gia Vị', 9, 60)

GO

-- Hinh anh 
INSERT INTO HinhAnh
VALUES
--BATDAU
	(1, 'Resource/Images/Product/BL_Nuoi_Xao_Rau_1.jpg'),
	(1, 'Resource/Images/Product/BL_Nuoi_Xao_Rau_2.jpg'),
	(1, 'Resource/Images/Product/BL_Nuoi_Xao_Rau_3.jpg'),
	(1, 'Resource/Images/Product/BL_Nuoi_Xao_Rau_4.jpg'),
	(1, 'Resource/Images/Product/BL_Nuoi_Xao_Rau_5.jpg'),
	(1, 'Resource/Images/Product/BL_Nuoi_Xao_Rau_6.jpg'),
	(1, 'Resource/Images/Product/BL_Nuoi_Xao_Rau_7.jpg'),
	(1, 'Resource/Images/Product/BL_Nuoi_Xao_Rau_8.jpg'),

	(2, 'Resource/Images/Product/BL_ThitBoXaoMang_1.jpg'),
	(2, 'Resource/Images/Product/BL_ThitBoXaoMang_2.jpg'), 
	(2, 'Resource/Images/Product/BL_ThitBoXaoMang_3.jpg'),
	(2, 'Resource/Images/Product/BL_ThitBoXaoMang_4.jpg'),
	(2, 'Resource/Images/Product/BL_ThitBoXaoMang_5.jpg'),
	(2, 'Resource/Images/Product/BL_ThitBoXaoMang_6.jpg'),
	(2, 'Resource/Images/Product/BL_ThitBoXaoMang_7.jpg'),
	(2, 'Resource/Images/Product/BL_ThitBoXaoMang_8.jpg'),

	(3, 'Resource/Images/Product/BL_SupLoXaoTrung_1.jpg'),
	(3, 'Resource/Images/Product/BL_SupLoXaoTrung_2.jpg'),

	(4, 'Resource/Images/Product/BL_HatSenXao_1.jpg'),
	(4, 'Resource/Images/Product/BL_HatSenXao_2.jpg'),
	(4, 'Resource/Images/Product/BL_HatSenXao_3.jpg'),
	(4, 'Resource/Images/Product/BL_HatSenXao_4.jpg'),
	(4, 'Resource/Images/Product/BL_HatSenXao_5.jpg'),

	(5, 'Resource/Images/Product/BL_UcGaXao_1.jpg'),
	(5, 'Resource/Images/Product/BL_UcGaXao_2.jpg'),
	(5, 'Resource/Images/Product/BL_UcGaXao_3.jpg'),
	(5, 'Resource/Images/Product/BL_UcGaXao_4.jpg'),
	(5, 'Resource/Images/Product/BL_UcGaXao_5.jpg'),
	(5, 'Resource/Images/Product/BL_UcGaXao_6.jpg'),
	(5, 'Resource/Images/Product/BL_UcGaXao_7.jpg'),
	(5, 'Resource/Images/Product/BL_UcGaXao_8.jpg'),
	(5, 'Resource/Images/Product/BL_UcGaXao_9.jpg'),

	(6, 'Resource/Images/BL_ComChienThaiLan_1.jpg'),
	(6, 'Resource/Images/BL_ComChienThaiLan_2.jpg'),

	(7, 'Resource/Images/Product/BL_CanhGaChienNcMam_1.jpg'),
	(7, 'Resource/Images/Product/BL_CanhGaChienNcMam_2.jpg'),
	(7, 'Resource/Images/Product/BL_CanhGaChienNcMam_3.jpg'),

	(8, 'Resource/Images/Product/BL_KhoaiTayQueChien_1.jpg'),
	(8, 'Resource/Images/Product/BL_KhoaiTayQueChien_2.png'),
	(8, 'Resource/Images/Product/BL_KhoaiTayQueChien_3.png'),
	(8, 'Resource/Images/Product/BL_KhoaiTayQueChien_4.png'),
	(8, 'Resource/Images/Product/BL_KhoaiTayQueChien_5.png'),
	(8, 'Resource/Images/Product/BL_KhoaiTayQueChien_6.png'),
	(8, 'Resource/Images/Product/BL_KhoaiTayQueChien_7.png'),

	(9, 'Resource/Images/Product/BL_ThitVienChien_1.jpg'),
	(9, 'Resource/Images/Product/BL_ThitVienChien_2.jpg'),
	(9, 'Resource/Images/Product/BL_ThitVienChien_3.jpg'),
	(9, 'Resource/Images/Product/BL_ThitVienChien_4.jpg'),
	(9, 'Resource/Images/Product/BL_ThitVienChien_5.jpg'),

	(10, 'Resource/Images/Product/BL_ThitChienGion_1.png'),
	(10, 'Resource/Images/Product/BL_ThitChienGion_2.png'),
	(10, 'Resource/Images/Product/BL_ThitChienGion_3.png'),
	(10, 'Resource/Images/Product/BL_ThitChienGion_4.png'),
	(10, 'Resource/Images/Product/BL_ThitChienGion_5.png'),
	(10, 'Resource/Images/Product/BL_ThitChienGion_6.png'),

	(11, 'Resource/Images/Product/BL_KhoQuet_1.jpg'),
	(11, 'Resource/Images/Product/BL_KhoQuet_2.jpg'),
	(11, 'Resource/Images/Product/BL_KhoQuet_3.jpg'),
	(11, 'Resource/Images/Product/BL_KhoQuet_4.jpg'),

	(12, 'Resource/Images/Product/BL_ThitKhoTieu_1.jpg'),
	(12, 'Resource/Images/Product/BL_ThitKhoTieu_2.jpg'),
	(12, 'Resource/Images/Product/BL_ThitKhoTieu_3.jpg'),

	(13, 'Resource/Images/Product/BL_ThitKhoTau_1.jpg'),
	(13, 'Resource/Images/Product/BL_ThitKhoTau_2.jpg'),
	(13, 'Resource/Images/Product/BL_ThitKhoTau_3.jpg'),

	(14, 'Resource/Images/Product/BL_VitKhoGung_1.png'),
	(14, 'Resource/Images/Product/BL_VitKhoGung_2.png'),
	(14, 'Resource/Images/Product/BL_VitKhoGung_3.png'),
	(14, 'Resource/Images/Product/BL_VitKhoGung_4.jpg'),
	(14, 'Resource/Images/Product/BL_VitKhoGung_5.jpg'),
	(14, 'Resource/Images/Product/BL_VitKhoGung_6.jpg'),
	(14, 'Resource/Images/Product/BL_VitKhoGung_7.jpg'),

	(15, 'Resource/Images/Product/BL_CaNguKho_1.jpg'),
	(15, 'Resource/Images/Product/BL_CaNguKho_2.jpg'),

	(16, 'Resource/Images/Product/BL_CanhBiHen_1.jpg'),
	(16, 'Resource/Images/Product/BL_CanhBiHen_2.jpg'),
	(16, 'Resource/Images/Product/BL_CanhBiHen_3.jpg'),

	(17, 'Resource/Images/Product/BL_CanhChuaCaLoc_1.jpg'),
	(17, 'Resource/Images/Product/BL_CanhChuaCaLoc_2.jpg'),
	(17, 'Resource/Images/Product/BL_CanhChuaCaLoc_3.png'),

	(18, 'Resource/Images/Product/BL_CanhDuDuGioHeo_1.jpg'),
	(18, 'Resource/Images/Product/BL_CanhDuDuGioHeo_2.jpg'),
	(18, 'Resource/Images/Product/BL_CanhDuDuGioHeo_3.jpg'),

	(19, 'Resource/Images/Product/BL_CanhGaAcHamThuocBac_1.jpg'),
	(19, 'Resource/Images/Product/BL_CanhGaAcHamThuocBac_2.jpg'),

	(20, 'Resource/Images/Product/BL_CanhGaTimOtHiem_1.jpg'),
	(20, 'Resource/Images/Product/BL_CanhGaTimOtHiem_2.png'),
	(20, 'Resource/Images/Product/BL_CanhGaTimOtHiem_3.png'),
	(20, 'Resource/Images/Product/BL_CanhGaTimOtHiem_4.png'),
	(20, 'Resource/Images/Product/BL_CanhGaTimOtHiem_5.jpg')
GO

INSERT INTO CTSP --cac bước làm
VALUES
--BATDAU
	(1, 1, N'Cà rốt gọt vỏ, cắt sợi mỏng. Ớt chuông rửa sạch, bỏ cuống và hạt, cắt sợi. Hành tây tím lột vỏ, cắt mỏng. Tỏi bóc vỏ, băm nhỏ. Cà chua bi rửa sạch, bỏ cuống, bổ làm đôi. Bí ngòi rửa sạch, cắt mỏng theo khoanh tròn, sau đó bổ làm tư. Cà tím rửa sạch, cắt lát, sau đó ngâm qua nước muối cho hết nhựa thâm.'),
	(1, 2, N'Bắc nồi nước lên bếp đun sôi, bỏ 1/2 muỗng cà phê muối và dầu ăn vào. Đến khi nước sôi, cho nui vào luộc chín, sau đó vớt ra cho vào nước lạnh, sau đó để ráo và cho 1 muỗng canh dầu ôliu vào trộn đều.'),
	(1, 3, N'Đặt chảo lên bếp, cho 1 muỗng canh dầu ăn vào phi thơm tỏi, sau đó cho cà rốt và hành tây vào xào. Tiếp đến, cho bí ngòi, cà tím, vào đảo khoảng 3 phút đến chín thì nêm 1/2 muỗng cà phê muối cho vừa ăn. Trút ra đĩa sạch để riêng. Đặt chảo lên bếp, cho cà chua vào đảo, thêm nước sốt cà chua, xạ hương khô, lá oregano xay và lá húng quế vào.'),
	(1, 4, N'Nui cho ra đĩa, đổ hỗn hợp rau củ vào và rưới nước sốt cà chua lên trên cùng rồi thưởng thức.'),

	(2, 1, N'Thịt bò rửa sạch, thái miếng vừa ăn. Ướp thịt với lòng trắng trứng gà, 1 muỗng bột năng, muối, tiêu. Trộn đều và để yên cho thấm gia vị.'),
	(2, 2, N'Măng rửa sạch, cắt miếng vừa ăn, ớt chuông rửa sạch, bỏ hạt, cắt miếng vuông.'),
	(2, 3, N'Pha sốt: cho 80ml nước, 30ml dầu hào và hạt tiêu vào khuấy đều, để riêng ra chén.'),
	(2, 4, N'Bắc chảo dầu phi thơm gốc hành lá cắt nhuyễn và gừng thái lát, cho thịt bò vào đảo lửa lớn nhanh tay, trút ra chén để riêng.'),
	(2, 5, N'Thêm dầu ăn vào chảo, cho măng vào đảo đều, sau đó cho thịt bò và sốt nấu đã pha vào nấu chung.'),
	(2, 6, N'Khi các nguyên liệu đã sôi thì cho ớt chuông vào.'),
	(2, 7, N'Pha 1 muỗng bột năng cùng 30ml nước, khuấy tan rồi rưới vào nồi (chảo nhà mình bé quá nên phải đổ sang nồi để nấu tiếp). Đảo cho các nguyên liệu thấm đều, sốt sánh lại, nêm nếm gia vị cho vừa ăn rồi tắt bếp.'),
	(2, 8, N'Trình bày món ăn ra đĩa, thêm chút tiêu lên trên là hoàn thành.'),

	(3, 1, N'Cho bơ thực vật vào chảo nóng vừa lửa sau đó cho trứng (gà,cút) và cá(đã luộc) vào chảo, nhớ nhỏ lửa đảo qua đảo lại'),
	(3, 2, N'Đổ khoảng 50ml nước vào chảo đợi sôi bỏ Súp lơ vào đảo đều và đậy nắp nồi lại. Nem nếm gia vị, chủ yếu là muối tiêu, nên nếm vừa phải hạn chế ăn mặn để tốt cho sức khoẻ.'),
	(3, 3, N'Lên đĩa, trang trí chút cà chua, xà lách, dưa leo, rồi ăn thôi.. Rất phù hợp cho người ăn Keto nha'),

	(4, 1, N'Luộc chín hạt sen trong nước có bỏ chút muối rồi vớt sen ra. Cho bắp vào luộc tiếp, bắp chín vớt ra.'),
	(4, 2, N'Cho hạt sen, bắp ngọt, nấm vào chảo xào với hạt nêm. Xào khoảng 10’ rồi tắt bếp. Cho thêm rau mùi.'),

	(5, 1, N'Thịt ức gà rửa sạch, thấm khô nước, sau đó thái thịt ức gà thành những khối vuông nhỏ, có kích thước tương đối đồng đều. Ướp thịt ức gà với 5g đường, 5ml nước tương, 15ml rượu, 1g ít tiêu, 1 thìa cà phê bột bắp và ướp trong 10 phút.'),
	(5, 2, N'Bông cải xanh thái nhỏ, rửa sạch rồi đem chần qua nước sôi khoảng 1 phút, vớt ra để ráo nước. Gừng băm nhỏ. Tỏi và hành lá thái nhỏ. Trong chén nhỏ trộn đều hỗn hợp gồm: 1 muỗng cà phê bột bắp, 1 muỗng cà phê giấm balsamic, 5ml nước tương, 2g muối và một nửa chén nước.'),
	(5, 3, N'Xào thơm gừng băm, tỏi và đầu hành lá với 20ml dầu ăn. Cho ức gà đã ướp cho đảo đều săn lại. Tiếp đến cho bông cải xanh vào, xào cùng. Đổ chén sốt đã pha vào, xào tiếp 5 phút, thêm hành lá rồi tắt bếp.'),
	(5, 4, N'Món này đơn giản nên mình cũng không tốn nhiều công sức lắm. Gia vị nêm thì tùy khẩu vị. Nhưng mình khuyên với món Ức gà xào bông cải xanh này bạn nên nêm nhạt thôi để có thể còn chấm nước sốt ăn kèm nữa nhé!'),

--MÓN CHIEN
	(6, 1, N'Ướp vào 100g thịt băm 1/2 muỗng cf hành tím băm và 1/2 muỗng tỏi băm, 1,5 muỗng canh dầu hào, 1/2 muỗng canh dầu màu điều, 1/2 muỗng cf bột tỏi, 2 muỗng cf hạt nêm nấm hương, 1/2 muỗng cf bột ngọt và 2g muối i ốt.'),
	(6, 2, N'Luộc 100g rau củ hỗn hợp, khi nước vừa sôi thì tắt bếp, vớt ra cho ngay vào nước đá lạnh để vẫn giữ được đội tươi giòn => vớt ra để thật ráo.'),
	(6, 3, N'Bắt chảo lên bếp, đợi dầu nóng cho hành tím và tỏi băm vào khử thơm. Cho vào 100g thịt đã ướp xào với lửa lớn đến khi thấy thịt vừa săn thì cho cơm vào. Đảo đều cho màu sắc và gia vị của thịt hoà quyện với cơm.'),
	(6, 4, N'Cho phần rau củ hỗn hợp vào cơm, đảo đều tay với lửa nhỏ. Nêm vào 1 muỗng cf hạt nêm nấm hương, 1 ít muối, 1 ít bột ngọt và 1 ít đường (nêm tuỳ theo khẩu vị gia đình), đảo tiếp 3 phút với lửa nhỏ.'),
	(6, 5, N'Sau khi tắt bếp thì cho 1/2 muỗng cf bột cà ri vào, rắc đều tay và trộn thật đều cơm. Tiếp tục cho vào 1/2 muỗng cf bột ớt (lưu ý sử dụng loại bột ớt xay nhuyễn mịn chứ không sử dụng loại bột ớt vảy) rồi trộn đều, nếu ăn cay có thể tăng lượng ớt lên, đảo thật đều tay.'),
	(6, 6, N'Đập vào bát 2 quả trứng vịt, nêm vào ít hạt nêm và bột ngọt + ít tiêu, đánh lên rồi tráng trứng thật mỏng trên chảo nóng. Sau đó cho cơm vào giữa rồi gập đôi trứng lại như hình. Vì cơm đã nêm vừa ăn với các gia vị nên không cần thêm nước tương sẽ làm mất mùi đặc trưng của cơm, có thể dùng kèm tuong ớt nếu muốn. Đây là món cơm rất lạ miệng, hãy làm thử cho gia đình bạn dùng nhé, chỉ mất khoảng 30p đã có món cơm chiên cay nồng đủ chất. Chúc các bạn thành công!'),

	(7, 1, N'Hành tây cắt sợi nhỏ, ớt cắt khoanh nhỏ.'),
	(7, 2, N'Cánh gà làm sạch, rửa sạch (có thể áp dụng cách trên), để khô và ướp với gia vị (tỉ lệ như trên) và trước khi chiên thì cho vào ½ muỗng canh bột chiên và đảo đều tay.'),
	(7, 3, N'Cho dầu ăn vào ngập đáy chảo và đun cho dầu sôi già. Cho cánh gà vào chiên đến thịt chín và vàng giòn. Vớt ra để ráo dầu.'),
	(7, 4, N'Lấy chảo mới và cho vào 2 muỗng canh dầu ăn, đến khi dầu sôi thì cho tỏi vào phi cho thơm, cho tiếp vào muỗng canh tương ớt, 2 muỗng canh đường và 4 muỗng canh nước mắm khuấy đều cho tan rồi cho ớt cắt sẵn vào.'),
	(7, 5, N'Cho gà đã ráo dầu vào rim, đảo nhanh tay với lửa lớn, đến khi gà được áo lớp xốt thì cho hạ lửa nhỏ và cho tiếp hành tây vào. Đảo đều tay đến khi nước xốt đặc quánh là có thể tắt bếp.'),
	(7, 6, N'Cho cánh gà ra dĩa và dọn kèm với rau sống và cơm trắng. Trang trí với chút tiêu và ngò bên trên.'),

	(8, 1, N'Khoai tây bỏ vỏ thái khúc nhỏ đem hấp chín. Khoai chín mềm thì đem tán nhuyễn. '),
	(8, 2, N'Cho bơ, bột gạo, bột bắp và 1/2 muỗng cà phê muối vào.'),
	(8, 3, N'Lúc đầu sẽ hơi khô nhưng nhồi 1 lúc bột sẽ mịn lại. Cho tiếp phần hành ngò thái nhỏ vào nhồi cho đều.'),
	(8, 4, N'Ủ bột 30 phút. Đem bột ra nhào lần nữa rồi cán thành 1 miếng lớn, xắn bột thành những cọng bằng nhau. Se bột thành sợi. Bạn nên thoa 1 chút bột bắp áo phía ngoài khi cán bột.'),
	(8, 5, N'Đun nóng dầu ăn trong chảo, cho từng cọng khoai vào chiên với lửa nhỏ đến khi khoai nổi lên vàng giòn thì vớt ra để ráo dầu. Lưu ý nên chiên ngập dầu để khoai không bị thấm dầu. Có thể chiên lần 2 để khoai giữ độ giòn lâu hơn nhé!'),

	(9, 1, N'Cho thịt băm vào bát, thêm yến mạch, đường, muối và nước tương vào trộn đều. Ướp thịt trong khoảng 20 phút.'),
	(9, 2, N'Viên thịt thành từng viên chả dẹt. Cho bột thì là, bột ngũ vị hương, vừng đen vào đĩa rồi trộn đều.'),
	(9, 3, N'Lăn từng viên thịt qua hỗn hợp bột vừa trộn sao cho bột phủ đều viên thịt.'),
	(9, 4, N'Đun nóng một ít dầu ăn trong chảo, cho thịt viên đã lăn bột vào chiên chín vàng đều hai mặt là được.'),

	(10, 1, N'Thịt thái miếng mỏng và dài tầm 4-5cm. Ướp thịt với 1/2 muỗng hạt nêm, 1/2 muỗng cà phê tiêu. Ớt chuông thái hạt lựu.'),
	(10, 2, N'Trứng gà đánh tan. Thịt nhúng qua bột chiên giòn rồi trứng gà và cuối cùng là lớp bột xù.'),
	(10, 3, N'Cho thịt vào chảo dầu chiên với lửa nhỏ vừa, đến khi thịt vàng giòn đều thì vớt ra rây cho ráo dầu.'),
	(10, 4, N'Làm xốt chua ngọt: Cho vào chén 2 muỗng canh tương ớt, 3 muỗng canh nước tương, 3 muỗng canh giấm, 2 muỗng canh đường, 1 muỗng canh dầu hào và nửa chén nước. Khuấy đều. Phi thơm tỏi cho ớt chuông vào xào thơm, tiếp đó là chén xốt đã pha. Nếm có vị chua ngọt vừa miệng thì thêm bột năng pha loãng vào để làm sệt.'),

	(11, 1, N'Ngâm tôm khô với nước nóng trong 10 phút cho mềm. Thịt ba chỉ cắt hạt lựu. Pha 8 muỗng canh nước mắm với 4 muỗng canh đường cùng 4 muỗng canh nước lọc.'),
	(11, 2, N'Cho dầu ăn vào nồi, xào thịt ba chỉ trên bếp đến khi thịt ra hết mỡ, vàng giòn. Lấy thịt ba chỉ ra, chắt nước mỡ đi. Cho 3 muỗng canh mỡ ở trên vào nồi đất.'),
	(11, 3, N'Hành củ băm nhỏ, phi vàng với phần nước mỡ. Tôm khô rửa sạch, để ráo, cho tôm vào phi vàng đều. Cho thịt ba chỉ đã chiên vàng ở trên vào. Khi thịt trộn đều với tôm khô thì cho 1/2 muỗng cà phê hạt nêm vào.'),
	(11, 4, N'Cho chén nước mắm làm sẵn vào nồi thịt. Thêm tiêu và ớt tuỳ theo khẩu vị. Rim kho quẹt đến khi mắm keo lại thì cho hành lá cắt nhỏ vào.'),

	(12, 1, N'Khử mùi hôi của thịt bằng cách ngâm vào trong nước muối khoảng 15 phút rồi rửa sạch và thái thành từng miếng vừa ăn.'),
	(12, 2, N'Ướp thịt với nước mắm, hạt nêm, hành khô băm nhỏ, hạt tiêu trong khoảng 20 phút cho thịt ngấm gia vị thêm phần đậm đà.'),
	(12, 3, N'Cho thịt đã ướp vào nồi và đổ một ít nước kẹo đắng đóng chai mua sẵn ngoài hàng tạo màu rồi đun cho đến khi sôi thì cho thêm nước vào đun đến khi sôi lại lần nữa thì chuyển sang lửa nhỏ để liu riu cho đến khi cạn nước. Nếu bạn muốn ăn chan nước thịt thì không nên kho cạn. Cuối cùng khi thịt chín thì múc ra cho hành tươi thái nhỏ lên cho thơm và thưởng thức. Món ăn sẽ vô cùng ngon khi được ăn nóng luôn cùng với cơm.'),

	(13, 1, N'Thịt ba chỉ mua về cạo sạch lông, rửa sạch rồi ngâm trong nước muối ấm khoảng 5 phút khử mùi hôi. Sau khi làm sạch, thái miếng vuông to. Cho thịt lợn thái miếng vào tô sau đó ướp cùng 2 thìa nước mắm, 1 thìa đường, ½ thìa muối, mì chính, thêm tỏi băm, hạt tiêu, 1 thìa dầu ăn sau đó đảo đều để ngấm trong 30 phút.'),
	(13, 2, N'Luộc trứng. Để trứng dễ bóc và không bị vỡ khi luộc, cho thêm chút muối và dấm gạo vào nồi.'),
	(13, 3, N'Cho đường vào chảo đun sôi, đảo đều đến khi đường có màu cánh gián, sau đó cho từ từ khoảng 1 bát tô nước đủ để kho thịt. Có thể cho thêm một chút dầu ăn vào khi đun đường để tránh bị cháy.'),
	(13, 4, N'Bắc nồi lên bếp, cho một chút dầu ăn vào đun nóng sau đó cho thịt lợn đã ướp vào đảo đều cho săn lại, thêm chút xíu mắm cho món thịt kho đậm đà.'),
	(13, 5, N'Tiếp đó bạn cho nước màu và nước dừa xâm xấp mặt thịt đun đến khi sôi vặn lửa nhỏ trong khoảng 1 tiếng rưỡi. Khi kho dùng thìa hớt bọt để món ăn được đẹp mắt.'),
	(13, 6, N'Trước khi tắt bếp, thả trứng cút và trứng gà vào đun sôi nhỏ lửa 15 phút là trứng và thịt đã ngấm đều.'),

	(14, 1, N'Gừng gọt vỏ, xắt lát mỏng hoặc xắt sợi. Ớt xắt khoanh mỏng.'),
	(14, 2, N'Vịt ngâm và chà rửa với rượu trắng với một ít lát gừng để không bị hôi lông. Chặt vịt thành từng miếng vừa ăn.'),
	(14, 3, N'Ướp vịt với ít tỏi băm, hành khô băm, 1/2 lượng gừng, 1 muỗng canh nước mắm ngon, 1/2 muỗng canh đường.'),
	(14, 4, N'Phi thơm tỏi trong chảo dầu rồi cho chỗ gừng còn lại vào xào.'),
	(14, 5, N'Khi gừng hơi vàng (đừng để vàng quá) thì cho thịt vịt vào xào săn. Cho vào ít nước màu, nêm nước mắm, đường, hạt nêm sao cho vừa ăn.'),
	(14, 6, N'Cho nước vào xâm xấp mặt vịt, kho với lửa riu riu cho vịt thật mềm và thấm. Thêm ớt đã xắt vào nồi vịt kho.'),
	(14, 7, N'Kho đến khi nước hơi cạn là được. Nêm nếm lại cho vừa ăn rồi tắt bếp. Cho vịt kho gừng ra bát và thưởng thức.'),

	(15, 1, N'Cá ngừ sơ chế thật sạch. Dứa rửa sạch sau đó thái miếng vừa ăn. Hành tím bóc vỏ, băm nhỏ. Ớt rửa sạch, bỏ hạt, băm nhỏ.'),
	(15, 2, N'Bắc chảo lên bếp, cho dầu ăn vào đun nóng rồi cho cá vào chiên sơ qua để cá không bị nát. Sau đó, vớt cá ra đĩa.'),
	(15, 3, N'Cho hành băm và ớt vào chảo phi cho thơm. Sau đó, bạn cho thơm vào và đảo đều, nêm thêm 1 - 2 thìa canh nước mắm, 1 thìa cà phê hạt nêm, 1 thìa cà phê đường. '),
	(15, 4, N'Tiếp theo, cho nước dừa vào đun cùng thơm, đến khi nước sôi thì cho cá ngừ chiên vào. Đun với lửa nhỏ trong đến khi nước sền sệt thì nêm nếm lại cho vừa ăn, sau đó tắt bếp'),

	(16, 1, N'Bí xanh gọt vỏ, rửa sạch, thái quân cờ. Hành lá, ngò rí rửa sạch. Gừng gọt vỏ, thái sợi. Hến đãi sạch lại với nước ấm. Sau đó ướp hến với muối, hạt nêm, đường.'),
	(16, 2, N'Phi thơm dầu ăn, cho ít ớt bột vào để tạo màu. Tiếp đến cho hến vào xào săn. Cho bí vào rồi cho nước lọc vào đun sôi. Thêm vào gừng thái sợi rồi nêm lại gia vị vừa ăn là được.'),
	(16, 3, N'Múc canh bí ra bát, rắc lên ít tiêu cùng hành lá, ngò rí và dùng nóng với cơm.'),

	(17, 1, N'Cá lóc làm thịt, rửa sạch, cắt khúc vừa ăn khoảng 2-3 cm, đem ướp với 1 chút tiêu, hạt nêm, nước mắm khoảng 10 phút.'),
	(17, 2, N'Các loại rau nấu kèm rửa sạch, tước vỏ (nếu có), đậu bắp, dọc mùng, thơm cắt xéo vừa ăn, cà chua bổ múi cau, rau thơm cắt nhỏ.'),
	(17, 3, N'Me vắt cho vào 1 chén nước ấm, dầm cho tan thịt me, chắt lấy nước. Đun một nồi nước vừa ăn (khoảng 1 lít), nếu có xương ống bạn ninh kèm cho ngọt nước, nước sôi nêm nếm muối, mắm, hạt nêm, đường, bột ngọt,... cho vừa ăn. Sau đó cho nước cốt me vào đun sôi cùng.'),
	(17, 4, N'Cho thơm vào đun sôi, sau đó thả cá vào đun khoảng 5-7 phút, cá chín vớt ra.'),
	(17, 5, N'Cho đậu bắp, cà chua, dọc mùng vào đun sôi, nêm nếm vừa ăn.'),

	(18, 1, N'Chân giò chặt khoanh, đu đủ thái cục, hành ngò tươi thái nhỏ, ớt tươi cắt miếng tất cả rửa sạch để ráo nước.'),
	(18, 2, N'Chân giò sau khi để ráo đem ướp gia vị gồm: một ít hạt nêm, nước mắm, tiêu, hành khô băm nhuyễn để khoảng 10-15p cho giá vị thấm vào chân giò.'),
	(18, 3, N'Đun nước thật sôi bỏ chân giò đã ướp gia vị vào hầm với lượng nước vừa phải và cho lửa vừa phải hầm cho chân giò mềm và thấm với các gia vị mình đã ướp.'),
	(18, 4, N'Đến khi chân giò mềm thì cho đu đủ thái cục vào hầm, lưu ý khi hầm đu đủ nên hầm vừa phải đừng để đu đủ rục quá bị vữa ra sẽ làm mất ngon các bạn nhé.'),
	(18, 5, N'Đến lúc đu đủ đã mềm ta nêm lại gia vị một lần nữa cho vừa với khẩu vị với từng gia đình, và bỏ thêm gia vị như tiêu, hành ngò tươi, ớt tươi cắt miếng vào cho thêm phần hấp dẫn của món ăn là dùng được các bạn nhé.'),

	(19, 1, N'Gà ác mua về làm sạch rồi đem đi bóp với muối, rượu và gừng để cho sạch, quan trọng là để khử mùi hôi. Sau đó rửa sạch và để cho ráo nước.'),
	(19, 2, N'Gà sau khi để cho ráo bớt nước đem đi ướp cùng với ½ thìa cà phê hạt tiêu, 1 thìa cà phê bột nêm và 1 thìa canh xì dầu. Dùng găng tay ni lông để xoa đều hỗn hợp lên trên thân và phía bên trong gà, để trong vòng 15 phút để gà thấm gia vị.'),
	(19, 3, N'Các loại thuốc bắc đã chuẩn bị cho vào nước ấm ngâm cho nở rồi đem rửa cho thật sạch, để ráo nước. Ngải cứu ngắt lấy phần ngọn non, đem đi rửa sạch rồi trần qua nước sôi.'),
	(19, 4, N'Dừa tươi đem bổ lấy nước và để riêng.'),
	(19, 5, N'Chuẩn bị một chiếc nồi rồi cho gà đã tẩm ướp vào. Tiếp theo cho hết tất cả các vị thuốc bắc xung quanh gà. '),
	(19, 6, N'Bắc gà lên bếp đem đi hấp cách thủy hoặc cho gà vào nồi tần. Lưu ý sau khi đun sôi thì hạ lửa nhỏ liu riu. Tần cho đến khi gà chín mềm là được. Thời gian tần gà có thể là hai giờ hoặc lâu hơn tùy vào từng loại gà'),

	(20, 1, N'Gà sau khi làm sạch thì chặt làm 8 phần. Sau đó, cho vào 1 muỗng café hành tím, tỏi băm, 1 muỗng café hạt nêm ướp gà trong khoảng 15 phút.'),
	(20, 2, N'Đun sôi dầu ăn sau đó chiên sơ sả trong dầu cho thơm rồi vớt ra cho gà vào. Chiên gà săn lại cho tới khi thịt chín vàng đều thì vớt ra. ( Nhớ để cho ráo dầu).'),
	(20, 3, N'Bắc nồi lên bếp cho vào nước dừa tươi và 1 lít nước để đun sôi. Cho tiếp gà, sả, ớt hiểm vào nấu và nêm vào 1 muỗng canh hạt nêm, 1 muỗng canh nước tương, đậy nắp lại. Trong khi nấu nhớ hớt bọt cho nồi nước dùng được trong.'),
	(20, 4, N'Sau 5 – 7 phút thì tiếp tục cho củ cải trắng, nấm đông cô vào nồi nấu. Khi thịt gà chín mềm thì cho tiếp kỷ tử, hành tây vào nồi và nêm nếm vị cho vừa ăn rồi đun tiếp trong vài phút thì tắt bếp.'),
	(20, 5, N'Trong khi hầm xương gà cho mềm thì chuẩn bị nước chấm. Món này các bạn hãy pha muối ớt bằng cách cho 1 thìa muối hạt, 5 trái ớt hiểm xanh vào cối giã dập. Sau đó cho ra bát, thêm 1 thìa đường, 1 thìa nước cốt chanh khuấy tan đường là được.'),
	(20, 6, N'Múc gà, các nguyên liệu và nước dùng ra nồi dùng để ăn lẩu. Dọn ra cùng các loại rau, mì ăn kèm.')
	
GO

INSERT INTO SanPham
VALUES
	(1, N'Ngồng tỏi xào tôm khô', 'https://www.youtube.com/watch?v=eusgvL51NaY',
			1065, 0, N'Cứ đến hẹn lại lên,Bếp Nhà Choi UnSu hôm nay này xin gửi đến anh chị em món ngồng tỏi xào tôm khô',
			'Resource/Images/Product/Avatar_NgongToiXaoTom.jpg',
			N'150g ngồng tỏi \n 50g tôm khô \n Giá Vị \n 1thìa nước tương \n 1thìa tỏi băm \n 2 thìa nước đường \n 3 thìa tương ớt \n 1 thìa dầu ớt \n 1 thìa dầu vừng \n 1thìa vừng', 10, 40),
	
--22
(1, N'Miến rong xào thập cẩm', 'https://www.youtube.com/watch?v=L7I87jqw0LI',
		1065, 0, N'Đã bao lâu bạn chưa ăn lại món này? Hôm nay mình sử dụng Miến Hàn Quốc để làm món ăn này. Miến Hàn Quốc làm theo kiểu Hàn còn có tên là Miến trộn Hàn Quốc Japchae. Có thể sử dụng Miến dong để làm món ăn này và có thể theo cách làm món Miến Xào Cật mà hôm trước Vành Khuyên đã chia sẻ để cho Miến không bị dính chùm sau khi xào.',
		'Resource/Images/Product/Avatar_MienXao.jpg',
		N'150 gr miến rong \n 200 gr giá đỗ \n 2 k hành \n Gia vị hạt nêm, nước mắm dầu hào hạt tiêu mì chính', 4, 30)

GO

INSERT INTO HinhAnh
VALUES
	(23, 'Resource/Images/Product/Bl_NgongToiXaoTom_1.jpg'),
	(23, 'Resource/Images/Product/Bl_NgongToiXaoTom_2.jpg'),
	(23, 'Resource/Images/Product/Bl_NgongToiXaoTom_3.jpg'),
	(23, 'Resource/Images/Product/Bl_NgongToiXaoTom_4.jpg'),
	(23, 'Resource/Images/Product/Bl_NgongToiXaoTom_5.jpg'), 
	(23, 'Resource/Images/Product/Bl_NgongToiXaoTom_6.jpg'),
	(23, 'Resource/Images/Product/Bl_NgongToiXaoTom_7.jpg'),
	(23, 'Resource/Images/Product/Bl_NgongToiXaoTom_8.jpg'),
	
	(24, 'Resource/Images/Product/BL_MienXao_1.jpg'),
	(24, 'Resource/Images/Product/BL_MienXao_2.jpg'),
	(24, 'Resource/Images/Product/BL_MienXao_3.jpg'),
	(24, 'Resource/Images/Product/BL_MienXao_4.jpg')
GO

INSERT INTO CTSP --cac bước làm
VALUES
	(23, 1, N'Ngồng tỏi xào tôm khô Nguyên Liệu _ 150g ngồng tỏi _ 50g tôm khô Giá Vị _ 1thìa nước tương _ 1thìa tỏi băm _  2 thìa nước đường _ 3 thìa tương ớt _  1 thìa dầu ớt (có thể thay bằng dầu ăn) _Trộn tất cả gia vị đã ghi ở trên lại với nhau (Bát Gia Vị) Giá vị cho vào cuối cùng _  1 thìa dầu vừng _ 1thìa vừng'),
	(23, 2, N'Tôm khô cho vào bát nước ngâm 2~3phút,rồi vớt ra rửa lại 1~2 lần cho sạch bụi và cát. Để tôm vào giá cho khô ráo nước'),
	(23, 3, N'Ngồng tỏi rửa sạch, xắt dài 2~3cm.'),
	(23, 4, N'Đun nồi nước sôi cho vào 1thìa muối'),
	(23, 5, N'Tiếp đến cho Ngồng tỏi vào luộc 3phút tính từ lúc nước sôi.'),
	(23, 6, N'Vớt Ngồng tỏi ra bát nước lạnh'),
	(23, 7, N'Tiếp tục vớt Ngồng tỏi ra để khô ráo nước.'),
	(23, 8, N'Cho tôm khô vào chảo rang đến khi giòn'),
	(23, 9, N'Tôm đã rang giòn thì đổ ra giá lắc qua lắc lại để những cái cấn vụn bong ra. Khéo léo nhặt tôm ra ngoài,còn phần cấn dụng ra từ tôm thì bỏ đi.'),
	(23, 10,N'Cho Bát Gia Vị vào chảo đun nóng(để lửa nhỏ kẻo cháy hết gia vị)'),
	(23, 11,N'Cho Bát Gia Vị vào chảo đun nóng,tiếp đến cho tôm và ngồng tỏi vào đảo đều. Cuối cùng cho dầu vừng và hạt vừng vào đảo qua rồi tắt bếp.'),
	(23, 12,N'Tôm giòn cộng tỏi ko đắng khi ăn có vị cay hơi ngọt❤❤❤❤❤❤❤❤❤❤❤❤❤❤❤ Bếp Nhà Choi UnSu Chúc Quý Vị Ngon Miệng'),

	(24, 1, N'Miến ngâm nước lạnh xong nhúng nhanh qua nước nước 70 độ rồi với ra cho tiếp vào nước lạnh rửa lại. Cho vào tô cho 1 ít dầu ăn vào trộm đều để đó cho miến lát xào k bị nát và dính'),
	(24, 2, N'Cà rốt nạo sợi, hành mộc nhĩ xắt khúc. Lòng mề rửa sạch, bóp muối chanh cho ra hết bẩn.'),
	(24, 3, N'Giá đỗ ngâm muối rửa sạch vớt ra. Cho lòng mề vào xào gần chín thì cho hạt nêm, giá đỗ, cà rốt, nấm mèo vào đảo đều, cho chút nước mắm, mì chính xong cho miến vào đảo. Cuối cùng cho hành lá, một chút tiêu vào đảo lại là được. Sợi miến rất ngon và k nát tí nào')
GO

UPDATE SanPham 
SET 
	TenSp = N'Mực xào chua ngọt',
	Video = 'youtube.com/watch?v=Ew35BJSvCFs',
	LuotXem = 1005,
	yeuThich = 0,
	MoTa = N'Mực xào chua ngọt với những bước làm cực dễ dưới đây sẽ là một lựa chọn bạn không thể bỏ qua khi muốn đổi vị cho cả nhà trong những dịp đặc biệt.',
	AnhDaiDien = 'Resource/Images/Product/Avatar_MucXao.jpg',
	NguyenLieu = N'Mực ống: 300gr \n Ớt chuông xanh và đỏ: 2 trái (mỗi màu 1 trái) \n Dưa leo: 1 trái \n Dứa: 1/3 trái \n Cà chua: 1 trái \n Hành tây: 1 củ \n Cần tây: 1 cây \n Tỏi: 1 củ \n Hạt nêm, đường, muối,tiêu xay…',
	SoThanhPhan = 9,
	ThoiGian = 30
WHERE MaSP = 21

UPDATE SanPham 
SET 
	TenSp = N'Thịt heo xào kim chi giá đỗ',
	Video = 'https://www.youtube.com/watch?v=XDRc7XFVla4',
	LuotXem = 2005,
	yeuThich = 1,
	MoTa = N'Trong những ngày se lạnh thì thưởng thức cơm nóng với thịt xào kim chi nóng hổi thì hợp vô cùng. Với cách xào thịt ngon này phần thịt sẽ thêm đậm đà, từng miếng từng miếng thơm nức mũi đượm vị chua cay của kim chi rất “bắt” cơm. Món ăn kết hợp hoàn hảo giữa kim chi nóng và giá đỗ tính hàn giúp cân bằng vị giác, vừa có chua, cay lại vừa có cái ngọt giòn kéo lại khiến người thưởng thức không khỏi thích thú. Không chỉ ăn với cơm, thịt xào kim chi dùng kèm với cơm cháy hay bún trộn cũng không kém phần ngon miệng đâu đấy.',
	AnhDaiDien = 'Resource/Images/Product/Avatar_ThitHeoXaoKimChi.jpg',
	NguyenLieu = N'Thịt ba chỉ 200 gr \n Giá đỗ 50 gr \n Hành tây 1 củ \n Dầu mè 1/2 muỗng canh \n Dầu ăn \n Kim chi cải thảo 100 gr \n Tỏi băm 1/2 muỗng canh \n Nước tương 2 muỗng canh \n Đường trắng 1/2 muỗng canh',
	SoThanhPhan = 8,
	ThoiGian = 35
WHERE MaSP = 22

INSERT INTO CTSP 
VALUES
(21, 1, N'Cho chảo lên bếp, chờ chảo nóng thì cho 2 muỗng dầu ăn vào, tráng đều mặt chảo. Khi dầu nóng già thì cho 1 muỗng tỏi băm vào phi thơm cho mực vào xào khoảng 3 – 4 phút là mực chín tới thì trút mực ra đĩa.'),
(21, 2, N'Cũng cái chảo lúc nãy , cũng phi thơm hành tỏi rồi cho ớt chuông và dưa leo khoảng 2 phút thì cho tiếp thơm và hành tây vào, tiếp tục đảo đều tay.Tiếp đến bỏ mực lúc nãy vào, nêm thêm 1 muỗng hạt nêm, 2 muỗng đường, 1/2 muỗng cafe muối, 1 muỗng giấm, 1 muỗng tương ớt, 1 muỗng tương cà, 1/2 muỗng nước tương, 1/3 muỗng cafe tiêu xay vào và đảo đều và tắt bếp.'),
(21, 3, N'Cuối cùng, cho tất cả ra đĩa, dọn lên ăn kèm với cơm nóng rất là ngon.'),

(22, 1, N'Hành tây cắt nhỏ. Tỏi bóc vỏ lụa, bằm nhuyễn. Thịt rửa sạch, thái miếng mỏng.'),
(22, 2, N'Cho thịt ra bát, thêm các thành phần gia vị trong phần ướp thịt vào trộn đều. Ướp thịt trong 15 phút cho thấm. Đun sôi nồi nước, cho giá đỗ vào trụng sơ rồi vớt ra cho ráo.'),
(22, 3, N'Làm nóng chảo trên lửa lớn với 1 muỗng canh dầu. Trút thịt vào đảo đều cho đến khi thịt đổi màu thì gạt thịt ra đĩa, để riêng. Làm nóng 1 chảo khác với 1 muỗng canh dầu, cho tỏi và hành vào phi thơm.'),
(22, 4, N'Trút thịt xào vào, thêm kim chi thái nhỏ vào xào trong 2-3 phút cho đến khi thịt chín hoàn toàn. Sau cùng, cho giá đỗ vào đảo chung, nêm nước tương cho vừa miệng rồi tắt bếp.')

--HINH ANH
INSERT INTO HinhAnh VALUES
(21, 'Resource/Images/Product/BL_MucXao_1.jpg'),
(21, 'Resource/Images/Product/BL_MucXao_2.jpg'),
(21, 'Resource/Images/Product/BL_MucXao_3.jpg'),
(21, 'Resource/Images/Product/BL_MucXao_4.jpg'),

(22, 'Resource/Images/Product/BL_ThitHeoXaoKimChi_1.jpg'),
(22, 'Resource/Images/Product/BL_ThitHeoXaoKimChi_2.jpg'),
(22, 'Resource/Images/Product/BL_ThitHeoXaoKimChi_3.jpg')

update CTSP set Buoclam=

select * from Hinhanh

delete CTSP where masp=22
GO

SELECT * FROM CTSP WHERE MaSP=1 ORDER BY STT
select * from HinhAnh where MaSP=1

SELECT sp.*,TenDM  FROM SANPHAM AS SP join DanhMuc as dm on dm.MaDM = sp.MADM where yeuThich=1

select * from SanPham where yeuThich=1

select * from danhMuc

select * from SanPham as sp join DanhMuc as dm on dm.MaDM = sp.MaDm  where dm.MADM=1

--NSERT INTO SanPham VALUES (1, N'ma1', '',0, False, N'mota', 'C:\\Users\\PC\\Desktop\\Phú\\C#\\biding list\\ListBook\\Images\\book8.jpg',N'nl1\nnl2\nnl3\n', 3, 12h)
select *from sanpham

update sanpham set MADM
SELECT IDENT_CURRENT('SanPham') as LastID

select  * from SanPham
update Table SanPham set yeuthich=? where masp=?