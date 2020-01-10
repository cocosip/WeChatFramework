IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'wechat')
BEGIN
	EXEC('CREATE SCHEMA [wechat]')
END;

CREATE TABLE [wechat].[SdkTickets] (
[AppId] nvarchar(50) NOT NULL,
[Ticket] nvarchar(128) NOT NULL,
[TicketType] nvarchar(30) NOT NULL,
[ExpiredIn] int NOT NULL,
[LastModifiedTime] datetime NOT NULL,
PRIMARY KEY ([AppId]) 
)
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'', 
'TABLE', N'SdkTickets', 
NULL, NULL)) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'SdkTicket存储'
, @level0type = 'SCHEMA', @level0name = N''
, @level1type = 'TABLE', @level1name = N'SdkTickets'

ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'SdkTicket存储'
, @level0type = 'SCHEMA', @level0name = N''
, @level1type = 'TABLE', @level1name = N'SdkTickets'

GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'', 
'TABLE', N'SdkTickets', 
'COLUMN', N'AppId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'应用AppId'
, @level0type = 'SCHEMA', @level0name = N''
, @level1type = 'TABLE', @level1name = N'SdkTickets'
, @level2type = 'COLUMN', @level2name = N'AppId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'应用AppId'
, @level0type = 'SCHEMA', @level0name = N''
, @level1type = 'TABLE', @level1name = N'SdkTickets'
, @level2type = 'COLUMN', @level2name = N'AppId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'', 
'TABLE', N'SdkTickets', 
'COLUMN', N'Ticket')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'Ticket'
, @level0type = 'SCHEMA', @level0name = N''
, @level1type = 'TABLE', @level1name = N'SdkTickets'
, @level2type = 'COLUMN', @level2name = N'Ticket'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'Ticket'
, @level0type = 'SCHEMA', @level0name = N''
, @level1type = 'TABLE', @level1name = N'SdkTickets'
, @level2type = 'COLUMN', @level2name = N'Ticket'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'', 
'TABLE', N'SdkTickets', 
'COLUMN', N'TicketType')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'Ticket类型'
, @level0type = 'SCHEMA', @level0name = N''
, @level1type = 'TABLE', @level1name = N'SdkTickets'
, @level2type = 'COLUMN', @level2name = N'TicketType'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'Ticket类型'
, @level0type = 'SCHEMA', @level0name = N''
, @level1type = 'TABLE', @level1name = N'SdkTickets'
, @level2type = 'COLUMN', @level2name = N'TicketType'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'', 
'TABLE', N'SdkTickets', 
'COLUMN', N'ExpiredIn')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'有效期'
, @level0type = 'SCHEMA', @level0name = N''
, @level1type = 'TABLE', @level1name = N'SdkTickets'
, @level2type = 'COLUMN', @level2name = N'ExpiredIn'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'有效期'
, @level0type = 'SCHEMA', @level0name = N''
, @level1type = 'TABLE', @level1name = N'SdkTickets'
, @level2type = 'COLUMN', @level2name = N'ExpiredIn'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'', 
'TABLE', N'SdkTickets', 
'COLUMN', N'LastModifiedTime')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'最后修改时间'
, @level0type = 'SCHEMA', @level0name = N''
, @level1type = 'TABLE', @level1name = N'SdkTickets'
, @level2type = 'COLUMN', @level2name = N'LastModifiedTime'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'最后修改时间'
, @level0type = 'SCHEMA', @level0name = N''
, @level1type = 'TABLE', @level1name = N'SdkTickets'
, @level2type = 'COLUMN', @level2name = N'LastModifiedTime'
GO

CREATE TABLE [wechat].[AccessTokens] (
[AppId] nvarchar(50) NOT NULL,
[Token] nvarchar(1024) NOT NULL,
[ExpiredIn] int NOT NULL,
[LastModifiedTime] datetime NOT NULL,
PRIMARY KEY ([AppId]) 
)
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'', 
'TABLE', N'AccessTokens', 
NULL, NULL)) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'AccessToken存储'
, @level0type = 'SCHEMA', @level0name = N''
, @level1type = 'TABLE', @level1name = N'AccessTokens'

ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'AccessToken存储'
, @level0type = 'SCHEMA', @level0name = N''
, @level1type = 'TABLE', @level1name = N'AccessTokens'

GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'', 
'TABLE', N'AccessTokens', 
'COLUMN', N'AppId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'应用AppId'
, @level0type = 'SCHEMA', @level0name = N''
, @level1type = 'TABLE', @level1name = N'AccessTokens'
, @level2type = 'COLUMN', @level2name = N'AppId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'应用AppId'
, @level0type = 'SCHEMA', @level0name = N''
, @level1type = 'TABLE', @level1name = N'AccessTokens'
, @level2type = 'COLUMN', @level2name = N'AppId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'', 
'TABLE', N'AccessTokens', 
'COLUMN', N'Token')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'Token'
, @level0type = 'SCHEMA', @level0name = N''
, @level1type = 'TABLE', @level1name = N'AccessTokens'
, @level2type = 'COLUMN', @level2name = N'Token'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'Token'
, @level0type = 'SCHEMA', @level0name = N''
, @level1type = 'TABLE', @level1name = N'AccessTokens'
, @level2type = 'COLUMN', @level2name = N'Token'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'', 
'TABLE', N'AccessTokens', 
'COLUMN', N'ExpiredIn')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'有效期'
, @level0type = 'SCHEMA', @level0name = N''
, @level1type = 'TABLE', @level1name = N'AccessTokens'
, @level2type = 'COLUMN', @level2name = N'ExpiredIn'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'有效期'
, @level0type = 'SCHEMA', @level0name = N''
, @level1type = 'TABLE', @level1name = N'AccessTokens'
, @level2type = 'COLUMN', @level2name = N'ExpiredIn'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'', 
'TABLE', N'AccessTokens', 
'COLUMN', N'LastModifiedTime')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'最后修改时间'
, @level0type = 'SCHEMA', @level0name = N''
, @level1type = 'TABLE', @level1name = N'AccessTokens'
, @level2type = 'COLUMN', @level2name = N'LastModifiedTime'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'最后修改时间'
, @level0type = 'SCHEMA', @level0name = N''
, @level1type = 'TABLE', @level1name = N'AccessTokens'
, @level2type = 'COLUMN', @level2name = N'LastModifiedTime'
GO

