USE SoftUni

GO
CREATE PROC usp_GetEmployeesSalaryAboveNumber(@AboveNumber DECIMAL(18, 4))
AS
BEGIN
	SELECT FirstName, LastName
	  FROM Employees
	 WHERE Salary >= @AboveNumber
END
