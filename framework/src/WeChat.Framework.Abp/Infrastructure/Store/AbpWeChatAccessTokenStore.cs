using Abp.Domain.Repositories;
using DotCommon.ObjectMapping;
using System.Threading.Tasks;
using WeChat.Framework.Model;

namespace WeChat.Framework.Infrastructure.Store
{
    /// <summary>微信应用AccessToken存储 Abp扩展
    /// </summary>
    public class AbpWeChatAccessTokenStore : IWeChatAccessTokenStore
    {
        private readonly IObjectMapper _objectMapper;
        private readonly IRepository<AbpAccessToken> _abpAccessTokenRepository;

        /// <summary>Ctor
        /// </summary>
        public AbpWeChatAccessTokenStore(IObjectMapper objectMapper, IRepository<AbpAccessToken> abpAccessTokenRepository)
        {
            _objectMapper = objectMapper;
            _abpAccessTokenRepository = abpAccessTokenRepository;
        }


        /// <summary>根据应用Id获取当前token
        /// </summary>
        public async Task<AccessTokenModel> GetAccessTokenAsync(string appId)
        {
            var abpAccessToken = await _abpAccessTokenRepository.FirstOrDefaultAsync(x => x.AppId == appId);
            return _objectMapper.Map<AccessTokenModel>(abpAccessToken);
        }


        /// <summary>创建或者修改AccessToken
        /// </summary>
        public async Task CreateOrUpdateAccessTokenAsync(AccessTokenModel accessToken)
        {
            var abpAccessToken = await _abpAccessTokenRepository.FirstOrDefaultAsync(x => x.AppId == accessToken.AppId);
            if (abpAccessToken == null)
            {
                abpAccessToken = _objectMapper.Map<AbpAccessToken>(accessToken);
                await _abpAccessTokenRepository.InsertAsync(abpAccessToken);
            }
            else
            {
                abpAccessToken.Token = accessToken.Token;
                abpAccessToken.ExpiredIn = accessToken.ExpiredIn;
                abpAccessToken.LastModifiedTime = accessToken.LastModifiedTime;
            }
        }


    }
}
