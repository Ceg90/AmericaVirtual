IF OBJECT_ID('[dbo].[User_GetById]') IS NOT NULL
	DROP PROCEDURE [dbo].[User_GetById];
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[User_GetById]
	(@Id NVARCHAR(50)) AS

BEGIN

	SET NOCOUNT ON;

	SELECT
		 [UserId]
		,[Email]
		,[FirstName]
		,[LastName]
		,[Address]
		,[PhoneNumber]

	FROM [dbo].[User]
	WHERE [UserId] = @Id
END
GO