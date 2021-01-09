CREATE DATABASE CarRental
USE CarRental


CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName VARCHAR(30) NOT NULL,
	DailyRate decimal(15, 2) NOT NULL,
	WeeklyRate decimal(15, 2) NOT NULL,
	MonthlyRate decimal(15, 2) NOT NULL,
	WeekendRate decimal(15, 2) NOT NULL
)


CREATE TABLE Cars(
	Id INT PRIMARY KEY IDENTITY,
	PlateNumber VARCHAR(10) NOT NULL,
	Manufacturer VARCHAR(20) NOT NULL,
	Model NVARCHAR(20) NOT NULL,
	CarYear DATE NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	Doors INT,
	Picture VARBINARY(MAX),
	Condition VARCHAR(20),
	Available BIT NOT NULL
)


CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(30) NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	Title NVARCHAR(30),
	Notes NVARCHAR(MAX)
)


CREATE TABLE Customers(
	Id INT PRIMARY KEY IDENTITY,
	DriverLicenceNumber VARCHAR(30) NOT NULL,
	FullName VARCHAR(50) NOT NULL,
	Address NVARCHAR(50) NOT NULL,
	City VARCHAR(15) NOT NULL,
	ZIPCode INT NOT NULL,
	Notes NVARCHAR(50)
)


CREATE TABLE RentalOrders(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	CustomerId INT FOREIGN KEY REFERENCES Customers(Id),
	CarId INT FOREIGN KEY REFERENCES Cars(Id),
	TankLevel DECIMAL(15,2) NOT NULL,
	KilometrageStart INT NOT NULL,
	KilometrageEnd INT NOT NULL,
	TotalKilometrage INT NOT NULL,
	StartDate DATETIME NOT NULL,
	EndDate DATETIME NOT NULL,
	TotalDays INT NOT NULL,
	RateApplied INT,
	TaxRate DECIMAL (15,2),
	OrderStatus VARCHAR(20),
	Notes NVARCHAR(MAX) 
)


INSERT INTO Categories(CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate) VALUES
('Sport Cars', 15.22, 20.33, 45.55, 12.33),
('Tourist Cars', 156.22, 20.33, 475.55, 12.33),	
('Campers', 115.22, 20.33, 45.55, 122.33)


INSERT INTO Cars (PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available) VALUES
('MBX 999', 'GMC', 'ADX 2.0L', '12-12-2008', 1, 4, NULL, 'Good', 1),
('BMW 777', 'BMW', 'M3 3.2L', '12-12-2008', 2, 3, NULL, 'Good', 0),
('BG 123', 'LADA', 'SAMARA 1.3L', '12-12-2008', 3, 4, NULL, 'Poor', 1)


INSERT INTO Employees(FirstName, LastName, Title, Notes) VALUES
('Pesho', 'Peshov', 'BlaBla', NULL),
('Gosho', 'Peshov', 'BlaBla', NULL),
('Tosho', 'Goshev', 'BlaBla', NULL)


INSERT INTO Customers(DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes) VALUES
('MBX 999', 'Pesho Peshov', 'BlaBla', 'Sofia', 1324, NULL),
('BMW 777', 'Gosho Peshov', 'BlaBla', 'Sofia', 1324, NULL),
('BG 123', 'Tosho Goshev', 'BlaBla', 'Sofia', 1324, NULL)


INSERT INTO RentalOrders(EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes) VALUES
(1, 2, 3, 12.5, 12, 12, 12, '12-12-2008', '12-12-2008', 12, NULL, NULL, NULL, NULL),
(1, 2, 3, 12.5, 12, 12, 12, '12-12-2008', '12-12-2008', 12, NULL, NULL, NULL, NULL),
(1, 2, 3, 12.5, 12, 12, 12, '12-12-2008', '12-12-2008', 12, NULL, NULL, NULL, NULL)