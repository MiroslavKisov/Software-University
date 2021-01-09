USE Diablo

BEGIN TRANSACTION
BEGIN TRY
	
	DECLARE @ItemCountBeforeInsert INT = (SELECT COUNT(ItemId) FROM UserGameItems WHERE UserGameId = 110)

	UPDATE UsersGames
	SET Cash -= (SELECT SUM(Price) FROM Items WHERE MinLevel IN (11, 12))
	WHERE Id = 87

	DECLARE @PlayerSum DECIMAL(15, 2) = (SELECT Cash FROM UsersGames WHERE Id = 87)

	IF(@PlayerSum < 0)
	BEGIN
		ROLLBACK
	END

	INSERT INTO UserGameItems
	SELECT Id, 110 FROM Items WHERE MinLevel IN (11, 12)

	DECLARE @ItemCountAfterInsert INT = (SELECT COUNT(ItemId) FROM UserGameItems WHERE UserGameId = 110)

	IF(@ItemCountBeforeInsert = @ItemCountAfterInsert)
	BEGIN
		ROLLBACK
	END

	COMMIT

END TRY
BEGIN CATCH
	ROLLBACK
END CATCH


BEGIN TRANSACTION
BEGIN TRY
	
	SET @ItemCountBeforeInsert = (SELECT COUNT(ItemId) FROM UserGameItems WHERE UserGameId = 110)

	UPDATE UsersGames
	SET Cash -= (SELECT SUM(Price) FROM Items WHERE MinLevel IN (19, 20, 21))
	WHERE Id = 87

	SET @PlayerSum = (SELECT Cash FROM UsersGames WHERE Id = 87)

	IF(@PlayerSum < 0)
	BEGIN
		ROLLBACK
	END

	INSERT INTO UserGameItems
	SELECT Id, 110 FROM Items WHERE MinLevel IN (19, 20, 21)

	SET @ItemCountAfterInsert = (SELECT COUNT(ItemId) FROM UserGameItems WHERE UserGameId = 110)

	IF(@ItemCountBeforeInsert = @ItemCountAfterInsert)
	BEGIN
		ROLLBACK
	END

	COMMIT

END TRY
BEGIN CATCH
	ROLLBACK
END CATCH

SELECT i.Name AS [Item Name]
  FROM UserGameItems AS ugi 
LEFT JOIN Items AS i ON ugi.ItemId = i.Id 
WHERE ugi.UserGameId = 110
ORDER BY i.Name
