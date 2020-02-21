IF OBJECT_ID('[dbo].[Product]') IS NOT NULL
	DROP TABLE [dbo].[Product];
GO

CREATE TABLE [Product]
	(ProductId BIGINT NOT NULL IDENTITY (1,1) PRIMARY KEY
	,[Title] VARCHAR(15)
	,[Description] VARCHAR(200)
	,[Price] DECIMAL(12,5)
	,[Image] VARBINARY(MAX)
	);