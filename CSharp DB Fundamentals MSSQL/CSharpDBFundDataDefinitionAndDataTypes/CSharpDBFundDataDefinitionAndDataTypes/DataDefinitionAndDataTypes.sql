--PROBLEM 01
CREATE DATABASE Minions

--PROBLEM 02
USE Minions

CREATE TABLE Minions(
	Id INT PRIMARY KEY NOT NULL,
	Name NVARCHAR(50) NOT NULL,
	Age INT
)

CREATE TABLE Towns(
	Id INT PRIMARY KEY NOT NULL,
	Name NVARCHAR(50) NOT NULL
)

--PROBLEM 03
USE Minions

ALTER TABLE Minions
ADD TownId INT FOREIGN KEY REFERENCES Towns(Id)

--PROBLEM 04
Use Minions

INSERT INTO Towns (Id, Name) VALUES
(1,'Sofia'),
(2,'Plovdiv'),
(3,'Varna')

INSERT INTO Minions (Id, Name, Age, TownId) VALUES
(1,'Kevin',22,1),
(2,'Bob',15,3),
(3,'Steward',NULL,2)

--PROBLEM 05
USE Minions

DELETE Minions

DELETE Towns

--PROBLEM 06
USE Minions

DROP TABLE Minions

DROP TABLE Towns

--PROBLEM 07
USE Minions

CREATE TABLE People(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX),
	Height DECIMAL (15,2),
	Weight DECIMAL (15,2),
	Gender CHAR(1) CHECK (Gender = 'm' OR Gender = 'f') NOT NULL,
	Birthdate DATE NOT NULL,
	Biography NVARCHAR(MAX)
)

INSERT INTO People (Name, Picture, Height, Weight, Gender, Birthdate, Biography) VALUES
('Pesho',NULL,12.34,23.34,'m','12-12-2006',NULL),
('Gosho',NULL,12.34,23.34,'m','12-12-2006',NULL),
('Sasho',NULL,12.34,23.34,'m','12-12-2006',NULL),
('Misho',NULL,12.34,23.34,'m','12-12-2006',NULL),
('Tosho',NULL,12.34,23.34,'m','12-12-2006',NULL)

--PROBLEM 08
USE Minions

CREATE TABLE Users(
	Id BIGINT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) UNIQUE NOT NULL,
	Password VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX),
	LastLoginTime DATETIME,
	IsDeleted BIT 
)

INSERT INTO Users (Username, Password, ProfilePicture, LastLoginTime, IsDeleted) VALUES
('Pesho', '12345', NULL, NULL, 1),
('Gosho', '12345', NULL, NULL, 0),
('Misho', '12345', NULL, NULL, 0),
('Tosho', '12345', NULL, NULL, 1),
('Kiro', '12345', NULL, NULL, 1)

--PROBLEM 09
USE Minions

ALTER TABLE Users
DROP CONSTRAINT [PK__Users__3214EC07C1363DA0]

ALTER TABLE Users
ADD CONSTRAINT PK_Users
PRIMARY KEY (Id, Username) 

--PROBLEM 10
USE Minions

ALTER TABLE Users
ADD CONSTRAINT CH_Users
CHECK (Password >= 5)

--PROBLEM 11
USE Minions

ALTER TABLE Users
ADD DEFAULT GETDATE()
FOR LastLoginTime

--PROBLEM 12
USE Minions

ALTER TABLE Users
DROP CONSTRAINT PK_Users

ALTER TABLE Users
ADD CONSTRAINT PK_Users
PRIMARY KEY(Id)

ALTER TABLE Users
ADD CONSTRAINT UK_Users
UNIQUE (Username)

--PROBLEM 13
CREATE DATABASE Movies

USE Movies

CREATE TABLE Directors(
	Id INT PRIMARY KEY IDENTITY,
	DirectorName VARCHAR(30) NOT NULL,
	Notes NVARCHAR(MAX) 
)

CREATE TABLE Genres(
	Id INT PRIMARY KEY IDENTITY,
	GenreName VARCHAR(30) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName VARCHAR(30) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Movies(
	Id INT PRIMARY KEY IDENTITY,
	DirectorId INT FOREIGN KEY REFERENCES Directors(Id),
	Title VARCHAR(30) NOT NULL,
	CopyrightYear DATE,
	Length INT,
	GenreId INT FOREIGN KEY REFERENCES Genres(Id),
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id), 
	Rating INT,
	Notes NVARCHAR(MAX)
)

INSERT INTO Directors(DirectorName, Notes) VALUES
('Pesho',NULL),
('Gosho',NULL),
('Tosho',NULL),
('Ivan',NULL),
('Stoqn',NULL)

