drop database Arkanis;

create database Arkanis;

use Arkanis;


CREATE TABLE Product (
    id					int not null AUTO_INCREMENT,
    code			nvarchar(100) not null,
    name			nvarchar(100) not null,
    description	nvarchar(250),
    unitPrice		decimal not null,
    unitsInStock int not null,
    unitsOrdered int not null,
    status			int not null,
    createdOn	datetime not null,
    createdBy	nvarchar(100) not null,
    updatedOn	datetime,
    updatedBy	nvarchar(100),
    PRIMARY KEY (id)
);

CREATE TABLE Category (
    id					int not null AUTO_INCREMENT,
    name			nvarchar(100) not null,
    description	nvarchar(250),
    status 			int not null,
    createdOn	datetime not null,
    createdBy	nvarchar(100) not null,
    updatedOn	datetime,
    updatedBy	nvarchar(100),
    PRIMARY KEY (id)
);

CREATE TABLE ProductCategory (
    productId		int not null,
    categoryId	int not null,
    createdOn	datetime not null,
    createdBy	nvarchar(100) not null,
    updatedOn	datetime,
    updatedBy	nvarchar(100),
    PRIMARY KEY (productId, categoryId)
);

ALTER TABLE ProductCategory
ADD CONSTRAINT FK_ProductCategory_Product_ProductId
FOREIGN KEY (productId) REFERENCES Product(id) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE ProductCategory
ADD CONSTRAINT FK_ProductCategory_Category_CategoryId
FOREIGN KEY (categoryId) REFERENCES Category(id) ON DELETE CASCADE ON UPDATE CASCADE;


CREATE TABLE Customer (
    id					int not null AUTO_INCREMENT,
    firstName		nvarchar(100) not null,
    lastName		nvarchar(100) not null,
    displayname nvarchar(100) not null,
    email			nvarchar(250) not null,
    phone			nvarchar(70),
    createdOn	datetime not null,
    createdBy	nvarchar(100) not null,
    updatedOn	datetime,
    updatedBy	nvarchar(100),
    PRIMARY KEY (id)
);

CREATE TABLE Address (
	id						int not null AUTO_INCREMENT,
    addressLine1	nvarchar(100) not null,
    addressLine2	nvarchar(100),
    addressLine3	nvarchar(100),
    city					nvarchar(100) not null,
    postCode			nvarchar(50) not null,
    province			nvarchar(100),
    country			nvarchar(100),
    phone				nvarchar(50),
    createdOn		datetime not null,
    createdBy		nvarchar(100) not null,
    updatedOn		datetime,
    updatedBy		nvarchar(100),
    PRIMARY KEY (id)
);

CREATE TABLE CustomerAddress (
    customerId	int not null,
    addressId	int not null,
    status			int not null,
    createdOn	datetime not null,
    createdBy	nvarchar(100) not null,
    updatedOn	datetime,
    updatedBy	nvarchar(100),
    PRIMARY KEY (customerId, addressId)
);

ALTER TABLE CustomerAddress
ADD CONSTRAINT FK_CustomerAddress_Customer_CustomerId
FOREIGN KEY (customerId) REFERENCES Customer(id) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE CustomerAddress
ADD CONSTRAINT FK_CustomerAddress_Address_AddressId
FOREIGN KEY (addressId) REFERENCES Address(id) ON DELETE CASCADE ON UPDATE CASCADE;


CREATE TABLE Orders (
    id					int not null AUTO_INCREMENT,
    name			nvarchar(100) not null,
    orderDate	datetime not null,
    requiredDate	datetime not null,
    shippedDate	datetime,
    deliveredDate  datetime,
    email			nvarchar(250) not null,
    createdOn	datetime not null,
    createdBy	nvarchar(100) not null,
    updatedOn	datetime,
    updatedBy	nvarchar(100),
    PRIMARY KEY (id)
);

CREATE TABLE CustomerOrders (
    customerId	int not null,
    orderId			int not null,
    status			int not null,
    PRIMARY KEY (customerId, orderId)
);

ALTER TABLE CustomerOrders
ADD CONSTRAINT FK_CustomerOrders_Customer_CustomerId
FOREIGN KEY (customerId) REFERENCES Customer(id) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE CustomerOrders
ADD CONSTRAINT FK_CustomerOrders_Orders_OrderId
FOREIGN KEY (orderId) REFERENCES Orders(id) ON DELETE CASCADE ON UPDATE CASCADE;

CREATE TABLE OrderDetail (
	id				int not null auto_increment,
    orderId 	int not null,
    productId int not null,
    quantity	int not null,
    unitPrice	decimal not null,
    discount	decimal not null,
    comments	nvarchar(500),
    createdOn	datetime not null,
    createdBy	nvarchar(100) not null,
    updatedOn	datetime,
    updatedBy	nvarchar(100),
    PRIMARY KEY (id)
);

ALTER TABLE OrderDetail
ADD CONSTRAINT FK_OrderDetail_Orders_OrderId
FOREIGN KEY (orderId) REFERENCES Orders(id) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE OrderDetail
ADD CONSTRAINT FK_OrderDetail_Product_ProductId
FOREIGN KEY (productId) REFERENCES Product(id) ON DELETE CASCADE ON UPDATE CASCADE;









































