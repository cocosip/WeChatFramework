using Microsoft.Extensions.DependencyInjection;
using WeChat.Framework.Infrastructure.Store;
using WeChat.Framework.Parser;
using WeChat.Framework.Service;

namespace WeChat.Framework
{
    /// <summary>Ioc注入
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>使用微信基础框架
        /// </summary>
        public static IServiceCollection AddWeChatFramework(this IServiceCollection services)
        {
            //Json结果格式化
            services
                .AddTransient<IJsonResponseParser, JsonResponseParser>()
                .AddTransient<IWeChatAccessTokenStore, MemoryWeChatAccessTokenStore>()
                .AddTransient<IWeChatSdkTicketStore, MemoryWeChatSdkTicketStore>()
                .AddTransient<IWeChatAccessTokenService, WeChatAccessTokenService>()
                .AddTransient<IWeChatSdkTicketService, WeChatSdkTicketService>();

            return services;
        }
    }
}
