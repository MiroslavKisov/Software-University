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