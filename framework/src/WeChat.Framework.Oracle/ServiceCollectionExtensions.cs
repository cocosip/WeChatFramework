using Microsoft.Extensions.DependencyInjection;
using System;
using WeChat.Framework.Infrastructure.Store;

namespace WeChat.Framework
{

    /// <summary>Ioc扩展
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>添加微信基础服务Oracle扩展
        /// </summary>
        public static IServiceCollection AddWeChatFrameworkOracle(this IServiceCollection services, Action<WeChatFrameworkOracleOption> configure)
        {
            var weChatFrameworkSqlServerOption = new WeChatFrameworkOracleOption();
            configure(weChatFrameworkSqlServerOption);
            services
                .AddSingleton<WeChatFrameworkOracleOption>(weChatFrameworkSqlServerOption)
                .AddTransient<IWeChatSdkTicketStore, OracleWeChatSdkTicketStore>()
                .AddTransient<IWeChatAccessTokenStore, OracleWeChatAccessTokenStore>();
            return services;
        }
    }
}
