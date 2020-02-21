IF OBJECT_ID('[dbo].[User_Delete]') IS NOT NULL
	DROP PROCEDURE [dbo].[User_Delete];
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[User_Delete]
	(@Id BIGINT) AS

BEGIN

	SET NOCOUNT ON;

	DELETE
	FROM [dbo].[User]
	WHERE UserId = @Id

END
GO