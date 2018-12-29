using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
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
        public static IServiceCollection AddWeChatFrameworkSqlServer(this IServiceCollection services, Action<WeChatSqlServerOption> option)
        {
            var weChatSqlServerOption = new WeChatSqlServerOption();
            option(weChatSqlServerOption);
            services.AddSingleton<WeChatSqlServerOption>(weChatSqlServerOption);

            services.AddTransient<IWeChatSdkTicketStore, SqlServerWeChatSdkTicketStore>();
            services.AddTransient<IWeChatAccessTokenStore, SqlServerWeChatAccessTokenStore>();
            return services;
        }
    }
}
