USE RentACar

GO
--Submit only the create trigger statement
CREATE TRIGGER tr_OrdersUpdate ON Orders FOR UPDATE
AS
DECLARE @OrderId INT = (SELECT Id FROM deleted);
DECLARE @TotalMileage INT = (SELECT TotalMileage FROM deleted WHERE Id = @OrderId)
DECLARE @VehicleId INT = (SELECT VehicleId FROM deleted WHERE Id = @OrderId)
DECLARE @GivenMileage INT = (SELECT TotalMileage FROM inserted WHERE Id = @OrderId)

IF(@TotalMileage IS NULL)
BEGIN
	UPDATE Vehicles
	SET Mileage += @GivenMileage
	WHERE Id = @VehicleId
END