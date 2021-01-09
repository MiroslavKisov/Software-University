USE Diablo

SELECT TOP 50 Name, REPLACE(CONVERT(VARCHAR, Start, 111),'/','-')
	AS [Start]
  FROM Games
WHERE YEAR(Start) = '2011' OR YEAR(Start) = '2012'
ORDER BY Start, Name