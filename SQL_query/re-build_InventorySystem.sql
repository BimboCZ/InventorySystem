use pv_dinh;

create table Login
(
	id int primary key identity(1,1),
	Username nvarchar(50) not null,
	Password nvarchar(50) null
);

create table Products
(
	id int primary key identity(1,1),
	ProductCode int not null,
	ProductName nvarchar(50) null,
	ProductStatus bit null
);

create table Stock
(
	id int primary key identity(1,1),
	TransDate datetime null,
	Quantity float null,
	constraint fk_Products foreign key(id) references Products(id)
);

-- add values to the database
insert into Login
values('admin','admin');
