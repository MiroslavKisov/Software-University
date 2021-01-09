USE ReportService

GO
CREATE PROCEDURE usp_AssignEmployeeToReport(@employeeId INT, @reportId INT)
AS
BEGIN
	DECLARE @EmployeeDepartment INT;
	DECLARE @CategoryId INT;
	DECLARE @CategoryDepartment INT;

	SET @EmployeeDepartment = (SELECT DepartmentId FROM Employees WHERE Id = @employeeId)

	SET @CategoryId = (SELECT CategoryId FROM Reports WHERE Id = @reportId)

	SET @CategoryDepartment = (SELECT DepartmentId FROM Categories WHERE Id = @CategoryId)
	
	IF(@CategoryDepartment = @EmployeeDepartment)
	BEGIN
	     UPDATE Reports
	     SET EmployeeId = @employeeId
	     WHERE Id = @reportId
	END
	ELSE
	BEGIN
		RAISERROR('Employee doesn''t belong to the appropriate department!', 16 , 1)
		ROLLBACK
		RETURN
	END

END 