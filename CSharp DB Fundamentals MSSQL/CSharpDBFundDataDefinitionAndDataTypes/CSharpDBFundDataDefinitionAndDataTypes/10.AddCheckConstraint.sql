USE Minions

ALTER TABLE Users
ADD CONSTRAINT CH_Users
CHECK (Password >= 5)