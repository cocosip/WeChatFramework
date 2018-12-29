using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using WeChat.Framework.Model;

namespace WeChat.Framework.Infrastructure.Store
{
    /// <summary>空的微信应用AcceessToken存储
    /// </summary>
    public class EmptyWeChatAccessTokenStore : IWeChatAccessTokenStore
    {
        private readonly ILogger _logger;

        /// <summary>Ctor
        /// </summary>
        public EmptyWeChatAccessTokenStore(ILogger<WeChatLoggerName> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// </summary>
        public Task<AccessTokenModel> GetAccessTokenAsync(string appId)
        {
            _logger.LogWarning($"未实现方法:EmptyWeChatAccessTokenStore.GetAccessTokenAsync");
            return Task.FromResult<AccessTokenModel>(null);
        }

        /// <summary>创建或者修改AccessToken
        /// </summary>
        public Task CreateOrUpdateAccessTokenAsync(AccessTokenModel accessToken)
        {
            _logger.LogWarning($"未实现方法:EmptyWeChatAccessTokenStore.CreateOrUpdateAccessTokenAsync");
            return Task.FromResult(0);
        }
    }
}
