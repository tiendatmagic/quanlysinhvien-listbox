create database QuanLySinhVien 

use QuanLySinhVien

create table SinhVien (
MaSV nchar(10) not null,
TenSV varchar(20),
Email nvarchar(50),
MaKhoa nchar(10) not null,
primary key(MaSV),
)

insert into SinhVien values ('SV01','Tran Van A','aa@gmail.com','KH01')
insert into SinhVien values ('SV02','Nguyen B','bb@gmail.com','KH02')
insert into SinhVien values ('SV03','Tran C','cc@gmail.com','KH01')

create table Khoa (
MaKhoa nchar(10) not null,
TenKhoa nvarchar(50),
primary key(MaKhoa),
)

insert into Khoa values ('KH01',N'Công Nghệ Thông Tin')
insert into Khoa values ('KH02',N'Cơ khí')