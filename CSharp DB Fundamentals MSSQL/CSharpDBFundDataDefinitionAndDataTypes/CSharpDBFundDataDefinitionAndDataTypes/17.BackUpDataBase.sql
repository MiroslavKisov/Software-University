BACKUP DATABASE SoftUni
TO DISK = 'C:\BackUp\softuni-backup.bak'

DROP DATABASE SoftUni

RESTORE DATABASE SoftUni
FROM DISK = 'C:\BackUp\softuni-backup.bak'