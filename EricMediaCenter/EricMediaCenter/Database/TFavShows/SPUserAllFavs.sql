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
IF OBJECT_ID('SPUserAllFavs') IS NOT NULL
DROP PROC SPUserAllFavs
GO
-- =============================================
-- Author:		ericmas001
-- Create date: 2013-03-17
-- Description:	Get all the favorite shows of a user
-- =============================================
CREATE PROCEDURE SPUserAllFavs 
	-- Add the parameters for the stored procedure here
	@username NVARCHAR(50),
	@session NVARCHAR(32),
	@ok BIT OUT,
	@info NVARCHAR(100) OUT,
	@validUntil DATETIME OUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	DECLARE	@idUser INT
	EXEC [ericmas001].[SPUserValidToken] @username, @session, @ok output, @info output, @validUntil output, @idUser output
	IF @ok = 1	
		SELECT s.idShow, s.website, s.showname, s.showtitle, s.lastSeason, s.lastEpisode, f.lastViewedSeason, f.lastViewedEpisode FROM [ericmas001].[TFavShows] f LEFT OUTER JOIN [ericmas001].[TTvShow] s ON f.idShow = s.idShow WHERE f.idUser = @idUser
END
GO
