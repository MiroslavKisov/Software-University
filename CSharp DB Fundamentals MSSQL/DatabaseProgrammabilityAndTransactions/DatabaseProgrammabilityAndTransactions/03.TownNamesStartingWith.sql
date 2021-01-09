USE SoftUni

GO
CREATE PROC usp_GetTownsStartingWith(@StartString VARCHAR(50))
AS
BEGIN
	SELECT Name
      FROM Towns
     WHERE Name LIKE @StartString + '%' 
END