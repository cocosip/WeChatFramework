using System.Threading.Tasks;
using WeChat.Framework.Model;

namespace WeChat.Framework.Service
{
    /// <summary>微信Sdk-Ticket服务
    /// </summary>
    public interface IWeChatSdkTicketService
    {
        /// <summary>获取可用的Sdk-Ticket(先从本地存储中获取,如果不存在,就从微信接口获取)
        /// </summary>
        /// <param name="appId">应用Id</param>
        /// <param name="appSecret">应用密钥,即appsecret</param>
        /// <param name="type"></param>
        /// <returns></returns>
        Task<string> GetSdkTicketAsync(string appId, string appSecret, string type);

        /// <summary>从微信接口获取微信Sdk-Ticket
        /// </summary>
        /// <param name="appId">应用Id</param>
        /// <param name="appSecret">应用密钥,即appsecret</param>
        /// <param name="type"></param>
        /// <returns></returns>
        Task<SdkTicket> GetRemoteSdkTicketAsync(string appId, string appSecret, string type);
    }
}
