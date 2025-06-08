USE [master]
GO

IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'PRN232DB')
BEGIN
	ALTER DATABASE PRN232DB SET OFFLINE WITH ROLLBACK IMMEDIATE;
	ALTER DATABASE PRN232DB SET ONLINE;
	DROP DATABASE PRN232DB;
END


CREATE DATABASE PRN232DB;
GO


USE PRN232DB;
GO


CREATE TABLE Employee (
    EmpID INT IDENTITY(1,1) PRIMARY KEY ,
    EmpName NVARCHAR(100),
    IDCard NVARCHAR(20),
    Gender NVARCHAR(10),
    Address NVARCHAR(255),
    Phone NVARCHAR(20)
);


CREATE TABLE [Order] (
    OrderID INT IDENTITY(1,1) PRIMARY KEY,
    Status NVARCHAR(50),
    OrderDate DATE,
    EmpID INT,
    FOREIGN KEY (EmpID) REFERENCES Employee(EmpID)
);


INSERT INTO Employee (EmpName, IDCard, Gender, Address, Phone)
VALUES
('Nguyen Van A', '123456789', 'Male', '123 A Street, Hanoi', '0901234567'),
('Le Thi B', '987654321', 'Female', '456 B Street, Ho Chi Minh City', '0912345678'),
('Tran Van C', '456789123', 'Male', '789 C Street, Da Nang', '0923456789');


INSERT INTO [Order] (Status, OrderDate, EmpID)
VALUES
('Delivered', '2025-05-20', 1),
('Pending', '2025-05-25', 2),
('Cancelled', '2025-05-28', 1),
('In Transit', '2025-06-01', 3),
('Delivered', '2025-06-02', 2);

