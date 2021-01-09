USE RentACar

SELECT t.Manufacturer, CAST(t.Consumption AS DECIMAL(14, 6))
  FROM(SELECT TOP 3 m.Manufacturer, m.Consumption, COUNT(m.Model) AS VehicleCount
  FROM Orders AS o
JOIN Vehicles AS v ON o.VehicleId = v.Id
JOIN Models AS m ON v.ModelId = m.Id
WHERE m.Consumption BETWEEN 5 AND 15
GROUP BY m.Manufacturer, m.Consumption
ORDER BY VehicleCount DESC) AS t
ORDER BY t.Manufacturer ASC, t.Consumption ASC