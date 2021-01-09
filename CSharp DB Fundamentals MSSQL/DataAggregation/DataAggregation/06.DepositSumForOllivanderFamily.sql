USE Gringotts

SELECT DepositGroup, 
   SUM(DepositAmount) AS [total Sum]
  FROM WizzardDeposits
  WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup