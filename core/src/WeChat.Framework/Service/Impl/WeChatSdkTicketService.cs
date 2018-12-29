using DotCommon.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WeChat.Framework.Infrastructure.Store;
using WeChat.Framework.Model;

namespace WeChat.Framework.Service
{

    /// <summary>微信Sdk-Ticket服务
    /// </summary>
    public class WeChatSdkTicketService : WeChatFrameServiceBase, IWeChatSdkTicketService
    {
        private readonly IWeChatSdkTicketStore _weChatSdkTicketStore;

        /// <summary>Ctor
        /// </summary>
        public WeChatSdkTicketService(IServiceProvider provider, ILogger<WeChatLoggerName> logger, IWeChatSdkTicketStore weChatSdkTicketStore) : base(provider, logger)
        {
            _weChatSdkTicketStore = weChatSdkTicketStore;
        }

        /// <summary>获取可用的Sdk-Ticket(先从本地存储中获取,如果不存在,就从微信接口获取)
        /// </summary>
        /// <param name="appId">应用Id</param>
        /// <param name="appSecret">应用密钥,即appsecret</param>
        /// <param name="type"></param>
        /// <returns></returns>
        public async Task<string> GetSdkTicketAsync(string appId, string appSecret, string type)
        {
            //从存储中读取SdkTicketModel
            var ticketType = type.ToUpper();
            var sdkTicketModel = await _weChatSdkTicketStore.GetSdkTicketAsync(appId, ticketType);
            if (sdkTicketModel == null || (sdkTicketModel != null && sdkTicketModel.IsExpired(DateTime.Now)))
            {
                //从微信获取SdkTicket
                var sdkTicket = await GetRemoteSdkTicketAsync(appId, appSecret, type);
                sdkTicketModel = new SdkTicketModel()
                {
                    AppId = appId,
                    Ticket = sdkTicket.Ticket,
                    ExpiredIn = sdkTicket.ExpiresIn,
                    LastModifiedTime = DateTime.Now,
                    TicketType = ticketType
                };
                //更新存储中的Sdk-Ticket
                await _weChatSdkTicketStore.CreateOrUpdateSdkTicketAsync(sdkTicketModel);
                return sdkTicket.Ticket;
            }
            return sdkTicketModel.Ticket;
        }

        /// <summary>从微信接口获取微信Sdk-Ticket
        /// </summary>
        /// <param name="appId">应用Id</param>
        /// <param name="appSecret">应用密钥,即appsecret</param>
        /// <param name="type"></param>
        /// <returns></returns>
        public async Task<SdkTicket> GetRemoteSdkTicketAsync(string appId, string appSecret, string type)
        {
            var ticketType = type.ToUpper();
            IHttpRequest request = new HttpRequest("https://api.weixin.qq.com/cgi-bin/ticket/getticket", Method.GET)
                .AddParameter("appid", appId)
                .AddParameter("secret", appSecret)
                .AddParameter("type", type);
            var response = await Client.ExecuteAsync(request);
            Logger.LogDebug(ParseLog(appId, "GetRemoteSdkTicketAsync", $"获取应用SdkTicket,类型:{type},返回结果:{response.Content}"));
            var sdkTicket = JsonResponseParser.ParseResponse<SdkTicket>(response.Content);
            //设置SdkTicket类型
            sdkTicket.Type = ticketType;
            return sdkTicket;
        }
    }
}
