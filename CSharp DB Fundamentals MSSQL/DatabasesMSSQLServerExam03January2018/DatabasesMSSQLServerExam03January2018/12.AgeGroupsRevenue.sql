USE RentACar

SELECT AgeGroup, SUM(o.Bill) AS Revenue, AVG(o.TotalMileage) AS AverageMileage
  FROM Orders AS o
  JOIN (SELECT Id,
	  CASE 
		   WHEN YEAR(BirthDate) >= 1970 AND YEAR(BirthDate) < 1980 THEN '70''s'
		   WHEN YEAR(BirthDate) >= 1980 AND YEAR(BirthDate) < 1990 THEN '80''s'
		   WHEN YEAR(BirthDate) >= 1990 AND YEAR(BirthDate) < 2000 THEN '90''s'
		   ELSE 'Others'
	  END AS AgeGroup
  FROM Clients) AS c ON o.ClientId = c.Id
GROUP BY AgeGroup
ORDER BY AgeGroup
