USE Minions

ALTER TABLE Users
DROP CONSTRAINT [PK__Users__3214EC07C1363DA0]

ALTER TABLE Users
ADD CONSTRAINT PK_Users
PRIMARY KEY (Id, Username) 