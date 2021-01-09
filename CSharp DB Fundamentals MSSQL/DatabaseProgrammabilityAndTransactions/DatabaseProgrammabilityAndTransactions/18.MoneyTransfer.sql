USE Bank

GO
CREATE PROC usp_TransferMoney(@SenderId INT, @ReceiverId INT, @Amount DECIMAL(18,4)) 
AS
BEGIN
	BEGIN TRANSACTION

	EXEC usp_WithdrawMoney @SenderId, @Amount
	EXEC usp_DepositMoney @ReceiverId, @Amount
	
	COMMIT
END
