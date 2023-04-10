create database QuanLyHoaDon
go

use QuanLyHoaDon 
go

create table Customer
(
	Id int identity primary key,
	name varchar(250),
	address varchar(250),
	birthday date,
	phone varchar(20)
)
go

create table Orders
(
	Id int identity primary key,
	name varchar(250),
	datecreation date,
	status bit,
	payments varchar(250),
	customerid int
)
go

ALTER TABLE Orders
ADD CONSTRAINT fk_Orders_Customer
  FOREIGN KEY (customerid)
  REFERENCES customer (id)


  select * from Customer