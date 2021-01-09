USE RentACar

SELECT m.Manufacturer, m.Model, COUNT(o.VehicleId) AS TimesOrdered
  FROM Orders AS o
FULL JOIN Vehicles AS v ON o.VehicleId = v.Id
FULL JOIN Models AS m ON v.ModelId = m.Id
GROUP BY m.Manufacturer, m.Model
ORDER BY TimesOrdered DESC, m.Manufacturer DESC, m.Model
