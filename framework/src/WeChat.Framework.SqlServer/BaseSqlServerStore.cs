using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;

namespace WeChat.Framework
{
    /// <summary>基础抽象存储
    /// </summary>
    public abstract class BaseSqlServerStore
    {
        /// <summary>SqlServer配置信息
        /// </summary>
        protected WeChatFrameworkSqlServerOption Option { get; set; }

        /// <summary>Logger
        /// </summary>
        protected ILogger Logger { get; set; }

        /// <summary>Ctor
        /// </summary>
        protected BaseSqlServerStore(IOptions<WeChatFrameworkSqlServerOption> option, ILogger<BaseSqlServerStore> logger)
        {
            Option = option.Value;
            Logger = logger;
        }

        /// <summary>获取连接
        /// </summary>
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(Option.DbConnectionString);
        }

        /// <summary>GetSchemaAccessTokenTableName
        /// </summary>
        protected string GetSchemaAccessTokenTableName()
        {
            return $@"[{Option.Schema}].[{Option.AccessTokenTableName}]";
        }


        /// <summary>GetSchemaSdkTicketTableName
        /// </summary>
        protected string GetSchemaSdkTicketTableName()
        {
            return $@"[{Option.Schema}].[{Option.SdkTicketTableName}]";
        }

    }
}
