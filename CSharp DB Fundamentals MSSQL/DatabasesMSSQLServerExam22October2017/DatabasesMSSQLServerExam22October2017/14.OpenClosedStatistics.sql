USE ReportService

 SELECT emp.FirstName + ' ' + emp.LastName AS [Name],
		ISNULL(CONVERT(VARCHAR, sub2.NumberOfClosedReports), 0) + '/' 
	  + ISNULL(CONVERT(VARCHAR, sub1.NumberOfOpenReports), 0)
   FROM Employees AS emp
   JOIN (SELECT e.FirstName + ' ' + e.LastName AS [N], 
	    COUNT(*) AS NumberOfOpenReports
   FROM Employees AS e
   JOIN Reports AS r ON e.Id = r.EmployeeId
  WHERE YEAR(r.OpenDate) = '2016'
  GROUP BY e.FirstName + ' ' + e.LastName) AS sub1 ON emp.FirstName + ' ' + emp.LastName = sub1.N
LEFT JOIN( SELECT e.FirstName + ' ' + e.LastName AS [N],
        COUNT(*) AS NumberOfClosedReports
  FROM Employees AS e
  JOIN Reports AS r ON e.Id = r.EmployeeId
 WHERE YEAR(r.CloseDate) = '2016'
 GROUP BY e.FirstName + ' ' + e.LastName) AS sub2 ON emp.FirstName + ' ' + emp.LastName = sub2.N
 ORDER BY [Name], emp.Id
