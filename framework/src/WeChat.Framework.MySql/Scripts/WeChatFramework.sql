CREATE TABLE IF NOT EXISTS `SdkTickets` (
`AppId` varchar(50) PRIMARY KEY NOT NULL COMMENT '应用AppId',
`Ticket` varchar(128) NOT NULL COMMENT 'Ticket',
`TicketType` varchar(30) NOT NULL COMMENT 'Ticket类型',
`ExpiredIn` int NOT NULL COMMENT '有效期',
`LastModifiedTime` datetime NOT NULL ON UPDATE CURRENT_TIMESTAMP COMMENT '最后修改时间'
);
CREATE TABLE `AccessTokens` IF NOT EXISTS (
`AppId` varchar(50) PRIMARY KEY NOT NULL COMMENT '应用AppId',
`Token` text NOT NULL COMMENT 'Token',
`ExpiredIn` int NOT NULL COMMENT '有效期',
`LastModifiedTime` datetime NOT NULL ON UPDATE CURRENT_TIMESTAMP COMMENT '最后修改时间'
);

