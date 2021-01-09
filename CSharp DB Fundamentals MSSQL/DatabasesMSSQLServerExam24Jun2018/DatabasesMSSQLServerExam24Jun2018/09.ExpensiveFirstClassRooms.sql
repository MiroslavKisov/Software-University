USE TripService

SELECT r.Id, 
	   r.Price,
	   h.Name,
	   c.Name
FROM Rooms AS r
LEFT JOIN Hotels AS h ON r.HotelId = h.Id
LEFT JOIN Cities AS c ON h.CityId = c.Id
WHERE r.Type = 'First Class'
ORDER BY r.Price DESC, r.Id
