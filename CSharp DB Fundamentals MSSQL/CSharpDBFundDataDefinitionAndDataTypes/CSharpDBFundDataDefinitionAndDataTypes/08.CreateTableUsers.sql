USE Minions

CREATE TABLE Users(
	Id BIGINT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) UNIQUE NOT NULL,
	Password VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX),
	LastLoginTime DATETIME,
	IsDeleted BIT 
)

INSERT INTO Users (Username, Password, ProfilePicture, LastLoginTime, IsDeleted) VALUES
('Pesho', '12345', NULL, NULL, 1),
('Gosho', '12345', NULL, NULL, 0),
('Misho', '12345', NULL, NULL, 0),
('Tosho', '12345', NULL, NULL, 1),
('Kiro', '12345', NULL, NULL, 1)
