USE TripService

SELECT c.Name,
	   ISNULL(COUNT(h.CityId), 0) AS Hotels
FROM Cities AS c
FULL JOIN Hotels AS h ON c.Id = h.CityId
GROUP BY c.Name
ORDER BY Hotels DESC, c.Name
