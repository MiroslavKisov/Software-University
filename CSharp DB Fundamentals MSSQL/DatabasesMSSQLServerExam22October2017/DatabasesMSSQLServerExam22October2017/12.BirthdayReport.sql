USE ReportService

SELECT DISTINCT c.Name AS [Category Name] 
FROM Categories AS c
JOIN Reports AS r ON c.Id = r.CategoryId
JOIN Users AS u ON r.UserId = u.Id
WHERE MONTH(r.OpenDate) = MONTH(u.BirthDate) AND DAY(r.OpenDate) = DAY(u.BirthDate)
ORDER BY [Category Name]