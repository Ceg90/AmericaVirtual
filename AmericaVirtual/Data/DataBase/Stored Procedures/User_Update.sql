IF OBJECT_ID('[dbo].[User_Update]') IS NOT NULL
	DROP PROCEDURE [dbo].[User_Update];
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[User_Update]
	(@UserId INT
	,@Email NVARCHAR(50)
	,@Password NVARCHAR(20)
	,@FirstName NVARCHAR(20)
	,@LastName NVARCHAR(20)
	,@Address NVARCHAR(200)
	,@PhoneNumber NVARCHAR(10)) AS

BEGIN

	SET NOCOUNT ON;

	UPDATE [dbo].[User]
	SET
		 Email = @Email
		,[Password] = @Password
		,FirstName = @FirstName
		,LastName = @LastName
		,[Address] = @Address
		,PhoneNumber = @PhoneNumber
	WHERE UserId = @UserId

END
GO