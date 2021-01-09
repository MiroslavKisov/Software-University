USE Bank

GO
CREATE PROC usp_DepositMoney(@AccountId INT, @MoneyAmount DECIMAL(18,4)) AS
BEGIN
	IF(@MoneyAmount >= 0)
	BEGIN
		UPDATE Accounts
		SET Balance += @MoneyAmount
		WHERE Id = @AccountId
	END
	ELSE
	BEGIN
	ROLLBACK
	END
END