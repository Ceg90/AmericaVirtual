IF OBJECT_ID('[dbo].[Product_GetById]') IS NOT NULL
	DROP PROCEDURE [dbo].[Product_GetById];
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Product_GetById]
	(@Id BIGINT) AS

BEGIN

	SET NOCOUNT ON

	SELECT
		 [Title]
		,[Description]
		,[Price]
		,[Image]

	FROM [dbo].[Product]
	WHERE ProductId = @Id

END
GO