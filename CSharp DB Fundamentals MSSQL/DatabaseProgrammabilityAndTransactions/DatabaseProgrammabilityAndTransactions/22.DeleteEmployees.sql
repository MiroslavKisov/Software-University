USE SoftUni

GO
CREATE TRIGGER tr_DelEmp ON Employees 
FOR DELETE AS
BEGIN
	INSERT INTO Deleted_Employees
	SELECT FirstName, LastName, MiddleName, JobTitle, DepartmentID, Salary
	  FROM deleted
END

		