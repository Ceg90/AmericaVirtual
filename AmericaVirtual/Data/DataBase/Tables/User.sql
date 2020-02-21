IF OBJECT_ID('[dbo].[User]') IS NOT NULL
	DROP TABLE [dbo].[User];
GO

CREATE TABLE [User]
	(UserId BIGINT NOT NULL IDENTITY (1,1) PRIMARY KEY
	,UserName VARCHAR(15)
	,Email VARCHAR(30)
	,[Password] VARCHAR(20)
	,FirstName VARCHAR(20)
	,LastName VARCHAR(20)
	,[Address] VARCHAR(50)
	,PhoneNumber VARCHAR(10)
	);