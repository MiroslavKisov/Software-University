USE Geography

SELECT TOP 5 c.CountryName, r.RiverName
  FROM Countries AS c
LEFT OUTER JOIN CountriesRivers AS cr ON
c.CountryCode = cr.CountryCode
LEFT OUTER JOIN Rivers AS r ON
cr.RiverId = r.Id
WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName


