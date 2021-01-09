USE ReportService

SELECT dep2.Name, 
		   ISNULL(CONVERT(VARCHAR, sub2.TimeAvg), 'no info') AS [Average Duration]
  FROM Departments AS dep2
  JOIN(SELECT DISTINCT sub.Name,
	          AVG(sub.Time) AS TimeAvg
        FROM Departments AS dep
        JOIN (SELECT d.Id,
                     d.Name,
	                 DATEDIFF(DAY, r.OpenDate, r.CloseDate) AS [Time]
                FROM Categories AS c
                JOIN Departments AS d ON c.DepartmentId = d.Id
                JOIN Reports AS r ON c.Id = r.CategoryId) AS sub ON dep.Name = sub.Name
GROUP BY dep.Id, sub.Name) AS sub2 ON dep2.Name = sub2.Name
ORDER BY sub2.Name