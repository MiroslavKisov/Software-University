USE SoftUni

GO
CREATE PROC usp_AssignProject(@EmployeeID INT, @ProjectID INT) AS
BEGIN
	BEGIN TRANSACTION

	INSERT INTO EmployeesProjects(EmployeeID, ProjectID) VALUES
	(@EmployeeId, @ProjectID)

	DECLARE @ProjectCount INT = (SELECT COUNT(ProjectID) FROM EmployeesProjects WHERE EmployeeID = @EmployeeID)
	IF(@ProjectCount > 3)
	BEGIN
		RAISERROR('The employee has too many projects!', 16, 1)
		ROLLBACK
		RETURN 
	END

	COMMIT

END
