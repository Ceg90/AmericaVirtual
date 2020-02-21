IF OBJECT_ID('[dbo].[User_GetByEmail]') IS NOT NULL
	DROP PROCEDURE [dbo].[User_GetByEmail];
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[User_GetByEmail]
	(@Email NVARCHAR(50)
	,@Password NVARCHAR(20)) AS

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
	WHERE [Email] = @Email AND [Password] = @Password
END
GO