using Microsoft.Extensions.DependencyInjection;
using WeChat.Framework.Infrastructure.Store;

namespace WeChat.Framework
{
    /// <summary>依赖注入扩展
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>添加WeChatFramework Abp扩展
        /// </summary>
        public static IServiceCollection AddWeChatFrameworkAbp(this IServiceCollection services)
        {
            services.AddTransient<IWeChatAccessTokenStore, AbpWeChatAccessTokenStore>();
            services.AddTransient<IWeChatSdkTicketStore, AbpWeChatSdkTicketStore>();
            return services;
        }
    }
}
