namespace WeChat.Framework
{
    /// <summary>Oracle配置信息
    /// </summary>
    public class WeChatFrameworkOracleOption
    {
        /// <summary>数据库连接字符串
        /// </summary>
        public string DbConnectionString { get; set; }

        /// <summary>Schema
        /// </summary>
        public string Schema { get; set; } = "wechat";

        /// <summary>AccessToken存储的表名称
        /// </summary>
        public string AccessTokenTableName { get; set; } = "ACCESS_TOKENS";

        /// <summary>SdkTicket存储的表名称
        /// </summary>
        public string SdkTicketTableName { get; set; } = "SDK_TICKETS";
    }
}
