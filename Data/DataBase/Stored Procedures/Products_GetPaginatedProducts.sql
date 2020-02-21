IF OBJECT_ID('[dbo].[Products_GetPaginatedProducts]') IS NOT NULL
	DROP PROCEDURE [dbo].[Product_GetPaginatedProducts];
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Product_GetPaginatedProducts]
	(@Skip INT = 0
	,@Take INT = 10
	,@SortBy NVARCHAR(100)
	,@SortOrder NVARCHAR = 'ASC') AS

BEGIN

	SET NOCOUNT ON

	DECLARE @Query NVARCHAR(MAX);
	DECLARE @OrderBy NVARCHAR(MAX);
	DECLARE @Offset NVARCHAR(MAX);

	SET @Query = N'
		SELECT
			[]
	';

END
GO