using DotCommon.Extensions;
using DotCommon.Threading;
using Microsoft.Extensions.DependencyInjection;
using WeChat.Framework.Service;
using Xunit;

namespace WeChat.Framework.Tests.Service
{
    public class WeChatSdkTicketServiceTest : TestBase
    {
        [Fact]
        public void GetSdkTicketTest()
        {
            var wechatSdkTicketService = Provider.GetService<IWeChatSdkTicketService>();

            var sdkTicket = AsyncHelper.RunSync(() =>
            {
                return wechatSdkTicketService.GetSdkTicketAsync("wx4239531fdf3896e6", "db87e04f733f746fa15d4091d8ba9479", WeChatSettings.SdkTicketType.JsApi);
            });

            Assert.True(!sdkTicket.IsNullOrWhiteSpace());
        }
    }
}
