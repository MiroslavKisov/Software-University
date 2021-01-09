USE SoftUni

SELECT TOP 5 
	   e.EmployeeID, 
	   e.FirstName, 
	   e.Salary, 
	   d.Name
  FROM Employees AS e
INNER JOIN Departments AS d ON
  e.DepartmentID = d.DepartmentID
  WHERE Salary > 15000
ORDER BY d.DepartmentID