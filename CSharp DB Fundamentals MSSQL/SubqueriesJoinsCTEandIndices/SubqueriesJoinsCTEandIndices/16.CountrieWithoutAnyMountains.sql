USE Geography

SELECT COUNT(c.CountryCode) AS CountryCode
  FROM Countries AS c
LEFT OUTER JOIN MountainsCountries AS mc ON
c.CountryCode = mc.CountryCode
LEFT OUTER JOIN Mountains AS m ON
mc.MountainId = m.Id
WHERE mc.MountainId IS NULL
