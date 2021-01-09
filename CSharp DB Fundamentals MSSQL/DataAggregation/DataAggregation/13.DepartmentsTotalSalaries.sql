USE SoftUni

SELECT * FROM Employees

SELECT DepartmentID, SUM(Salary) AS TotalSalary
  FROM Employees
GROUP BY DepartmentID