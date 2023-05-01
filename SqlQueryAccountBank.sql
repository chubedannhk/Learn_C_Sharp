create database x 
go

use AccountBank 
go

create table Account
(
	AccID int primary key identity,
	Username varchar(250),
	Password varchar(250),
	Fullname varchar(250),
	Email varchar(250),
	Phone varchar(250),
	Balance decimal
)
go

create table TransactionDetails 
(
	TransId int primary key identity,
	AccID int,
	TransMonry decimal,
	TransType int,
	DateOfTrans date default getdate()
)
go
ALTER TABLE TransactionDetails ADD CONSTRAINT fk_Trans_Acc FOREIGN KEY (AccID) REFERENCES Account (AccID);

ALTER TABLE Account
ADD Balance decimal DEFAULT 0;

select * from TransactionDetails where AccID = 1 and TransType = 2