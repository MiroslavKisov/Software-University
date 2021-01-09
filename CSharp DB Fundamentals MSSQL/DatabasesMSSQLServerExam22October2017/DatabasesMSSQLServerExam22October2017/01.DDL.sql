USE ReportService

CREATE TABLE Users(
	Id INT IDENTITY NOT NULL
	CONSTRAINT PK_Users
	PRIMARY KEY (Id),

	Username NVARCHAR(30) UNIQUE NOT NULL,

	Password NVARCHAR(50) NOT NULL,

	Name NVARCHAR(50),
	
	Gender CHAR(1) CHECK ((Gender = 'M') OR (Gender = 'F')),
	
	BirthDate DATETIME,
	
	Age INT,
	
	Email NVARCHAR(50) NOT NULL  
)

CREATE TABLE Status(
	Id INT IDENTITY NOT NULL
	CONSTRAINT PK_Status
	PRIMARY KEY (Id),

	Label VARCHAR(30) NOT NULL
)

CREATE TABLE Departments(
	Id INT IDENTITY NOT NULL
	CONSTRAINT PK_Departments
	PRIMARY KEY (Id),

	Name NVARCHAR(50) NOT NULL,
)

CREATE TABLE Employees(
	Id INT IDENTITY NOT NULL
	CONSTRAINT PK_Employees
	PRIMARY KEY (Id),

	FirstName NVARCHAR(25),

	LastName NVARCHAR(25),

	Gender CHAR(1) CHECK ((Gender = 'M') OR (Gender = 'F')),

	BirthDate DATETIME,

	Age INT,

	DepartmentId INT NOT NULL,
	CONSTRAINT FK_Employees_Departments
	FOREIGN KEY (DepartmentId)
	REFERENCES Departments(Id)
)

CREATE TABLE Categories(
	Id INT IDENTITY NOT NULL,
	CONSTRAINT PK_Categories
	PRIMARY KEY (Id),

	Name VARCHAR(50) NOT NULL,

	DepartmentId INT
	CONSTRAINT FK_Categories_Departments
	FOREIGN KEY (DepartmentId)
	REFERENCES Departments(Id)
)

CREATE TABLE Reports(
	Id INT IDENTITY NOT NULL
	CONSTRAINT PK_Reports
	PRIMARY KEY (Id),

	CategoryId INT NOT NULL
	CONSTRAINT FK_Reports_Categories
	FOREIGN KEY (CategoryId)
	REFERENCES Categories(Id),
	
	StatusId INT NOT NULL
	CONSTRAINT FK_Reports_Status
	FOREIGN KEY (StatusId)
	REFERENCES Status(Id),
	
	OpenDate DATETIME NOT NULL,
	
	CloseDate DATETIME,
	
	Description VARCHAR(200),
	
	UserId INT NOT NULL
	CONSTRAINT FK_Reports_Users
	FOREIGN KEY (UserId)
	REFERENCES Users(Id),
	
	EmployeeId INT
	CONSTRAINT FK_Report_Employees
	FOREIGN KEY (EmployeeId)
	REFERENCES Employees(Id)   
)

DROP TABLE Reports

DROP TABLE Employees

DROP TABLE Categories

DROP TABLE Departments

DROP TABLE Users

DROP TABLE Status