IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'wechat')
BEGIN
	EXEC('CREATE SCHEMA [wechat]')
END;

IF NOT EXISTS (select * from dbo.sysobjects where xtype='U' and Name = 'SdkTickets')
BEGIN
  CREATE TABLE [wechat].[SdkTickets] (
  [AppId] NVARCHAR(50) PRIMARY KEY NOT NULL,
  [Ticket] NVARCHAR(128) NOT NULL,
  [TicketType] NVARCHAR(30) NOT NULL,
  [ExpiredIn] INT NOT NULL,
  [UpdateTime] DATETIME NOT NULL);
END
GO
IF NOT EXISTS (select * from dbo.sysobjects where xtype='U' and Name = 'AccessTokens')
BEGIN
  CREATE TABLE [wechat].[AccessTokens] (
  [AppId] NVARCHAR(50) PRIMARY KEY NOT NULL,
  [Token] NVARCHAR(1024) NOT NULL,
  [ExpiredIn] INT NOT NULL,
  [LastModifiedTime] DATETIME NOT NULL);
END
GO

