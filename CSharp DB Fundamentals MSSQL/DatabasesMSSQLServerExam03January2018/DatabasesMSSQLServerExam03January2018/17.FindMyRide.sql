USE RentACar

GO 
CREATE FUNCTION udf_CheckForVehicle(@townName NVARCHAR(50), @seatsNumber INT)
RETURNS NVARCHAR(MAX)
AS
BEGIN
	DECLARE @TownId INT;
	DECLARE @OfficeId INT
	DECLARE @OfficeName NVARCHAR(40);
	DECLARE @ModelName NVARCHAR(50);
	DECLARE @Result NVARCHAR(MAX)

	SET @TownId = (SELECT Id FROM Towns WHERE Name = @townName);

	SET @OfficeId = (SELECT TOP 1 o.Id
                       FROM Towns AS t 
                  LEFT JOIN Offices AS o ON t.Id = o.TownId
                  LEFT JOIN Vehicles AS v ON o.Id = v.OfficeId
                  LEFT JOIN Models AS m ON v.ModelId = m.Id
                  WHERE TownId = @TownId AND m.Seats = @seatsNumber
                  ORDER BY o.Name);

	SET @OfficeName = (SELECT TOP 1 o.Name 
                         FROM Towns AS t 
                    LEFT JOIN Offices AS o ON t.Id = o.TownId
                    LEFT JOIN Vehicles AS v ON o.Id = v.OfficeId
                    LEFT JOIN Models AS m ON v.ModelId = m.Id
                        WHERE TownId = @TownId AND m.Seats = @seatsNumber AND o.Id = @OfficeId
                     ORDER BY o.Name);

	SET @ModelName = (SELECT TOP 1 m.Model 
                        FROM Towns AS t 
                   LEFT JOIN Offices AS o ON t.Id = o.TownId
                   LEFT JOIN Vehicles AS v ON o.Id = v.OfficeId
                   LEFT JOIN Models AS m ON v.ModelId = m.Id
                       WHERE TownId = @TownId AND m.Seats = @seatsNumber AND o.Name = @OfficeName
                    ORDER BY o.Name)
    IF(@ModelName IS NULL)
	BEGIN
	    SET @Result = 'NO SUCH VEHICLE FOUND'
		RETURN @Result
	END

    SET @Result = @OfficeName + ' - ' + @ModelName   

RETURN @Result
END
