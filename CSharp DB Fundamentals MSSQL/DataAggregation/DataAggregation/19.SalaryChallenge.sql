USE SoftUni

SELECT TOP 10 FirstName, LastName, DepartmentID
  FROM Employees AS Emp1
 WHERE Salary > 
(
	SELECT AVG(Salary)
      FROM Employees AS Emp2
     WHERE Emp1.DepartmentID = Emp2.DepartmentID
  GROUP BY DepartmentID
)

