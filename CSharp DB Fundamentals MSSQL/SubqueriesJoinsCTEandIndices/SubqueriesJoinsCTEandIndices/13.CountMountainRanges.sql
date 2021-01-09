USE Geography

SELECT m.CountryCode, COUNT(MountainRange)
  FROM MountainsCountries AS m
INNER JOIN Mountains AS m1 ON
m.MountainId = m1.Id
GROUP BY m.CountryCode
HAVING m.CountryCode IN ('BG', 'RU', 'US')