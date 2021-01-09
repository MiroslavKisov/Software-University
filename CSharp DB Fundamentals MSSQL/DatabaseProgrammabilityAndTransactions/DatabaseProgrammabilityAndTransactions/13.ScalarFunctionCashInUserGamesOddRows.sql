USE Diablo

GO
CREATE FUNCTION ufn_CashInUsersGames(@GameName NVARCHAR(MAX))
RETURNS TABLE
AS
RETURN SELECT SUM(Cash) AS SumCash
         FROM(SELECT g.Name, ug.Cash, ROW_NUMBER() OVER(ORDER BY ug.Cash DESC) AS RowNumber
                FROM UsersGames AS ug
                JOIN Games AS g ON ug.GameId = g.Id
               WHERE g.Name = @GameName) AS innerTable
 WHERE RowNumber % 2 <> 0;