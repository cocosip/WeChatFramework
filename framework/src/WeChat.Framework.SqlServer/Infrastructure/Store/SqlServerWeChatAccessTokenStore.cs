using Dapper;
using DotCommon.Extensions;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using System.Threading.Tasks;
using WeChat.Framework.Model;

namespace WeChat.Framework.Infrastructure.Store
{
    /// <summary>SqlServer微信应用AccessToken存储
    /// </summary>
    public class SqlServerWeChatAccessTokenStore : BaseSqlServerStore, IWeChatAccessTokenStore
    {
        /// <summary>表名称
        /// </summary>
        private readonly string _tableName;

        /// <summary>Ctor
        /// </summary>
        public SqlServerWeChatAccessTokenStore(WeChatFrameworkSqlServerOption option, ILoggerFactory loggerFactory) : base(option, loggerFactory)
        {
            _tableName = option.AccessTokenTableName;
        }


        /// <summary>根据应用Id获取当前token
        /// </summary>
        public async Task<AccessTokenModel> GetAccessTokenAsync(string appId)
        {
            try
            {
                using(var connection = GetConnection())
                {
                    var sql = $"SELECT TOP 1 * FROM {_tableName} WHERE AppId=@AppId";
                    return await connection.QueryFirstOrDefaultAsync<AccessTokenModel>(sql, new { AppId = appId });
                }
            }
            catch (SqlException ex)
            {
                Logger.LogError("查询微信应用AccessToken出错,AppId:{0},Ex:{1}", appId, ex.Message);
                throw;
            }
        }


        /// <summary>创建或者修改微信应用AccessToken
        /// </summary>
        public async Task CreateOrUpdateAccessTokenAsync(AccessTokenModel accessToken)
        {
            try
            {
                using(var connection = GetConnection())
                {
                    //先查询AccessToken,是否存在
                    var queryAccessToken = await GetAccessTokenAsync(accessToken.AppId);

                    var sql = "";
                    if (queryAccessToken == null || queryAccessToken.AppId.IsNullOrWhiteSpace())
                    {
                        //创建
                        sql = $"INSERT INTO {_tableName} ([AppId],[Token],[ExpiredIn],[LastModifiedTime]) VALUES (@AppId,@Token,@ExpiredIn,@LastModifiedTime)";
                    }
                    else
                    {
                        //修改
                        sql = $"UPDATE {_tableName} SET [Token]=@Token,[ExpiredIn]=@ExpiredIn,[LastModifiedTime]=@LastModifiedTime WHERE [AppId]=@AppId";
                    }
                    await connection.ExecuteAsync(sql, accessToken);

                }
            }
            catch (SqlException ex)
            {
                Logger.LogError("创建或者修改微信AccessToken出错,AppId:{0},Ex:{1}", accessToken.AppId, ex.Message);
                throw;
            }
        }

    }
}
