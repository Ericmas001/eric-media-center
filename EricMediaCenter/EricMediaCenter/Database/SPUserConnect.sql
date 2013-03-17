﻿-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF OBJECT_ID('SPUserConnect') IS NOT NULL
DROP PROC SPUserConnect
GO
-- =============================================
-- Author:		ericmas001
-- Create date: 2013-03-16
-- Description:	Register a user
-- =============================================
CREATE PROCEDURE SPUserConnect 
	-- Add the parameters for the stored procedure here
	@username NVARCHAR(50), 
	@password NVARCHAR(50),
	@ok BIT = 0 OUT,
	@info NVARCHAR(100) OUT,
	@validUntil DATETIME OUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @hashed NVARCHAR(32)
	SELECT @hashed = CONVERT(NVARCHAR(32),HashBytes('MD5', @password),2)

	DECLARE @idUser INT
	SET @ok = 0
	SELECT @ok = 1, @idUser = idUser from [ericmas001].[TUser] where username = @username AND password = @hashed

	IF @ok = 1
	BEGIN
		DECLARE @key NVARCHAR(100)
		SELECT @key = @username + '_' + CONVERT(NVARCHAR(100),NEWID())
		DECLARE @token NVARCHAR(32)
		SELECT @token = CONVERT(NVARCHAR(32),HashBytes('MD5',@key ),2)
		UPDATE [ericmas001].[TUser] SET sessionToken = @token WHERE idUser = @idUser
		EXEC [ericmas001].[SPUserRefresh] @idUser, @validUntil output
		SELECT @info = @token
	END
	ELSE
	BEGIN
		SET @info = 'Incorrect user or password'
	END
END
GO