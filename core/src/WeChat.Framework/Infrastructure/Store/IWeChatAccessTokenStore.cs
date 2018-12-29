using System.Threading.Tasks;
using WeChat.Framework.Model;

namespace WeChat.Framework.Infrastructure.Store
{
    /// <summary>微信应用AcceessToken存储
    /// </summary>
    public interface IWeChatAccessTokenStore
    {
        /// <summary>根据应用Id获取当前token
        /// </summary>
        Task<AccessTokenModel> GetAccessTokenAsync(string appId);

        /// <summary>创建或者修改AccessToken
        /// </summary>
        Task CreateOrUpdateAccessTokenAsync(AccessTokenModel accessToken);
    }
}
