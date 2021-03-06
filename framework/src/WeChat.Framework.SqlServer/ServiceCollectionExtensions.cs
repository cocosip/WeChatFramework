using Microsoft.Extensions.DependencyInjection;
using System;
using WeChat.Framework.Infrastructure.Store;

namespace WeChat.Framework
{

    /// <summary>Ioc扩展
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>添加微信基础服务SqlServer扩展
        /// </summary>
        public static IServiceCollection AddWeChatFrameworkSqlServer(this IServiceCollection services, Action<WeChatFrameworkSqlServerOption> configure)
        {
            services
                .Configure<WeChatFrameworkSqlServerOption>(configure)
                .AddTransient<IWeChatSdkTicketStore, SqlServerWeChatSdkTicketStore>()
                .AddTransient<IWeChatAccessTokenStore, SqlServerWeChatAccessTokenStore>();
            return services;
        }
    }
}
