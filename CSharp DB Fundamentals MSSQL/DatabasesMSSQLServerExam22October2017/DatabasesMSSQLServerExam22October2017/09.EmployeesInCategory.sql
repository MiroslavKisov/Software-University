USE ReportService

SELECT c.Name, COUNT(e.Id) AS [Employee Count]
FROM Categories AS c
LEFT JOIN Departments AS d ON c.DepartmentId = d.Id
LEFT JOIN Employees AS e ON d.Id = e.DepartmentId
GROUP BY c.Name
ORDER BY c.Name


