USE TripService

GO
CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS NVARCHAR(MAX)
BEGIN
	DECLARE @TotalPrice DECIMAL(15,2);
	DECLARE @RoomId INT;
	DECLARE @NumberOfBeds INT;
	DECLARE @RoomType NVARCHAR(20);
	DECLARE @RoomPrice DECIMAL(15,2);
	DECLARE @BaseRate DECIMAL(15,2);

	SET @RoomId = (SELECT TOP 1 r.Id
                     FROM Rooms AS r
                     LEFT JOIN Trips AS t ON r.Id = t.RoomId
                     WHERE r.HotelId = @HotelId
                     AND (t.ArrivalDate > @Date OR t.ReturnDate <= @Date)
                     AND t.CancelDate IS NULL 
                     AND r.Beds >= @People
                     ORDER BY r.Price DESC)
	IF(@RoomId IS NOT NULL)
	BEGIN
		SET @BaseRate = (SELECT BaseRate FROM Hotels WHERE Id = @HotelId)
		SET @RoomPrice = (SELECT Price FROM Rooms WHERE Id = @RoomId)
		SET @TotalPrice = (@BaseRate + @RoomPrice) * @People
		SET @RoomType = (SELECT Type FROM Rooms WHERE Id = @RoomId)
		SET @NumberOfBeds = (SELECT Beds FROM Rooms WHERE Id = @RoomId)

		RETURN 'Room ' + CAST(@RoomId AS NVARCHAR) + ':' + ' ' + @RoomType + ' ' + '(' + CAST(@NumberOfBeds AS NVARCHAR) + ' ' + 'beds' + ')' + ' ' + '-' + ' ' +'$'+ CAST(@TotalPrice AS NVARCHAR);
	END

	RETURN 'No rooms available'
	
END



