IF OBJECT_ID('[dbo].[Product_Delete]') IS NOT NULL
	DROP PROCEDURE [dbo].[Product_Delete];
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Product_Delete]
	(@Id BIGINT) AS

BEGIN

	SET NOCOUNT ON;

	DELETE
	FROM [dbo].[Product]
	WHERE ProductId = @Id

END
GO