USE Bank

CREATE TABLE NotificationEmails(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Recipient INT NOT NULL,
	Subject NVARCHAR(50) NOT NULL,
	Body NVARCHAR(50)
)

GO
CREATE TRIGGER tr_EmailNotification ON Logs
FOR INSERT AS
BEGIN
	DECLARE @Recipient INT = (SELECT AccountId FROM inserted);
	DECLARE @Subject NVARCHAR(50) = CONCAT('Balance change for account: ', @Recipient);
	DECLARE @Oldsum DECIMAL(15, 2) = (SELECT OldSum FROM inserted);
	DECLARE @NewSum DECIMAL(15, 2) = (SELECT NewSum FROM inserted);
	DECLARE @Body NVARCHAR(50) = CONCAT('On ', GETDATE(), ' your balance was changed from ', @OldSum, ' to ', @NewSum, '.');
	INSERT INTO NotificationEmails (Recipient, Subject, Body) VALUES
	(@Recipient, @Subject, @Body)
END