using DotCommon.Caching;
using DotCommon.DependencyInjection;
using DotCommon.Json4Net;
using Microsoft.Extensions.DependencyInjection;
using System;


namespace WeChat.Framework.Tests
{
    public class TestBase
    {
        protected static IServiceProvider Provider { get; }
        static TestBase()
        {

            IServiceCollection services = new ServiceCollection();
            services.AddLogging(c =>
                {
                    // c.AddLog4Net();
                })
                .AddDotCommon()
                .AddGenericsMemoryCache()
                .AddJson4Net()
                .AddHttpClient()
                .AddWeChatFramework();

            Provider = services.BuildServiceProvider();
            Provider.ConfigureDotCommon();
        }
    }
}