INSERT INTO Genres (GenreName, Notes) VALUES
('Horror',NULL),
('Drama',NULL),
('Action',NULL),
('Comedy',NULL),
('Sci-Fi',NULL)

INSERT INTO Categories(CategoryName, Notes) VALUES
('First',NULL),
('Second',NULL),
('Third',NULL),
('Fourth',NULL),
('Fifth',NULL)

--Id, Title, DirectorId, CopyrightYear, Length, GenreId, CategoryId, Rating, Notes 

INSERT INTO Movies(Title, DirectorId, CopyrightYear, Length, GenreId, CategoryId, Rating, Notes) VALUES
('The Adventures Of Pesho', 1 , '12-12-2000', 120, 1, 1, 5, NULL),
('The Adventures Of Pesho', 2 , '12-12-2000', 120, 2, 2, 5, NULL),
('The Adventures Of Pesho', 3 , '12-12-2000', 120, 3, 3, 5, NULL),
('The Adventures Of Pesho', 4 , '12-12-2000', 120, 4, 4, 5, NULL),
('The Adventures Of Pesho', 5 , '12-12-2000', 120, 5, 5, 5, NULL)

--PROBLEM 14
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

--PROBLEM 15
CREATE DATABASE Hotel

USE Hotel


CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Title NVARCHAR(50),
	Notes NVARCHAR(MAX)
)

INSERT INTO Employees(FirstName, LastName, Title, Notes) VALUES
('Johny', 'Bravo', 'Doorman', 'Good lookin dude'),
('Snoop', 'Dogg', 'PIMP', NULL),
('Pesho', 'Peshov', 'Room Service', 'Lazy Bastard')


CREATE TABLE Customers(
	AccountNumber INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	PhoneNumber INT NOT NULL,
	EmergencyName NVARCHAR(50),
	EmergencyNumber INT,
	Notes NVARCHAR(MAX)
)

INSERT INTO Customers(FirstName, LastName, PhoneNumber, EmergencyName,
EmergencyNumber, Notes) VALUES
('James', 'Smith', 123321, 'ZeroOne', 555, NULL),
('Rico', 'Trejo', 12451, 'Zigzag', 555, NULL), 
('James', 'Smith', 1261, 'AliBaba', 555, NULL)
 
CREATE TABLE RoomStatus(
	RoomStatus NVARCHAR(50) PRIMARY KEY NOT NULL,
	Notes NVARCHAR(MAX)
)
 
INSERT INTO RoomStatus(RoomStatus, Notes) VALUES
('A', NULL),
('B', NULL),
('C', NULL)
 
CREATE TABLE RoomTypes(
	RoomType NVARCHAR(50) PRIMARY KEY NOT NULL,
	Notes NVARCHAR(MAX)
) 

INSERT INTO RoomTypes(RoomType, Notes) VALUES
('X', NULL),
('Y', NULL),
('Z', NULL)

CREATE TABLE BedTypes(
	BedType NVARCHAR(50) PRIMARY KEY NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO BedTypes(BedType, Notes) VALUES
('AA', NULL),
('BB', NULL),
('CC', NULL)

CREATE TABLE Rooms(
	RoomNumber INT PRIMARY KEY IDENTITY NOT NULL,
	RoomType NVARCHAR(50) FOREIGN KEY REFERENCES RoomTypes(RoomType),
	BedType NVARCHAR(50) FOREIGN KEY REFERENCES BedTypes(BedType),
	Rate DECIMAL(15,2) NOT NULL,
	RoomStatus NVARCHAR(50) FOREIGN KEY REFERENCES RoomStatus(RoomStatus),
	Notes NVARCHAR(MAX)	 
)

INSERT INTO Rooms(RoomType, BedType, Rate, RoomStatus, Notes) VALUES
('X', 'AA', 12.33, 'A', NULL),
('Y', 'BB', 12.33, 'B', NULL),
('Z', 'CC', 12.33, 'C', NULL)

CREATE TABLE Payments(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	PaymentDate DATE NOT NULL,
	AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber),
	FirstDateOccupied DATE NOT NULL,
	LastDateOccupied DATE NOT NULL,
	TotalDays AS DATEDIFF(DAY, FirstDateOccupied, LastDateOccupied),
	AmmountCharged DECIMAL(15,2),
	TaxRate DECIMAL(15,2),
	TaxAmount DECIMAL(15,2),
	PaymentTotal DECIMAL(15,2),
	Notes NVARCHAR(MAX)
)

