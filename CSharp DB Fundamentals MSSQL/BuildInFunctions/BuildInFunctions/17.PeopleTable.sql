USE Orders

GO
CREATE TABLE People(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(50) NOT NULL,
	BirthDate DATETIME NOT NULL
)

INSERT INTO People(Name, BirthDate) VALUES
('Victor', '12-07-2000'),
('Steven', '09-10-1992'),
('Stephen', '09-10-1910'),
('John', '01-06-2010')

GO
SELECT Id, Name ,BirthDate,
DATEDIFF(YEAR, BirthDate, GETDATE()) AS [Age In Years],
DATEDIFF(MONTH, BirthDate, GETDATE()) AS [Age In Months],
DATEDIFF(DAY, BirthDate, GETDATE()) AS [Age In Days],
DATEDIFF(MINUTE, BirthDate, GETDATE()) AS [Age In Minutes]
  FROM People