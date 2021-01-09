USE Bank

GO
CREATE PROC usp_WithdrawMoney(@AccountId INT, @MoneyAmount DECIMAL(18, 4)) 
AS
BEGIN
    BEGIN TRANSACTION
	
	UPDATE Accounts
	SET Balance -= @MoneyAmount
	WHERE Id = @AccountId
	
	IF(@@ROWCOUNT <> 1)
	BEGIN
		ROLLBACK
		RETURN
	END

	DECLARE @Balance DECIMAL(18,4) = (SELECT Balance FROM Accounts WHERE Id = @AccountId)
	IF(@Balance < 0)
	BEGIN
		ROLLBACK
		RETURN
	END

	COMMIT
END