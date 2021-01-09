USE Gringotts

SELECT SUM([SpecialColumn]) AS SumDifference
  FROM
  (
	SELECT DepositAmount - LEAD(DepositAmount) OVER(ORDER BY Id) AS SpecialColumn
	FROM WizzardDeposits
  ) AS SumDifference
