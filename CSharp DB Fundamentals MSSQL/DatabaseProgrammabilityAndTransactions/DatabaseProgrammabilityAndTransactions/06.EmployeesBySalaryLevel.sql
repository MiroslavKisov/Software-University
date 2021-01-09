USE SoftUni

GO
CREATE PROC usp_EmployeesBysalaryLevel(@Level VARCHAR(50))
AS
	SELECT FirstName,
	        LastName
      FROM Employees
     WHERE dbo.ufn_GetSalaryLevel(Salary) = @Level