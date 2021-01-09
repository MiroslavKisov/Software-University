USE SoftUni

SELECT TownID, Name 
  FROM Towns
 WHERE SUBSTRING(Name ,1, 1) ='M' 
    OR SUBSTRING(Name ,1, 1) ='K' 
	OR SUBSTRING(Name ,1, 1) ='B' 
	OR SUBSTRING(Name ,1, 1) ='E'
 ORDER BY Name
