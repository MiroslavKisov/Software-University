USE SoftUni

SELECT EmployeeID, FirstName, ManagerID,
	CASE
		WHEN ManagerID = 3 
		THEN (SELECT FirstName AS ManagerName FROM Employees WHERE EmployeeID = 3)
		WHEN ManagerID = 7 
		THEN (SELECT FirstName AS ManagerName FROM Employees WHERE EmployeeID = 7)
	END AS ManagerName   
  FROM Employees
 WHERE ManagerID IN (3, 7)
ORDER BY EmployeeID