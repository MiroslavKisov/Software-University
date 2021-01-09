USE ReportService

GO
CREATE TRIGGER tr_CompleteReport ON Reports FOR UPDATE
AS
  DECLARE @EmployeeId INT;

  SET @EmployeeId = (SELECT TOP 1 EmployeeId FROM inserted WHERE CloseDate IS NOT NULL)

  UPDATE Reports
  SET StatusId = 3
  WHERE EmployeeId = @EmployeeId 
  
