USE TripService

SELECT DISTINCT CityId FROM Accounts
ORDER BY CityId

SELECT * FROM AccountsTrips

SELECT * FROM Cities
ORDER BY Id

SELECT * FROM Hotels

SELECT * FROM Rooms

SELECT * FROM Trips

SELECT TOP 5 c.Id,c.Name, c.CountryCode, COUNT(a.Id) AS CountOfA
  FROM Cities AS c
  JOIN Accounts AS a ON c.Id = a.CityId
  GROUP BY c.Id,c.Name, c.CountryCode 
  ORDER BY CountOfA DESC

   
