USE RentACar

  SELECT sub2.Name, 
         CASE
		     WHEN mp > 0 THEN CAST(mp AS INT)
			 ELSE NULL
			 END AS MalePercent,
	     CASE
		     WHEN fp > 0 THEN CAST(fp AS INT)
			 ELSE NULL
			 END AS FemalePercent  
  FROM(SELECT t.Name, (Males / Total) * 100 AS mp, (Females / Total) * 100 AS fp
  FROM Towns AS t
  JOIN(SELECT t.Name, CAST(COUNT(CASE WHEN c.Gender = 'M' THEN 1 END) AS DECIMAL(15,0)) AS Males,
			   CAST(COUNT(CASE WHEN c.Gender = 'F' THEN 1 END) AS DECIMAL(15,0)) AS Females,
               COUNT(Gender) AS Total 
  FROM Orders AS o 
  LEFT JOIN Clients AS c ON o.ClientId = c.Id
  LEFT JOIN Towns AS t ON o.TownId = t.Id
  GROUP BY t.Name) AS sub ON t.Name = sub.Name) AS sub2