CREATE SCHEMA IF NOT EXISTS "wechat";
CREATE TABLE "wechat"."SDK_TICKETS" IF NOT EXISTS (
"APPID" NVARCHAR2(50) NOT NULL,
"TICKET" NVARCHAR2(128) NOT NULL,
"TICKET_TYPE" NVARCHAR2(30) NOT NULL,
"EXPIRED_IN" NUMBER(11,0) NOT NULL,
"UPDATE_TIME" DATE NOT NULL,
PRIMARY KEY ("APPID") 
)
NOCOMPRESS 
NOPARALLEL ;
COMMENT ON TABLE "SDK_TICKETS" IS 'SdkTicket存储';
COMMENT ON COLUMN "SDK_TICKETS"."APPID" IS '应用AppId';
COMMENT ON COLUMN "SDK_TICKETS"."TICKET" IS 'Ticket';
COMMENT ON COLUMN "SDK_TICKETS"."TICKET_TYPE" IS 'Ticket类型';
COMMENT ON COLUMN "SDK_TICKETS"."EXPIRED_IN" IS '有效期';
COMMENT ON COLUMN "SDK_TICKETS"."UPDATE_TIME" IS '最后修改时间';

CREATE TABLE "wechat"."ACCESS_TOKENS" IF NOT EXISTS (
"APPID" NVARCHAR2(50) NOT NULL,
"TOKEN" NCLOB NOT NULL,
"EXPIRED_IN" NUMBER(11,0) NOT NULL,
"UPDATE_TIME" DATE NOT NULL,
PRIMARY KEY ("APPID") 
)
NOCOMPRESS 
NOPARALLEL ;
COMMENT ON TABLE "ACCESS_TOKENS" IS 'AccessToken存储';
COMMENT ON COLUMN "ACCESS_TOKENS"."APPID" IS '应用AppId';
COMMENT ON COLUMN "ACCESS_TOKENS"."TOKEN" IS 'Token';
COMMENT ON COLUMN "ACCESS_TOKENS"."EXPIRED_IN" IS '有效期';
COMMENT ON COLUMN "ACCESS_TOKENS"."UPDATE_TIME" IS '最后修改时间';
