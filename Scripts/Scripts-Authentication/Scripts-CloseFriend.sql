USE CloseFriendDB
GO

CREATE TABLE dbo.Friend(
	Id int NOT NULL PRIMARY KEY IDENTITY(1,1),
	Name varchar(100) NOT NULL,
	X int,
	Y int
)
GO

INSERT INTO dbo.Friend
           (Name
		   ,X
		   ,Y)
     VALUES
			('Amigo 1', 1,1)
			,('Amigo 2', 2,4)
			,('Amigo 3', 4,8)
			,('Amigo 4', 8,16)
			,('Amigo 5', 16,32)
			,('Amigo 6', 32,64)
			,('Amigo 7', 64,128)
			,('Amigo 8', 128,256)
			,('Amigo 9', 256,512)
			,('Amigo 10', 512,1024)
			,('Amigo 11', 1024,2048)
			,('Amigo 12', 2048,4096)
			,('Amigo 13', 4096,1)
			,('Amigo 14', 2048,2)
			,('Amigo 15', 1024,4)
			,('Amigo 16', 512,8)
			,('Amigo 17', 256,16)
			,('Amigo 18', 128,32)
			,('Amigo 19', 64,64)
			,('Amigo 20', 32,128)
			,('Amigo 21', 16,256)
			,('Amigo 22', 8,512)
			,('Amigo 23', 4,1024)
			,('Amigo 24', 2,2048)
