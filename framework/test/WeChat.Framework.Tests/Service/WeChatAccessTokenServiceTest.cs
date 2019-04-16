using DotCommon.Extensions;
using DotCommon.Threading;
using Microsoft.Extensions.DependencyInjection;
using WeChat.Framework.Service;
using Xunit;

namespace WeChat.Framework.Tests.Service
{
    public class WeChatAccessTokenServiceTest : TestBase
    {


        [Fact]
        public void GetAccessTokenTest()
        {
            var weChatAccessTokenService = Provider.GetService<IWeChatAccessTokenService>();

            var accessToken = AsyncHelper.RunSync(() =>
            {
                return weChatAccessTokenService.GetAccessTokenAsync("wx4239531fdf3896e6", "db87e04f733f746fa15d4091d8ba9479");
            });

            Assert.True(!accessToken.IsNullOrWhiteSpace());
        }

    }
}
