USE SoftUni

SELECT e.EmployeeID, 
	   e.FirstName, 
	   e.LastName, 
	   d.Name AS DepartmentName
  FROM Employees AS e
RIGHT OUTER JOIN Departments AS d ON
e.DepartmentID = d.DepartmentID
  WHERE d.Name = 'Sales'
ORDER BY d.DepartmentID