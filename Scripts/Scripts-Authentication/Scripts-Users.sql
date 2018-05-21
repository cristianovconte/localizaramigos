USE AuthenticationDB
GO

CREATE TABLE dbo.Users(
	UserID varchar(30) NOT NULL,
	AccessKey varchar(32) NOT NULL,
	CONSTRAINT PK_User PRIMARY KEY (UserID)
)
GO


INSERT INTO dbo.Users
           (UserID
           ,AccessKey)
     VALUES
           ('user1'
           ,'53nh@123*')

INSERT INTO dbo.Users
           (UserID
           ,AccessKey)
     VALUES
           ('user2'
           ,'53nh@1234*')
