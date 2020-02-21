IF OBJECT_ID('[dbo].[UserActions]') IS NOT NULL
	DROP TABLE [dbo].[UserActions];
GO

CREATE TABLE [UserActions]
	(UserActionsId BIGINT NOT NULL IDENTITY (1,1) PRIMARY KEY
	,UserId INT
	,[Action] VARCHAR(20)
	,[Date] DATETIME
	,CONSTRAINT [FK_UserActions_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] (UserId)
	);