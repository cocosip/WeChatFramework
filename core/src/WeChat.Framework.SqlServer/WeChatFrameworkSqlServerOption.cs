namespace WeChat.Framework
{
    /// <summary>SqlServer配置信息
    /// </summary>
    public class WeChatFrameworkSqlServerOption
    {
        /// <summary>数据库连接字符串
        /// </summary>
        public string DbConnectionString { get; set; }

        /// <summary>AccessToken存储的表名称
        /// </summary>
        public string AccessTokenTableName { get; set; } = "WeChat_AccessTokens";

        /// <summary>SdkTicket存储的表名称
        /// </summary>
        public string SdkTicketTableName { get; set; } = "WeChat_SdkTickets";
    }
}
