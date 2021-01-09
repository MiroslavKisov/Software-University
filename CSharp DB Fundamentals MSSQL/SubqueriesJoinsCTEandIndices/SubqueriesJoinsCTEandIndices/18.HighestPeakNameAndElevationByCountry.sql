USE Geography

--VERSION 1
GO

SELECT TOP 5 CountryName AS [Country],
	   CASE
		   WHEN PeakName IS NULL THEN '(no highest peak)'
		   ELSE PeakName
       END AS [Highest Peak Name],
	   CASE 
		   WHEN Elevation IS NULL THEN 0
		   ELSE Elevation
	   END AS [Highest Peak Elevation],
	   CASE 
	       WHEN MountainRange IS NULL THEN '(no mountain)'
		   ELSE MountainRange
	   END AS [Mountain]
  FROM
  (SELECT CountryName, 
          PeakName, 
	      Elevation, 
	      MountainRange,
	      DENSE_RANK() OVER (PARTITION BY CountryName ORDER BY Elevation DESC) AS [Rank]
     FROM
  (SELECT  c.CountryName,
           p.PeakName,
		   p.Elevation,
		   m.MountainRange
     FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains AS m On mc.MountainId = m.Id
LEFT JOIN Peaks AS p ON m.Id = p.MountainId) AS InnerTable) AS InnerTable2
WHERE [Rank] = 1
ORDER BY CountryName, PeakName



--VERSION 2
GO

WITH HighesPeak_CTE
(CountryName, PeakName, [Highest Peak Elevation], MountainRange)
AS
(SELECT c.CountryName,
	    CASE
			WHEN p.PeakName IS NULL THEN '(no highest peak)'
			ELSE p.PeakName
		END AS [Highest Peak Name],
		CASE
			WHEN MAX(p.Elevation) IS NULL THEN '0'
			ELSE MAX(p.Elevation)
		END AS [Highest Peak Elevation],
	    CASE
			WHEN m.MountainRange IS NULL THEN '(no mountain)'
			ELSE m.MountainRange
		END AS [Mountain]
	  FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
LEFT JOIN Peaks AS p ON m.Id = p.MountainId
GROUP BY c.CountryName, p.PeakName, m.MountainRange)

SELECT TOP 5 cte.CountryName,
	   PeakName,
	   cte.[Highest Peak Elevation],
	   MountainRange
  FROM HighesPeak_CTE AS cte
INNER JOIN (SELECT CountryName, MAX(HighesPeak_CTE.[Highest Peak Elevation]) AS fsdf
		  FROM HighesPeak_CTE
		  GROUP BY CountryName) AS cte2 ON
cte.CountryName = cte2.CountryName
ORDER BY cte.CountryName, cte.PeakName
