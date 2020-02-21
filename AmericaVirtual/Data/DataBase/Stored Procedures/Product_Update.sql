IF OBJECT_ID('[dbo].[Product_Update]') IS NOT NULL
	DROP PROCEDURE [dbo].[Product_Update];
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Product_Update]
	(@ProductId INT
	,@Title NVARCHAR(15)
	,@Description NVARCHAR(200)
	,@Price FLOAT
	,@Images NVARCHAR(10)) AS

BEGIN

	SET NOCOUNT ON;

	UPDATE [dbo].[Product]
	SET
		 Title = @Title
		,[Description] = @Description
		,Price = @Price
		,[Images] = @Images
	WHERE ProductId = @ProductId

END
GO