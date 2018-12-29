USE [WeChatFramework]
GO

/****** Object:  Table [dbo].[WeChat_SdkTickets]    Script Date: 11/14/2018 22:58:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WeChat_SdkTickets]
(
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [AppId] [nvarchar](50) NOT NULL,
    [Ticket] [nvarchar](1024) NOT NULL,
    [ExpiredIn] [int] NOT NULL,
    [TicketType] [nvarchar](50) NOT NULL,
    [LastModifiedTime] [datetime] NOT NULL,
    CONSTRAINT [PK_WeChat_SdkTickets] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WeChat_AccessTokens]    Script Date: 11/14/2018 22:58:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WeChat_AccessTokens]
(
    [Id] [int] NOT NULL,
    [AppId] [nvarchar](50) NOT NULL,
    [Token] [nvarchar](1024) NOT NULL,
    [ExpiredIn] [int] NOT NULL,
    [LastModifiedTime] [datetime] NOT NULL,
    CONSTRAINT [PK_WeChat_AccessTokens] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
