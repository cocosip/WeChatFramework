using Microsoft.Extensions.Logging;
using Npgsql;

namespace WeChat.Framework
{
    /// <summary>基础抽象存储
    /// </summary>
    public abstract class BasePostgreSqlStore
    {
        /// <summary>PostgreSql配置信息
        /// </summary>
        protected WeChatFrameworkPostgreSqlOption Option { get; set; }
        /// <summary>Logger
        /// </summary>
        protected ILogger Logger { get; set; }

        /// <summary>Ctor
        /// </summary>
        protected BasePostgreSqlStore(WeChatFrameworkPostgreSqlOption option, ILoggerFactory loggerFactory)
        {
            Option = option;
            Logger = loggerFactory.CreateLogger(WeChatSettings.LoggerName);
        }

        /// <summary>获取连接
        /// </summary>
        protected NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(Option.DbConnectionString);
        }

    }
}
