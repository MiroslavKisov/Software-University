USE SoftUni

SELECT TOP 3 
       e.EmployeeID, 
	   FirstName
  FROM Employees AS e
LEFT OUTER JOIN EmployeesProjects AS e1 ON
e.EmployeeID = e1.EmployeeID
 WHERE ProjectID IS NULL
ORDER BY EmployeeID
