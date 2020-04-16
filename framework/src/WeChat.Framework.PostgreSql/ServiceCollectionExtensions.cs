using Microsoft.Extensions.DependencyInjection;
using System;
using WeChat.Framework.Infrastructure.Store;

namespace WeChat.Framework
{

    /// <summary>Ioc扩展
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>添加微信基础服务PostgreSql扩展
        /// </summary>
        public static IServiceCollection AddWeChatFrameworkPostgreSql(this IServiceCollection services, Action<WeChatFrameworkPostgreSqlOption> configure)
        {
            services
                .Configure<WeChatFrameworkPostgreSqlOption>(configure)
                .AddTransient<IWeChatSdkTicketStore, PostgreSqlWeChatSdkTicketStore>()
                .AddTransient<IWeChatAccessTokenStore, PostgreSqlWeChatAccessTokenStore>();
            return services;
        }
    }
}
