USE ReportService

SELECT r.OpenDate, 
       r.Description, 
	   u.Email
  FROM Reports AS r
  JOIN Users AS u ON r.UserId = u.Id
  JOIN Categories AS c ON r.CategoryId = c.Id
  JOIN Departments AS d ON c.DepartmentId = d.Id
WHERE r.CloseDate IS NULL 
AND LEN(r.Description) > 20 
AND r.Description LIKE '%Str%'
AND d.Id IN (1, 4, 5)
ORDER BY r.OpenDate, u.Email, r.Id

