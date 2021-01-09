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