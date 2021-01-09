USE RentACar

SELECT t.Name, COUNT(o.Id) AS OfficesNumber
  FROM Towns AS t
  JOIN Offices AS o ON t.Id = o.TownId
GROUP BY t.Name
ORDER BY OfficesNumber DESC, t.Name
