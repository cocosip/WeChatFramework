using Abp.Domain.Repositories;
using DotCommon.AutoMapper;
using System.Threading.Tasks;
using WeChat.Framework.Model;

namespace WeChat.Framework.Infrastructure.Store
{
    /// <summary>微信应用AccessToken存储 Abp扩展
    /// </summary>
    public class AbpWeChatAccessTokenStore : IWeChatAccessTokenStore
    {
        private readonly IRepository<AbpAccessToken> _abpAccessTokenRepository;

        /// <summary>Ctor
        /// </summary>
        public AbpWeChatAccessTokenStore(IRepository<AbpAccessToken> abpAccessTokenRepository)
        {
            _abpAccessTokenRepository = abpAccessTokenRepository;
        }


        /// <summary>根据应用Id获取当前token
        /// </summary>
        public async Task<AccessTokenModel> GetAccessTokenAsync(string appId)
        {
            var abpAccessToken = await _abpAccessTokenRepository.FirstOrDefaultAsync(x => x.AppId == appId);
            return abpAccessToken.MapTo<AccessTokenModel>();
        }


        /// <summary>创建或者修改AccessToken
        /// </summary>
        public async Task CreateOrUpdateAccessTokenAsync(AccessTokenModel accessToken)
        {
            var abpAccessToken = await _abpAccessTokenRepository.FirstOrDefaultAsync(x => x.AppId == accessToken.AppId);
            if (abpAccessToken == null)
            {
                abpAccessToken = accessToken.MapTo<AbpAccessToken>();
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
