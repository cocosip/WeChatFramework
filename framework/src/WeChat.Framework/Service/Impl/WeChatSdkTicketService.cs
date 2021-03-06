using DotCommon.Extensions;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
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
        private readonly IWeChatAccessTokenService _weChatAccessTokenService;

        /// <summary>Ctor
        /// </summary>
        public WeChatSdkTicketService(IServiceProvider provider, ILogger<WeChatFrameServiceBase> logger, IWeChatSdkTicketStore weChatSdkTicketStore, IWeChatAccessTokenService weChatAccessTokenService, IHttpClientFactory httpClientFactory) : base(provider, logger, httpClientFactory)
        {
            _weChatSdkTicketStore = weChatSdkTicketStore;
            _weChatAccessTokenService = weChatAccessTokenService;
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
            if (sdkTicketModel != null && !sdkTicketModel.IsExpired(DateTime.Now))
            {
                return sdkTicketModel.Ticket;
            }
            //从微信获取SdkTicket
            var sdkTicket = await GetRemoteSdkTicketAsync(appId, appSecret, type);
            sdkTicketModel = new SdkTicketModel()
            {
                AppId = appId,
                Ticket = sdkTicket.Ticket,
                ExpiredIn = sdkTicket.ExpiresIn,
                UpdateTime = DateTime.Now,
                TicketType = ticketType
            };
            //更新存储中的Sdk-Ticket
            await _weChatSdkTicketStore.CreateOrUpdateSdkTicketAsync(sdkTicketModel);
            return sdkTicket.Ticket;

        }

        /// <summary>从微信接口获取微信Sdk-Ticket
        /// </summary>
        /// <param name="appId">应用Id</param>
        /// <param name="appSecret">应用密钥,即appsecret</param>
        /// <param name="type"></param>
        /// <returns></returns>
        public async Task<SdkTicket> GetRemoteSdkTicketAsync(string appId, string appSecret, string type)
        {
            //先拿到应用的AccessToken
            var accessToken = await _weChatAccessTokenService.GetAccessTokenAsync(appId, appSecret);
            if (accessToken.IsNullOrWhiteSpace())
            {
                Logger.LogError("微信获取SdkTicket时,查询到的AccessToken为空");
            }
            var ticketType = type.ToUpper();

            var url = $"{WeChatSettings.WeChatUrls.BaseUrl}{WeChatSettings.WeChatUrls.SdkTicketResource}?access_token={accessToken}&type={type}";
            var client = HttpClientFactory.CreateClient();
            var response = await client.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"获取微信SdkTicket失败,请求url地址:[{url}],返回Http状态:{response.StatusCode}");
            }
            var responseString = await response.Content.ReadAsStringAsync();

            Logger.LogDebug(ParseLog(appId, "GetRemoteSdkTicketAsync", $"获取应用SdkTicket,类型:{type},返回结果:{responseString}"));
            var sdkTicket = JsonResponseParser.ParseResponse<SdkTicket>(responseString);
            //设置SdkTicket类型
            sdkTicket.Type = ticketType;
            return sdkTicket;
        }
    }
}
