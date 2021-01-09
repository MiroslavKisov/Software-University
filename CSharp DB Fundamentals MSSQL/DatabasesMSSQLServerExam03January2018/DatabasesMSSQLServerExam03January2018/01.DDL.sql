USE RentACar

CREATE TABLE Clients(
	Id INT IDENTITY NOT NULL
	CONSTRAINT PK_Clients
	PRIMARY KEY (Id),

	FirstName NVARCHAR(30) NOT NULL,

	LastName NVARCHAR(30) NOT NULL,

	Gender CHAR(1) CHECK ((Gender = 'M') OR (Gender = 'F')),

	BirthDate DATETIME,

	CreditCard NVARCHAR(30) NOT NULL,

	CardValidity DATETIME,

	Email NVARCHAR(50) NOT NULL
)

CREATE TABLE Models(
	Id INT IDENTITY NOT NULL
	CONSTRAINT PK_Models
	PRIMARY KEY (Id),

	Manufacturer NVARCHAR(50) NOT NULL,

	Model NVARCHAR(50) NOT NULL,

	ProductionYear DATETIME,

	Seats INT,

	Class NVARCHAR(10),

	Consumption DECIMAL(14, 2)
)

CREATE TABLE Towns(
	Id INT IDENTITY NOT NULL
	CONSTRAINT PK_Towns
	PRIMARY KEY (Id),

	Name NVARCHAR(50) NOT NULL
)

CREATE TABLE Offices(
	Id INT IDENTITY NOT NULL
	CONSTRAINT PK_Offices
	PRIMARY KEY (Id),

	Name NVARCHAR(40),

	ParkingPlaces INT,

	TownId INT NOT NULL
	CONSTRAINT FK_Offices_Towns
	FOREIGN KEY (TownId)
	REFERENCES Towns(Id)
)

CREATE TABLE Vehicles(
	Id INT IDENTITY NOT NULL
	CONSTRAINT PK_Vehicles
	PRIMARY KEY (Id),

	ModelId INT NOT NULL
	CONSTRAINT FK_Vehicles_Models
	FOREIGN KEY (ModelId)
	REFERENCES Models(Id),

	OfficeId INT NOT NULL
	CONSTRAINT FK_Vehicles_Offices
	FOREIGN KEY (OfficeId)
	REFERENCES Offices(Id),

	Mileage INT
)

CREATE TABLE Orders(
	Id INT IDENTITY NOT NULL
	CONSTRAINT PK_Orders
	PRIMARY KEY (Id),

	ClientId INT NOT NULL
	CONSTRAINT FK_Orders_Clients
	FOREIGN KEY (ClientId) 
	REFERENCES Clients(Id),

	TownId INT NOT NULL
	CONSTRAINT FK_Orders_Towns
	FOREIGN KEY (TownId) 
	REFERENCES Towns(Id),

	VehicleId INT NOT NULL,
	CONSTRAINT FK_Orders_Vehicles
	FOREIGN KEY (VehicleId) 
	REFERENCES Vehicles(Id),

	CollectionDate DATETIME NOT NULL,

	CollectionOfficeId INT NOT NULL
	CONSTRAINT FK_Orders_CollectionOffices
	FOREIGN KEY (CollectionOfficeId) 
	REFERENCES Offices(Id),

	ReturnDate DATETIME,

	ReturnOfficeId INT
	CONSTRAINT FK_Orders_ReturnOffices
	FOREIGN KEY (ReturnOfficeId) 
	REFERENCES Offices(Id),

	Bill DECIMAL(14,2),

	TotalMileage INT 
)

DROP TABLE Orders

DROP TABLE Vehicles

DROP TABLE Offices

DROP TABLE Towns

DROP TABLE Models

DROP TABLE Clients