using Dapper;
using DotCommon.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Npgsql;
using System.Threading.Tasks;
using WeChat.Framework.Model;

namespace WeChat.Framework.Infrastructure.Store
{
    /// <summary>PostgreSql微信Sdk-Ticket存储
    /// </summary>
    public class PostgreSqlWeChatSdkTicketStore : BasePostgreSqlStore, IWeChatSdkTicketStore
    {
        /// <summary>Ctor
        /// </summary>
        public PostgreSqlWeChatSdkTicketStore(IOptions<WeChatFrameworkPostgreSqlOption> option, ILogger<BasePostgreSqlStore> logger) : base(option, logger)
        {

        }

        /// <summary>根据应用Id,ticket类型获取Sdk-Ticket
        /// </summary>
        /// <param name="appId">应用AppId</param>
        /// <param name="ticketType">Ticket类型</param>
        /// <returns></returns>
        public async Task<SdkTicketModel> GetSdkTicketAsync(string appId, string ticketType)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    var sql = $@"SELECT TOP 1 * FROM {GetSchemaSdkTicketTableName()} WHERE ""appid""=@AppId AND ""ticket_type""=@TicketType";
                    return await connection.QueryFirstOrDefaultAsync<SdkTicketModel>(sql, new { AppId = appId, TicketType = ticketType });
                }
            }
            catch (NpgsqlException ex)
            {
                Logger.LogError("查询微信应用SdkTicket出错,AppId:{0},TicketType:{1},Ex:{2}", appId, ticketType, ex.Message);
                throw;
            }
        }

        /// <summary>创建或者修改Sdk-Ticket
        /// </summary>
        public async Task CreateOrUpdateSdkTicketAsync(SdkTicketModel sdkTicket)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    //先查询JsApiTicket,是否存在
                    var querySdkTicket = await GetSdkTicketAsync(sdkTicket.AppId, sdkTicket.TicketType);

                    var sql = "";
                    if (querySdkTicket == null || querySdkTicket.AppId.IsNullOrWhiteSpace())
                    {
                        //创建
                        sql = $@"INSERT INTO {GetSchemaSdkTicketTableName()} (""appid"",""ticket"",""expired_in"",""update_time"",""ticket_type"") VALUES (@AppId,@Ticket,@ExpiredIn,@UpdateTime,@TicketType)";
                    }
                    else
                    {
                        //修改
                        sql = $@"UPDATE {GetSchemaSdkTicketTableName()} SET ""ticket""=@Ticket,""expired_in""=@ExpiredIn,""update_time""=@UpdateTime WHERE ""appid""=@AppId AND ""ticket_type""=@TicketType";
                    }
                    await connection.ExecuteAsync(sql, sdkTicket);

                }
            }
            catch (NpgsqlException ex)
            {
                Logger.LogError("创建或者修改微信SdkTicket出错,AppId:{0},TicketType:{1},Ex:{2}", sdkTicket.AppId, sdkTicket.TicketType, ex.Message);
                throw;
            }
        }

    }
}
