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



