using Microsoft.Extensions.Logging;
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
        protected BaseSqlServerStore(WeChatFrameworkSqlServerOption option, ILoggerFactory loggerFactory)
        {
            Option = option;
            Logger = loggerFactory.CreateLogger(WeChatSettings.LoggerName);
        }

        /// <summary>获取连接
        /// </summary>
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(Option.DbConnectionString);
        }

    }
}
