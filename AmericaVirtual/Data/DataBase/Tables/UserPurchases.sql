IF OBJECT_ID('[dbo].[UserPurchases]') IS NOT NULL
	DROP TABLE [dbo].[UserPurchases];
GO

CREATE TABLE [UserPurchases]
	(UserPurchasesId BIGINT NOT NULL IDENTITY (1,1) PRIMARY KEY
	,UserId INT
	,ProductId INT
	,CONSTRAINT [FK_UserPurchases_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] (UserId)
	,CONSTRAINT [FK_UserPurchases_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] (ProductId)
	);