USE SoftUni

SELECT FirstName, LastName, HireDate, d.Name  
  FROM Employees AS e
INNER JOIN Departments AS d ON
e.DepartmentID = d.DepartmentID
WHERE d.Name IN ('Sales', 'Finance') AND e.HireDate > '01/01/1999'
ORDER BY HireDate