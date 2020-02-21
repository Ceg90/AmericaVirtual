IF OBJECT_ID('[dbo].[UserPurchases_Insert]') IS NOT NULL
	DROP PROCEDURE [dbo].[UserPurchases_Insert];
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UserPurchases_Insert]
	(@UserId INT
	,@ProductId INT) AS

BEGIN

	SET NOCOUNT ON;

	INSERT INTO [dbo].[UserPurchases]
		(UserId
		,ProductId)

	VALUES
		(@UserId
		,@ProductId)

	SELECT SCOPE_IDENTITY();

END
GO