using Microsoft.Extensions.DependencyInjection;
using System;
using WeChat.Framework.Infrastructure.Store;

namespace WeChat.Framework
{

    /// <summary>Ioc扩展
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>添加微信基础服务MySql扩展
        /// </summary>
        public static IServiceCollection AddWeChatFrameworkMySql(this IServiceCollection services, Action<WeChatFrameworkMySqlOption> configure)
        {
            var weChatFrameworkSqlServerOption = new WeChatFrameworkMySqlOption();
            configure(weChatFrameworkSqlServerOption);
            services
                .AddSingleton<WeChatFrameworkMySqlOption>(weChatFrameworkSqlServerOption)
                .AddTransient<IWeChatSdkTicketStore, MySqlWeChatSdkTicketStore>()
                .AddTransient<IWeChatAccessTokenStore, MySqlWeChatAccessTokenStore>();
            return services;
        }
    }
}
