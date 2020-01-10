CREATE SCHEMA IF NOT EXISTS "wechat";
CREATE TABLE IF NOT EXISTS "wechat"."sdk_tickets" (
"appid" varchar(50) NOT NULL,
"ticket" varchar(128) NOT NULL,
"ticket_type" varchar(30) NOT NULL,
"expired_in" int4 NOT NULL,
"update_time" timestamp(0) NOT NULL,
PRIMARY KEY ("appid") 
)
WITHOUT OIDS;
COMMENT ON TABLE "sdk_tickets" IS 'SdkTicket存储';
COMMENT ON COLUMN "sdk_tickets"."appid" IS '应用AppId';
COMMENT ON COLUMN "sdk_tickets"."ticket" IS 'Ticket';
COMMENT ON COLUMN "sdk_tickets"."ticket_type" IS 'Ticket类型';
COMMENT ON COLUMN "sdk_tickets"."expired_in" IS '有效期';
COMMENT ON COLUMN "sdk_tickets"."update_time" IS '最后修改时间';

CREATE TABLE IF NOT EXISTS "wechat"."access_tokens" (
"appid" varchar(50) NOT NULL,
"token" varchar(1024) NOT NULL,
"expired_in" int4 NOT NULL,
"update_time" timestamp(0) NOT NULL,
PRIMARY KEY ("appid") 
)
WITHOUT OIDS;
COMMENT ON TABLE "access_tokens" IS 'AccessToken存储';
COMMENT ON COLUMN "access_tokens"."appid" IS '应用AppId';
COMMENT ON COLUMN "access_tokens"."token" IS 'Token';
COMMENT ON COLUMN "access_tokens"."expired_in" IS '有效期';
COMMENT ON COLUMN "access_tokens"."update_time" IS '最后修改时间';

