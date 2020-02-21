IF OBJECT_ID('[dbo].[Product_Insert]') IS NOT NULL
	DROP PROCEDURE [dbo].[Product_Insert];
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Product_Insert]
	(@Title NVARCHAR(50)
	,@Description NVARCHAR(20)
	,@Price FLOAT
	,@Images NVARCHAR(MAX)) AS

BEGIN

	SET NOCOUNT ON

	INSERT INTO [dbo].[Product]
		(Title
		,[Description]
		,Price
		,[Images])

	VALUES
		(@Title
		,@Description
		,@Price
		,@Images)

	SELECT SCOPE_IDENTITY()

END
GO