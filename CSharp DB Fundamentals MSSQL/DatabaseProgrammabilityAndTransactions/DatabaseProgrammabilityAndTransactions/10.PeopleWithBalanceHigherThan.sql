USE Bank

GO
CREATE PROC usp_GetholdersWithBalanceHigherThan(@Balance DECIMAL(18, 4))
AS
SELECT ac.FirstName, ac.LastName
  FROM AccountHolders AS ac
INNER JOIN Accounts AS a ON
ac.Id = a.AccountHolderId
GROUP BY ac.FirstName, ac.LastName
HAVING SUM(a.Balance) > @Balance
