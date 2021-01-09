USE ReportService

GO
CREATE FUNCTION udf_GetReportsCount(@employeeId INT, @statusId INT)
RETURNS INT
AS
BEGIN
	DECLARE @CountOfReportsByStatus INT;
	SET @CountOfReportsByStatus =  (SELECT COUNT(*) 
                                      FROM Reports AS r
                                      WHERE r.StatusId = @statusId AND r.EmployeeId = @employeeId)

	RETURN @CountOfReportsByStatus

END





