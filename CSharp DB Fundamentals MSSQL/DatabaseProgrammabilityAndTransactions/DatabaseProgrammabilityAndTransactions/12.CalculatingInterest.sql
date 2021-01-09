USE Bank

GO
CREATE PROC usp_CalculateFutureValueForAccount(@AccountId INT, @Interest FLOAT)
AS
SELECT a.Id AS [Account Id],
       ac.FirstName AS [First Name],
	   ac.LastName AS [Last Name],
	   a.Balance AS [Current Balance],
	   dbo.ufn_CalculateFutureValue(a.Balance, @Interest, 5) AS [Balance in 5 years]
FROM dbo.AccountHolders AS ac
INNER JOIN dbo.Accounts AS a ON
ac.Id = a.AccountHolderId
WHERE a.Id = @AccountId