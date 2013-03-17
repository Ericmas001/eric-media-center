USE [emc2]
GO

/****** Object:  Table [ericmas001].[TUser]    Script Date: 2013-03-16 21:09:16 ******/
DROP TABLE [ericmas001].[TUser]
GO

/****** Object:  Table [ericmas001].[TUser]    Script Date: 2013-03-16 21:09:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [ericmas001].[TUser](
	[idUser] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](32) NOT NULL,
	[email] [nvarchar](100) NULL,
	[sessionToken] [nvarchar](32) NULL,
	[validUntil] [datetime] NULL,
 CONSTRAINT [PK_TUser] PRIMARY KEY CLUSTERED 
(
	[idUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


