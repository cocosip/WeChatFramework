using Microsoft.Extensions.Logging;
using Oracle.ManagedDataAccess.Client;

namespace WeChat.Framework
{
    /// <summary>基础抽象存储
    /// </summary>
    public abstract class BaseOracleStore
    {
        /// <summary>Oracle配置信息
        /// </summary>
        protected WeChatFrameworkOracleOption Option { get; set; }
        /// <summary>Logger
        /// </summary>
        protected ILogger Logger { get; set; }

        /// <summary>Ctor
        /// </summary>
        protected BaseOracleStore(WeChatFrameworkOracleOption option, ILogger<BaseOracleStore> logger)
        {
            Option = option;
            Logger = logger;
        }

        /// <summary>获取连接
        /// </summary>
        protected OracleConnection GetConnection()
        {
            return new OracleConnection(Option.DbConnectionString);
        }

    }
}
