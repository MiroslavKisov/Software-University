USE TripService

SELECT a.FirstName, 
	   a.LastName, 
	   CONVERT(VARCHAR, a.BirthDate, 110) AS BirthDate,
	   c.Name,
	   a.Email
  FROM Accounts AS a
  JOIN Cities AS c ON a.CityId = c.Id
  WHERE a.Email LIKE 'e%'
  ORDER BY c.Name DESC