namespace WeChat.Framework
{
    /// <summary>PostgreSql配置信息
    /// </summary>
    public class WeChatFrameworkPostgreSqlOption
    {
        /// <summary>数据库连接字符串
        /// </summary>
        public string DbConnectionString { get; set; }

        /// <summary>Schema
        /// </summary>
        public string Schema { get; set; } = "wechat";

        /// <summary>AccessToken存储的表名称
        /// </summary>
        public string AccessTokenTableName { get; set; } = "access_tokens";

        /// <summary>SdkTicket存储的表名称
        /// </summary>
        public string SdkTicketTableName { get; set; } = "sdk_tickets";
    }
}
