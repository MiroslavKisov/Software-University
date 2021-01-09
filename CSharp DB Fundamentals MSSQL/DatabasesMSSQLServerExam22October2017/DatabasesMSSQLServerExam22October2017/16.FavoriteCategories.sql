USE ReportService

SELECT dep.Name,
	   sub.[Category Name],
	   CAST(ROUND((sub.CountOfReportsPerCategory * 100.00) / SUM(CountOfReportsPerCategory) OVER(PARTITION BY dep.Name) ,0) AS INT) AS [Percentage]
  FROM Departments AS dep
  JOIN(SELECT d.Name, 
	          c.Name AS [Category Name], 
	          COUNT(*) AS CountOfReportsPerCategory 
         FROM Categories AS c
         JOIN Reports AS r ON c.Id = r.CategoryId
         JOIN Departments AS d ON c.DepartmentId = d.Id
  GROUP BY d.Name, c.Name) AS sub ON  dep.Name = sub.Name
  GROUP BY dep.Name, sub.[Category Name], sub.CountOfReportsPerCategory
  ORDER BY dep.Name, sub.[Category Name], [Percentage]



