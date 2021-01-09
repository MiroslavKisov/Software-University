USE RentACar

GO
WITH cte_MostCommonClass
(Names, Class)
AS
(SELECT FirstName + ' ' + LastName AS Names, t.Class
  FROM Clients AS c
JOIN (SELECT ClientId, m.Class, DENSE_RANK() OVER(PARTITION BY o.ClientId ORDER BY COUNT(m.Class) DESC) AS RowClass
  FROM Orders AS o 
JOIN Vehicles AS v ON o.VehicleId = v.Id
JOIN Models AS m ON v.ModelId = m.Id
GROUP BY ClientId, m.Class) AS t ON c.Id = t.ClientId
WHERE RowClass = 1)

SELECT Names, Class
FROM cte_MostCommonClass
ORDER BY Names, Class