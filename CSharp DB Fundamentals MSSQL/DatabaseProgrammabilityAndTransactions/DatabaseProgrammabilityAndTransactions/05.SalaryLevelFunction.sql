USE SoftUni

GO
CREATE FUNCTION ufn_GetSalaryLevel(@Salary DECIMAL(18,4))
RETURNS VARCHAR(50)
AS
BEGIN
	DECLARE @Level VARCHAR(50)
SET @Level =
	CASE 
		WHEN @Salary < 30000 THEN 'Low'
		WHEN @Salary >= 30000 AND @Salary <= 50000 THEN 'Average'
		WHEN @Salary > 50000 THEN 'High'
	END
	RETURN @Level
END

