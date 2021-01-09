USE Hotel

UPDATE Payments
SET TaxRate *= 0.97, TaxAmount *= 0.97
WHERE Id = 1

UPDATE Payments
SET TaxRate *= 0.97, TaxAmount *= 0.97
WHERE Id = 2

UPDATE Payments
SET TaxRate *= 0.97, TaxAmount *= 0.97
WHERE Id = 3

SELECT TaxRate FROM Payments
