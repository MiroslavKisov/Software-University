USE SoftUni

SELECT MIN(tempTable.MinSalary)
  FROM
  (
	SELECT AVG(Salary) AS MinSalary
      FROM Employees
  GROUP BY DepartmentID
  ) AS tempTable
