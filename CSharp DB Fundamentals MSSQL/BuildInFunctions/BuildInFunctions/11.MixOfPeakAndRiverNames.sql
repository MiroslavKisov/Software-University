USE Geography

SELECT p.PeakName, r.RiverName, 
 STUFF(LOWER(p.PeakName), LEN(p.PeakName), 1, LOWER(r.RiverName)) 
    AS Mix
  FROM Peaks p, Rivers r
WHERE RIGHT(LOWER(P.PeakName), 1) = LEFT(LOWER(r.RiverName), 1)
ORDER BY Mix


