USE ReportService

SELECT DISTINCT u.Username
FROM Users AS u
JOIN Reports AS r ON u.Id = r.UserId 
WHERE (SUBSTRING(u.Username, 1, 1) = CAST(r.CategoryId AS VARCHAR(1))) 
OR (SUBSTRING(u.Username, LEN(u.Username), 1) = CAST(r.CategoryId AS VARCHAR(1)))
ORDER BY u.Username
