USE Bank

GO
CREATE FUNCTION ufn_CalculateFutureValue(@Sum DECIMAL(18, 4), @YearlyInterestRate FLOAT, @NumberOfYears INT)
RETURNS DECIMAL(18, 4)
AS
BEGIN
	DECLARE @FutureValue DECIMAL(18, 4)
	SET @FutureValue = @Sum * POWER((1 + @YearlyInterestRate), @NumberOfYears)
	RETURN @FutureValue
END
