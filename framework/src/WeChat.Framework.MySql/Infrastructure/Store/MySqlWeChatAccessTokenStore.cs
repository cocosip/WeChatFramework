using Dapper;
using DotCommon.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using WeChat.Framework.Model;

namespace WeChat.Framework.Infrastructure.Store
{
    /// <summary>MySql微信应用AccessToken存储
    /// </summary>
    public class MySqlWeChatAccessTokenStore : BaseMySqlStore, IWeChatAccessTokenStore
    {

        /// <summary>Ctor
        /// </summary>
        public MySqlWeChatAccessTokenStore(IOptions<WeChatFrameworkMySqlOption> option, ILogger<BaseMySqlStore> logger) : base(option, logger)
        {
        }


        /// <summary>根据应用Id获取当前token
        /// </summary>
        public async Task<AccessTokenModel> GetAccessTokenAsync(string appId)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    var sql = $"SELECT TOP 1 * FROM {GetSchemaAccessTokenTableName()} WHERE `AppId`=?AppId";
                    return await connection.QueryFirstOrDefaultAsync<AccessTokenModel>(sql, new { AppId = appId });
                }
            }
            catch (MySqlException ex)
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
                using (var connection = GetConnection())
                {
                    //先查询AccessToken,是否存在
                    var queryAccessToken = await GetAccessTokenAsync(accessToken.AppId);

                    var sql = "";
                    if (queryAccessToken == null || queryAccessToken.AppId.IsNullOrWhiteSpace())
                    {
                        //创建
                        sql = $"INSERT INTO {GetSchemaAccessTokenTableName()} (`AppId`,`Token`,`ExpiredIn`,`UpdateTime`) VALUES (?AppId,?Token,?ExpiredIn,?UpdateTime)";
                    }
                    else
                    {
                        //修改
                        sql = $"UPDATE `{GetSchemaAccessTokenTableName()}` SET `Token`=?Token,`ExpiredIn`=?ExpiredIn,`UpdateTime`=?UpdateTime WHERE `AppId`=?AppId";
                    }
                    await connection.ExecuteAsync(sql, accessToken);

                }
            }
            catch (MySqlException ex)
            {
                Logger.LogError("创建或者修改微信AccessToken出错,AppId:{0},Ex:{1}", accessToken.AppId, ex.Message);
                throw;
            }
        }

    }
}
