IF OBJECT_ID('[dbo].[UserActions_Insert]') IS NOT NULL
	DROP PROCEDURE [dbo].[UserActions_Insert];
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UserActions_Insert]
	(@UserId INT
	,@Action VARCHAR(20)
	,@Date DATETIME) AS

BEGIN

	SET NOCOUNT ON;

	INSERT INTO [dbo].[UserActions]
		(UserId
		,[Action]
		,[Date])

	VALUES
		(@UserId
		,@Action
		,@Date)

	SELECT SCOPE_IDENTITY();

END
GO