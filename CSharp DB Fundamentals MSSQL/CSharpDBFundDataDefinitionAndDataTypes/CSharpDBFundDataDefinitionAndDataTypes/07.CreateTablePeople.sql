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



