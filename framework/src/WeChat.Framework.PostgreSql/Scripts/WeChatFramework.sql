CREATE SCHEMA IF NOT EXISTS "wechat";

CREATE TABLE IF NOT EXISTS "wechat"."sdk_tickets" (
"appid" VARCHAR(50) PRIMARY KEY NOT NULL,
"ticket" VARCHAR(128) NOT NULL,
"ticket_type" VARCHAR(30) NOT NULL,
"expired_in" INT4 NOT NULL,
"update_time" TIMESTAMP(0) NOT NULL);

CREATE TABLE IF NOT EXISTS "wechat"."access_tokens" (
"appid" VARCHAR(50) PRIMARY KEY NOT NULL,
"token" VARCHAR(1024) NOT NULL,
"expired_in" int4 NOT NULL,
"update_time" TIMESTAMP(0) NOT NULL);
