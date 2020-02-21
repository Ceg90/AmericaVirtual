IF OBJECT_ID('[dbo].[User_Insert]') IS NOT NULL
	DROP PROCEDURE [dbo].[User_Insert];
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[User_Insert]
	(@Email NVARCHAR(50)
	,@Password NVARCHAR(20)
	,@FirstName NVARCHAR(20)
	,@LastName NVARCHAR(20)
	,@Address NVARCHAR(200)
	,@PhoneNumber NVARCHAR(10)) AS

BEGIN

	SET NOCOUNT ON

	INSERT INTO [dbo].[User]
		(Email
		,[Password]
		,FirstName
		,LastName
		,[Address]
		,PhoneNumber)

	VALUES
		(@Email
		,@Password
		,@FirstName
		,@LastName
		,@Address
		,@PhoneNumber)

	SELECT SCOPE_IDENTITY()

END
GO