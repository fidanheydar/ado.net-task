CREATE DATABASE Kfc
Use Kfc

 CREATE TABLE Categoryes(
Id INT PRIMARY KEY IDENTITY,
Name NVARCHAR(30)
)

CREATE TABLE Products(
Id INT PRIMARY KEY IDENTITY,
Name NVARCHAR(30),
CategoryId INT FOREIGN KEY REFERENCES Categoryes(Id)
)

INSERT INTO Categoryes
VALUES('Meal'),
('Drink')

INSERT INTO Products
VALUES('Burger',1),
('Soda',1)


SELECT C.Id 'CategoryId', C.Name 'CategoryName',P.Name 'ProductName' from Categoryes as C LEFT JOIN Products as P ON C.Id=P.CategoryId 
SELECT * FROM Categoryes
SELECT * FROM Products