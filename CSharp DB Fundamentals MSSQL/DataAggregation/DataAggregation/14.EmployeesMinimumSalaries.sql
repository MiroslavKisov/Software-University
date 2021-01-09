USE SoftUni

SELECT DepartmentID, MIN(Salary) AS MinSalary 
  FROM Employees
  WHERE HireDate > '01-01-2000'AND (DepartmentID = 2 OR DepartmentID = 5 OR DepartmentID = 7)
  GROUP BY DepartmentID  