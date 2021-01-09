USE SoftUni

BACKUP DATABASE SoftUni
TO DISK = 'C:\BackUp\SoftUni-backup.bak'

RESTORE DATABASE SoftUni
FROM DISK = 'C:\BackUp\SoftUni-backup.bak'

UPDATE Employees
SET Salary *= 1.12
WHERE DepartmentID = 1 OR DepartmentID = 2 OR DepartmentID = 4 OR DepartmentID = 11

SELECT Salary FROM Employees

USE master
DROP DATABASE SoftUni