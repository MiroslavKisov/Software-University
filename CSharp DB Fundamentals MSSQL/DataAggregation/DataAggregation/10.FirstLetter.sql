USE Gringotts

SELECT DISTINCT SUBSTRING(FirstName, 1, 1)
AS FirstLetter 
FROM WizzardDeposits
GROUP BY DepositGroup, SUBSTRING(FirstName, 1, 1)
HAVING DepositGroup = 'Troll Chest'