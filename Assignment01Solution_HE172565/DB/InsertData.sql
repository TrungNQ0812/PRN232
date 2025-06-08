INSERT INTO Categories (CategoryName) VALUES 
('Beverages'),
('Snacks'),
('Electronics');


INSERT INTO Members (Email, CompanyName, City, Country, Password) VALUES 
('admin@estore.com', 'Admin Co', 'Hanoi', 'Vietnam', 'admin@@'),
('user1@example.com', 'User Co', 'Ho Chi Minh', 'Vietnam', 'user123'),
('user2@example.com', 'Another Co', 'Da Nang', 'Vietnam', 'pass456');


INSERT INTO Products (CategoryId, ProductName, Weight, UnitPrice, UnitsInStock) VALUES 
(1, 'Coca Cola', '330ml', 10.0, 100),
(1, 'Pepsi', '330ml', 9.5, 150),
(2, 'Oreo', '150g', 5.5, 200),
(3, 'iPhone 14', '1 unit', 999.99, 10);


INSERT INTO Orders (MemberId, OrderDate, RequiredDate, ShippedDate, Freight) VALUES 
(2, GETDATE(), GETDATE() + 3, GETDATE() + 1, 15.00),
(3, GETDATE(), GETDATE() + 5, NULL, 10.00);


INSERT INTO OrderDetails (OrderId, ProductId, UnitPrice, Quantity, Discount) VALUES 
(1, 1, 10.0, 2, 0),
(1, 2, 9.5, 1, 0.1),
(2, 3, 5.5, 5, 0);
