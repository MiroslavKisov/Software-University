USE ReportService

SELECT e.FirstName, 
       e.LastName, 
	   r.Description, 
	   CONVERT(char(10) , r.OpenDate, 126) AS OpenDate
  FROM Reports AS r
  JOIN Employees AS e ON r.EmployeeId = e.Id
  ORDER BY  e.Id, r.OpenDate, r.Id