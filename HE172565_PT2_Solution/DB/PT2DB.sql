IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'MICHO')
BEGIN
	ALTER DATABASE MICHO SET OFFLINE WITH ROLLBACK IMMEDIATE;
	ALTER DATABASE MICHO SET ONLINE;
	DROP DATABASE MICHO;
END

GO

CREATE DATABASE MICHO;
GO
USE MICHO;
GO

CREATE TABLE Employee (
    EmpID INT PRIMARY KEY IDENTITY(1,1),
    EmpName NVARCHAR(100),
    IDCard NVARCHAR(20),
    Gender NVARCHAR(10),
    Address NVARCHAR(200),
    Phone NVARCHAR(20)
);

CREATE TABLE Customer (
    CustomerID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100),
    Address NVARCHAR(200),
    Contact NVARCHAR(20)
);

CREATE TABLE IceCream (
    IceID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100),
    Price DECIMAL(10,2),
    Flavor NVARCHAR(50),
    Color NVARCHAR(50)
);

CREATE TABLE [Order] (
    OrderID INT PRIMARY KEY IDENTITY(1,1),
    Status NVARCHAR(50),
    OrderDate DATETIME,
    CustomerID INT,
    EmpID INT,
    FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID),
    FOREIGN KEY (EmpID) REFERENCES Employee(EmpID)
);

CREATE TABLE OrderDetail (
    OrderDetailID INT PRIMARY KEY IDENTITY(1,1),
    OrderID INT,
    Quantity INT,
    TotalAmount DECIMAL(10,2),
    FOREIGN KEY (OrderID) REFERENCES [Order](OrderID)
);

CREATE TABLE OrderDetailIceCream (
    OrderDetailID INT,
    OrderID INT,
    IceID INT,
    PRIMARY KEY (OrderDetailID, OrderID, IceID),
    FOREIGN KEY (OrderDetailID) REFERENCES OrderDetail(OrderDetailID),
    FOREIGN KEY (OrderID) REFERENCES [Order](OrderID),
    FOREIGN KEY (IceID) REFERENCES IceCream(IceID)
);




-- Insert vào bảng Employee
INSERT INTO Employee (EmpName, IDCard, Gender, Address, Phone)
VALUES
('Nguyen Thi A', '123456789012', 'Female', '123 Street, District 1, HCM', '0123456789'),
('Tran Minh B', '234567890123', 'Male', '456 Street, District 3, HCM', '0987654321'),
('Le Thi C', '345678901234', 'Female', '789 Street, District 5, HCM', '0112233445'),
('Nguyen Hoang D', '456789012345', 'Male', '101 Street, District 10, HCM', '0192837465'),
('Pham Minh E', '567890123456', 'Male', '202 Street, District 7, HCM', '0654321987');

-- Insert vào bảng Customer
INSERT INTO Customer (Name, Address, Contact)
VALUES
('Nguyen Thi Mai', '11 Nguyen Trai, District 1, HCM', '0988776655'),
('Pham Lan H', '22 Le Lai, District 3, HCM', '0911223344'),
('Le Minh T', '33 Hai Ba Trung, District 5, HCM', '0922334455'),
('Nguyen Hieu S', '44 Ton Duc Thang, District 7, HCM', '0933445566'),
('Vu Thi B', '55 Bui Thi Xuan, District 10, HCM', '0977556688');

-- Insert vào bảng IceCream
INSERT INTO IceCream (Name, Price, Flavor, Color)
VALUES
('Vanilla Delight', 25.50, 'Vanilla', 'White'),
('Chocolate Dream', 30.00, 'Chocolate', 'Brown'),
('Strawberry Surprise', 28.00, 'Strawberry', 'Pink'),
('Mango Magic', 32.50, 'Mango', 'Yellow'),
('Pistachio Perfection', 35.00, 'Pistachio', 'Green');

-- Insert vào bảng [Order]
INSERT INTO [Order] (Status, OrderDate, CustomerID, EmpID)
VALUES
('Completed', '2025-06-20 10:00:00', 1, 1),
('Pending', '2025-06-21 12:30:00', 2, 2),
('Shipped', '2025-06-22 14:00:00', 3, 3),
('Cancelled', '2025-06-23 09:00:00', 4, 4),
('Completed', '2025-06-24 15:30:00', 5, 5);

-- Insert vào bảng OrderDetail
INSERT INTO OrderDetail (OrderID, Quantity, TotalAmount)
VALUES
(1, 3, 76.50),
(2, 2, 60.00),
(3, 5, 140.00),
(4, 1, 32.50),
(5, 4, 125.00);

-- Insert vào bảng OrderDetailIceCream
INSERT INTO OrderDetailIceCream (OrderDetailID, OrderID, IceID)
VALUES
(1, 1, 1),
(2, 2, 2),
(3, 3, 3),
(4, 4, 4),
(5, 5, 5);

