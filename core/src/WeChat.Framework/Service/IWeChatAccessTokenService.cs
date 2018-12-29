using System.Threading.Tasks;
using WeChat.Framework.Model;

namespace WeChat.Framework.Service
{
    /// <summary>微信AccessToken服务(App,小程序,公众号)
    /// </summary>
    public interface IWeChatAccessTokenService
    {
        /// <summary>获取可用的AccessToken(先从本地存储中获取,如果不存在,就从微信接口获取)
        /// </summary>
        /// <param name="appId">应用AppId</param>
        /// <param name="appSecret">应用密钥,即appsecret</param>
        /// <returns></returns>
        Task<string> GetAccessTokenAsync(string appId, string appSecret);

        /// <summary>从微信服务器获取微信应用的AccessToken
        /// </summary>
        /// <param name="appId">应用AppId</param>
        /// <param name="appSecret">应用密钥,即appsecret</param>
        /// <returns></returns>
        Task<AccessToken> GetRemoteAccessTokenAsync(string appId, string appSecret);
    }
}
