using DotCommon.Caching;
using System.Threading.Tasks;
using WeChat.Framework.Model;
namespace WeChat.Framework.Infrastructure.Store
{
    /// <summary>空的微信应用AcceessToken存储
    /// </summary>
    public class MemoryWeChatAccessTokenStore : IWeChatAccessTokenStore
    {
        private readonly IDistributedCache<AccessTokenModel> _accessTokenCache;

        /// <summary>Ctor
        /// </summary>
        public MemoryWeChatAccessTokenStore(IDistributedCache<AccessTokenModel> accessTokenCache)
        {
            _accessTokenCache = accessTokenCache;
        }

        /// <summary>根据应用Id获取当前token
        /// </summary>
        public async Task<AccessTokenModel> GetAccessTokenAsync(string appId)
        {
            var accessToken = await _accessTokenCache.GetAsync(appId);
            return accessToken;
        }

        /// <summary>创建或者修改AccessToken
        /// </summary>
        public async Task CreateOrUpdateAccessTokenAsync(AccessTokenModel accessToken)
        {
            await _accessTokenCache.SetAsync(accessToken.AppId, accessToken);
        }
    }
}
