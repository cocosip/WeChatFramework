using Dapper;
using DotCommon.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using WeChat.Framework.Model;

namespace WeChat.Framework.Infrastructure.Store
{
    /// <summary>MySql微信Sdk-Ticket存储
    /// </summary>
    public class MySqlWeChatSdkTicketStore : BaseMySqlStore, IWeChatSdkTicketStore
    {
        /// <summary>Ctor
        /// </summary>
        public MySqlWeChatSdkTicketStore(IOptions<WeChatFrameworkMySqlOption> option, ILogger<BaseMySqlStore> logger) : base(option, logger)
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
                    var sql = $"SELECT TOP 1 * FROM {GetSchemaSdkTicketTableName()} WHERE `AppId`=@AppId AND `TicketType`=?TicketType";
                    return await connection.QueryFirstOrDefaultAsync<SdkTicketModel>(sql, new { AppId = appId, TicketType = ticketType });
                }
            }
            catch (MySqlException ex)
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
                        sql = $"INSERT INTO {GetSchemaSdkTicketTableName()} (`AppId`,`Ticket`,`ExpiredIn`,`LastModifiedTime`,`TicketType`) VALUES (?AppId,?Ticket,?ExpiredIn,?LastModifiedTime,?TicketType)";
                    }
                    else
                    {
                        //修改
                        sql = $"UPDATE {GetSchemaSdkTicketTableName()} SET `Ticket`=@Ticket,`ExpiredIn`=?ExpiredIn,`UpdateTime`=?UpdateTime WHERE `AppId`=?AppId AND `TicketType`=?TicketType";
                    }
                    await connection.ExecuteAsync(sql, sdkTicket);

                }
            }
            catch (MySqlException ex)
            {
                Logger.LogError("创建或者修改微信SdkTicket出错,AppId:{0},TicketType:{1},Ex:{2}", sdkTicket.AppId, sdkTicket.TicketType, ex.Message);
                throw;
            }
        }

    }
}
