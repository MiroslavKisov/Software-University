USE RentACar

GO
CREATE PROC usp_MoveVehicle(@vehicleId INT, @officeId INT)
AS
BEGIN
	DECLARE @VehicleCountInGivenOffice INT;
	DECLARE @FreeParkingSlotsInGivenOffice INT;
	DECLARE @TotalParkingSlotInGivenOffice INT;

	SET @VehicleCountInGivenOffice = (SELECT COUNT(*) FROM Vehicles WHERE OfficeId = @officeId)

	SET @TotalParkingSlotInGivenOffice = (SELECT ParkingPlaces FROM Offices WHERE Id = @officeId)

	SET @FreeParkingSlotsInGivenOffice = @TotalParkingSlotInGivenOffice - @VehicleCountInGivenOffice

	IF(@FreeParkingSlotsInGivenOffice > 0)
	BEGIN
		UPDATE Vehicles
		SET OfficeId = @officeId
		WHERE Id = @vehicleId
	END
	ELSE
	BEGIN
		RAISERROR('Not enough room in this office!', 16, 1);
		RETURN;
	END

END