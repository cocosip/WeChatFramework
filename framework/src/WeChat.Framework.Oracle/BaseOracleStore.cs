using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
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
        protected BaseOracleStore(IOptions<WeChatFrameworkOracleOption> option, ILogger<BaseOracleStore> logger)
        {
            Option = option.Value;
            Logger = logger;
        }

        /// <summary>获取连接
        /// </summary>
        protected OracleConnection GetConnection()
        {
            return new OracleConnection(Option.DbConnectionString);
        }


        /// <summary>GetSchemaAccessTokenTableName
        /// </summary>
        protected string GetSchemaAccessTokenTableName()
        {
            return $@"""{Option.Schema}"".""{Option.AccessTokenTableName}""";
        }


        /// <summary>GetSchemaSdkTicketTableName
        /// </summary>
        protected string GetSchemaSdkTicketTableName()
        {
            return $@"""{Option.Schema}"".""{Option.SdkTicketTableName}""";
        }

    }
}