INSERT INTO Payments(EmployeeId, PaymentDate, 
AccountNumber, FirstDateOccupied, LastDateOccupied,
AmmountCharged, Taxrate, TaxAmount, PaymentTotal, Notes) VALUES
(1, GETDATE(), 1, GETDATE(), GETDATE(), 12.34, 12.34, 100.00, 122.22, NULL),
(2, GETDATE(), 2, GETDATE(), GETDATE(), 12.34, 12.34, 100.00, 122.22, NULL),
(3, GETDATE(), 3, GETDATE(), GETDATE(), 12.34, 12.34, 100.00, 122.22, NULL)

CREATE TABLE Occupancies(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	DateOccupied DATE NOT NULL,
	AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber),
	RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber),
	RateApplied DECIMAL(15,2),
	PhoneCharge DECIMAL(15,2),
	Notes NVARCHAR(MAX) 
)

INSERT INTO Occupancies(EmployeeId, DateOccupied, AccountNumber, 
RoomNumber, RateApplied, PhoneCharge, Notes) VALUES
(1, GETDATE(), 1, 1, 12.33, 12.33, NULL),
(2, GETDATE(), 2, 2, 12.33, 12.33, NULL),
(3, GETDATE(), 3, 3, 12.33, 12.33, NULL)

--PROBLEM 16
CREATE DATABASE SoftUni

USE SoftUni

--
CREATE TABLE Towns(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Name NVARCHAR(50) NOT NULL
)

--Id, AddressText, TownId
CREATE TABLE Addresses(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	AddressText NVARCHAR(50) NOT NULL,
	TownId INT FOREIGN KEY REFERENCES Towns(Id)
)

--Id, Name
CREATE TABLE Departments(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Name NVARCHAR(50) NOT NULL
)

--(Id, FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary, AddressId
CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	JobTitle NVARCHAR(50) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id),
	HireDate DATE NOT NULL,
	Salary DECIMAL(15, 2) NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
)

--PROBLEM 17
BACKUP DATABASE SoftUni
TO DISK = 'C:\BackUp\softuni-backup.bak'

DROP DATABASE SoftUni

RESTORE DATABASE SoftUni
FROM DISK = 'C:\BackUp\softuni-backup.bak'

--PROBLEM 18
USE SoftUni

INSERT INTO Towns(Name) VALUES
('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas')

--Engineering, Sales, Marketing, Software Development, Quality Assurance
INSERT INTO Departments(Name) VALUES
('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Quality assurance')

--
INSERT INTO Employees(FirstName, MiddleName, LastName, JobTitle,
 DepartmentId, HireDate, Salary) VALUES
('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '01-02-2013', 3500.00),
('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '02-03-2004', 4000.00),
('Maria', 'Patrova', 'Ivanova', 'Intern', 5, '08-28-2016', 525.25),
('Georgi', 'Terziev', 'Ivanov', 'CEO', 2, '09-12-2007', 3000.00),
('Peter', 'Pan', 'Pan', 'Intern', 3, '08-28-2016', 3500.00)

--PROBLEM 19
USE SoftUni

SELECT * FROM Towns

SELECT * FROM Departments

SELECT * FROM Employees

--PROBLEM 20
USE SoftUni

SELECT * FROM Towns
ORDER BY Name ASC

SELECT * FROM Departments
ORDER BY Name ASC

SELECT * FROM Employees
ORDER BY Salary DESC

--PROBLEM 21
USE SoftUni

SELECT Name FROM Towns
ORDER BY Name ASC

SELECT Name FROM Departments
ORDER BY Name ASC

SELECT FirstName, LastName, JobTitle, Salary FROM Employees
ORDER BY Salary DESC

--PROBLEM 22
USE SoftUni

UPDATE Employees
SET Salary = Salary + (Salary * 0.10)
WHERE Id = 1

UPDATE Employees
SET Salary = Salary + (Salary * 0.10)
WHERE Id = 2

UPDATE Employees
SET Salary = Salary + (Salary * 0.10)
WHERE Id = 3

UPDATE Employees
SET Salary = Salary + (Salary * 0.10)
WHERE Id = 4

UPDATE Employees
SET Salary = Salary + (Salary * 0.10)
WHERE Id = 5

SELECT Salary FROM Employees

--PROBLEM 23
USE Hotel

UPDATE Payments
SET TaxRate *= 0.97, TaxAmount *= 0.97
WHERE Id = 1

UPDATE Payments
SET TaxRate *= 0.97, TaxAmount *= 0.97
WHERE Id = 2

UPDATE Payments
SET TaxRate *= 0.97, TaxAmount *= 0.97
WHERE Id = 3

SELECT TaxRate FROM Payments

--PROBLEM 24
USE Hotel

DELETE Occupancies