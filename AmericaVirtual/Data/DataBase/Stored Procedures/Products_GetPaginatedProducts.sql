IF OBJECT_ID('[dbo].[Product_GetPaginatedProducts]') IS NOT NULL
	DROP PROCEDURE [dbo].[Product_GetPaginatedProducts];
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Product_GetPaginatedProducts]
	(@Skip INT = 0
	,@Take INT = 10
	,@SortBy NVARCHAR(100) = NULL
	,@SortOrder INT = 0) AS

BEGIN

	SET NOCOUNT ON

	DECLARE @Select NVARCHAR(MAX);
	DECLARE @OrderBy NVARCHAR(MAX);
	DECLARE @Order NVARCHAR(MAX);
	DECLARE @Offset NVARCHAR(MAX);

	SET @Select = N'
		SELECT
			 [ProductId]
			,[Title]
			,[Description]
			,[Price]
			,[Image]

		FROM [dbo].[Product]';

	IF(@SortBy IS NOT NULL)
	BEGIN
		SET @OrderBy = N' ORDER BY ' + @SortBy
	END

	IF(@SortOrder = 1)
	BEGIN
		SET @Order = N' DESC';
	END

	ELSE
	BEGIN
		SET @Order = N' ASC';
	END

	SET @Offset = N' OFFSET ' + CONVERT(NVARCHAR(10), @Skip)
				+ N' ROWS FETCH NEXT ' + CONVERT(NVARCHAR(10), @Take)
				+ N' ROWS ONLY';

	DECLARE @Query NVARCHAR(MAX) = @Select + @OrderBy + @Order + @Offset;

	EXEC sp_executesql @Query

END
GO