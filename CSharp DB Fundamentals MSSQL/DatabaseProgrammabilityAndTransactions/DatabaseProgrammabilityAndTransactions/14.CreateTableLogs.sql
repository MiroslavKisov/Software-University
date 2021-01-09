USE Bank

CREATE TABLE Logs(
	LogId INT PRiMARY KEY IDENTITY NOT NULL,
	AccountId INT NOT NULL,
	OldSum DECIMAL(15, 2) NOT NULL,
	NewSum DECIMAL(15, 2) NOT NULL
)

GO
CREATE TRIGGER tr_AccountsUpdate ON Accounts FOR UPDATE
AS
BEGIN
	DECLARE @AccountId INT = (SELECT Id FROM deleted)
	DECLARE @OldBalance DECIMAL(15, 2) = (SELECT Balance FROM deleted)
	DECLARE @NewBalance DECIMAL(15, 2) = (SELECT Balance FROM inserted)

	INSERT INTO Logs(AccountId, Oldsum, NewSum) VALUES
	(@AccountId, @OldBalance, @NewBalance)
END