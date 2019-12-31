using Microsoft.Extensions.Logging;
using RestSharp;
using System;
using System.Threading.Tasks;
using WeChat.Framework.Infrastructure.Store;
using WeChat.Framework.Model;

namespace WeChat.Framework.Service
{
    /// <summary>微信AccessToken服务(App,小程序,公众号)
    /// </summary>
    public class WeChatAccessTokenService : WeChatFrameServiceBase, IWeChatAccessTokenService
    {

        /// <summary>微信AccessToken存储
        /// </summary>
        private readonly IWeChatAccessTokenStore _weChatAccessTokenStore;

        /// <summary>Ctor
        /// </summary>
        public WeChatAccessTokenService(IServiceProvider provider, ILogger<WeChatFrameServiceBase> logger, IWeChatAccessTokenStore weChatAccessTokenStore) : base(provider, logger)
        {
            _weChatAccessTokenStore = weChatAccessTokenStore;
        }

        /// <summary>获取可用的AccessToken(先从本地存储中获取,如果不存在,就从微信接口获取)
        /// </summary>
        /// <param name="appId">应用AppId</param>
        /// <param name="appSecret">应用密钥,即appsecret</param>
        /// <returns></returns>
        public async Task<string> GetAccessTokenAsync(string appId, string appSecret)
        {
            //从存储中读取AccessToken
            var accessTokenModel = await _weChatAccessTokenStore.GetAccessTokenAsync(appId);
            if (accessTokenModel != null && !accessTokenModel.IsExpired(DateTime.Now))
            {
                return accessTokenModel.Token;
            }
            //从微信获取AccessToken
            var accessToken = await GetRemoteAccessTokenAsync(appId, appSecret);
            accessTokenModel = new AccessTokenModel()
            {
                AppId = appId,
                Token = accessToken.Token,
                ExpiredIn = accessToken.ExpiresIn,
                LastModifiedTime = DateTime.Now
            };
            //更新存储中的AccessToken
            await _weChatAccessTokenStore.CreateOrUpdateAccessTokenAsync(accessTokenModel);
            return accessToken.Token;
        }


        /// <summary>从微信服务器获取微信应用的AccessToken
        /// </summary>
        /// <param name="appId">应用AppId</param>
        /// <param name="appSecret">应用密钥,即appsecret</param>
        /// <returns></returns>
        public async Task<AccessToken> GetRemoteAccessTokenAsync(string appId, string appSecret)
        {
            IRestRequest request = new RestRequest(WeChatSettings.WeChatUrls.AccessTokenResource, Method.GET);
            request
                .AddParameter("appid", appId)
                .AddParameter("secret", appSecret)
                .AddParameter("grant_type", "client_credential");
            var response = await Client.ExecuteTaskAsync(request);
            Logger.LogDebug(ParseLog(appId, "GetRemoteAccessToken", $"获取应用AccessToken,返回结果:{response.Content}"));
            return JsonResponseParser.ParseResponse<AccessToken>(response.Content);
        }

    }
}
