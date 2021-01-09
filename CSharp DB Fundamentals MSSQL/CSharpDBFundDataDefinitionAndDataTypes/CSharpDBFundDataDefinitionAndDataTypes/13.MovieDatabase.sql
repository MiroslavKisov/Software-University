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