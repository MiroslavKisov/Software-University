USE RentACar

SELECT t.Name, o.Name, o.ParkingPlaces
  FROM Offices AS o
INNER JOIN Towns AS t ON o.TownId = t.Id
WHERE o.ParkingPlaces > 25
ORDER BY t.Name, o.Id
