USE master
GO
IF DB_ID('QLGH') IS NOT NULL
	DROP DATABASE QLGH

GO
CREATE DATABASE QLGH
GO
USE QLGH

create table loaisanpham (
	id_lsp int,
	lsp_ten nvarchar(50),
	CONSTRAINT PK_LSP
	PRIMARY KEY (id_lsp)
)

create table sanpham (
	id_sp int,
	sp_ten nvarchar(50),
	sp_mota nvarchar(50),
	sp_tonkho int,
	sp_dongia int,
	sp_donvi int,
	sp_loaisp int,
	sp_cuahang int,
	CONSTRAINT PK_SP
	PRIMARY KEY (id_sp)
)

create table cuahang (
	id_ch int,
	ch_ten nvarchar(50),
	ch_mota nvarchar(50),
	ch_danhgia nvarchar(50),
	ch_sdt varchar(10),
	ch_stk varchar(30),
	CONSTRAINT PK_CH
	PRIMARY KEY (id_ch)
)

create table hinhthucthanhtoan (
	id_httt int,
	httt_ten nvarchar(50),
	CONSTRAINT PK_HTTT
	PRIMARY KEY (id_httt)
)

create table khachhang (
	id_khachhang int,
	kh_ten nvarchar(50),
	kh_sdt varchar(10),
	kh_diachi nvarchar(50),
	kh_cccd varchar(15),
	kh_stk varchar(30),
	kh_vung varchar(30),
	kh_email varchar(30)
	CONSTRAINT PK_KH
	PRIMARY KEY (id_khachhang)
)

create table tinhtrangdonhang (
	id_ttdh int,
	ttdh_ten nvarchar(50),
	CONSTRAINT PK_TTDH
	PRIMARY KEY (id_ttdh)
)


create table donhang (
	id_donhang int,
	dh_thoigian datetime,
	dh_tinhtrangthanhtoan bit,
	dh_danhgia nvarchar(50),
	dh_soluong int,
	dh_httt int,
	dh_khachhang int,
	dh_ngh int,
	dh_ttdh int,
	CONSTRAINT PK_DH
	PRIMARY KEY (id_donhang)
)

create table donhang_sanpham (
	id_dh int,
	id_sp int,
	soluong int,
	CONSTRAINT PK_DH
	PRIMARY KEY (id_dh, id_sp)
)
create table thongtindiduong (
	id_ttdd int,
	ttdd_ngaycap datetime,
	ttdd_ngayhethan datetime
	CONSTRAINT PK_TTDD
	PRIMARY KEY (id_ttdd)
)

create table ketquakiemtra (
	id_kqkt int,
	kqkt_ketqua nvarchar(50),
	kqkt_ngaykiemtra datetime
	CONSTRAINT PK_TTDD
	PRIMARY KEY (id_kqkt)
)

create table nguoigiaohang (
	id_ngh int,
	ngh_ten nvarchar(50),
	ngh_sdt varchar(10),
	ngh_diachi nvarchar(50),
	ngh_cccd varchar(15),
	ngh_stk varchar(30),
	ngh_vunghoatdong varchar(30),
	ngh_email varchar(30),
	ngh_ngaydangky datetime,
	ngh_ttdd int,
	ngh_kqkt int,
	CONSTRAINT PK_NGH
	PRIMARY KEY (id_ngh)
)

ALTER TABLE sanpham
ADD CONSTRAINT FK_SP_LSP
	FOREIGN KEY (sp_loaisp)
	REFERENCES loaisanpham

ALTER TABLE sanpham
ADD CONSTRAINT FK_SP_CH
	FOREIGN KEY (sp_cuahang)
	REFERENCES cuahang

ALTER TABLE nguoigiaohang
ADD CONSTRAINT FK_NGH_TTDD
	FOREIGN KEY (ngh_ttdd)
	REFERENCES thongtindiduong

ALTER TABLE nguoigiaohang
ADD CONSTRAINT FK_NGH_KQKT
	FOREIGN KEY (ngh_kqkt)
	REFERENCES ketquakiemtra

ALTER TABLE nguoigiaohang
ADD CONSTRAINT FK_NGH_KQKT
	FOREIGN KEY (ngh_kqkt)
	REFERENCES ketquakiemtra

ALTER TABLE donhang
ADD CONSTRAINT FK_DH_HTTT
	FOREIGN KEY (dh_httt)
	REFERENCES hinhthucthanhtoan

ALTER TABLE donhang
ADD CONSTRAINT FK_DH_KH
	FOREIGN KEY (dh_khachhang)
	REFERENCES khachhang

ALTER TABLE donhang
ADD CONSTRAINT FK_DH_NGH
	FOREIGN KEY (dh_ngh)
	REFERENCES nguoigiaohang

ALTER TABLE donhang
ADD CONSTRAINT FK_DH_TTDH
	FOREIGN KEY (dh_ttdh)
	REFERENCES tinhtrangdonhang

ALTER TABLE donhang_sanpham
ADD CONSTRAINT FK_DHSP_SP
	FOREIGN KEY (id_sp)
	REFERENCES sanpham

ALTER TABLE donhang_sanpham
ADD CONSTRAINT FK_DHSP_DH
	FOREIGN KEY (id_dh)
	REFERENCES donhang