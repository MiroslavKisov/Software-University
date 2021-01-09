USE RentACar

SELECT c.FirstName + ' ' + c.LastName AS [Category Name],
       c.Email,
	   o.Bill,
	   t.Name AS Town
  FROM Clients AS c 
  FULL JOIN (SELECT TownId, 
       ClientId,
	   o.Bill, 
	   DENSE_RANK()OVER (PARTITION BY TownId ORDER BY Bill DESC) AS BillRank
   FROM Orders AS o
   JOIN Clients AS c ON o.ClientId = c.Id
   WHERE o.CollectionDate > c.CardValidity) AS o ON c.Id = o.ClientId
   FULL JOIN Towns AS t ON o.TownId = t.Id
  WHERE o.BillRank IN(1, 2) AND Bill IS NOT NULL 
ORDER BY t.Name, o.Bill, o.ClientId