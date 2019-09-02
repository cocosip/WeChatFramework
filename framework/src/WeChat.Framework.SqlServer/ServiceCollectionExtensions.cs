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
            var weChatFrameworkSqlServerOption = new WeChatFrameworkSqlServerOption();
            configure(weChatFrameworkSqlServerOption);
            services.AddSingleton<WeChatFrameworkSqlServerOption>(weChatFrameworkSqlServerOption);

            services.AddTransient<IWeChatSdkTicketStore, SqlServerWeChatSdkTicketStore>();
            services.AddTransient<IWeChatAccessTokenStore, SqlServerWeChatAccessTokenStore>();
            return services;
        }
    }
}
