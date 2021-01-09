USE ReportService

SELECT c.Name, COUNT(r.Id) AS ReportsNumber 
  FROM Categories AS c
  JOIN Reports AS r ON c.Id = r.CategoryId
  GROUP BY c.Name
ORDER BY COUNT(r.Id) DESC, c.Name