using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;

namespace WeChat.Framework
{
    /// <summary>基础抽象存储
    /// </summary>
    public abstract class BaseMySqlStore
    {
        /// <summary>MySql配置信息
        /// </summary>
        protected WeChatFrameworkMySqlOption Option { get; set; }

        /// <summary>Logger
        /// </summary>
        protected ILogger Logger { get; set; }

        /// <summary>Ctor
        /// </summary>
        protected BaseMySqlStore(WeChatFrameworkMySqlOption option, ILogger<BaseMySqlStore> logger)
        {
            Option = option;
            Logger = logger;
        }

        /// <summary>获取连接
        /// </summary>
        protected MySqlConnection GetConnection()
        {
            return new MySqlConnection(Option.DbConnectionString);
        }

        /// <summary>GetSchemaAccessTokenTableName
        /// </summary>
        protected string GetSchemaAccessTokenTableName()
        {
            return $@"`{Option.AccessTokenTableName}`";
        }


        /// <summary>GetSchemaSdkTicketTableName
        /// </summary>
        protected string GetSchemaSdkTicketTableName()
        {
            return $@"`{Option.SdkTicketTableName}`";
        }

    }
}
