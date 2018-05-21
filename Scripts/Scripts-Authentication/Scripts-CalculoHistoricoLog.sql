USE LogDB

CREATE TABLE CalculoHistoricoLog
(
	Id BIGINT PRIMARY KEY IDENTITY(1,1),
	DateLog DATETIME,
	SelfPositionX INT,
	SelfPositionY INT,
	FriendPositionX INT,
	FriendPositionY INT,
	CalcResult FLOAT
)