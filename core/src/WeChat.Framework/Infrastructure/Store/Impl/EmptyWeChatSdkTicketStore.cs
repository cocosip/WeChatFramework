using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using WeChat.Framework.Model;

namespace WeChat.Framework.Infrastructure.Store
{
    /// <summary>空的微信Sdk-Ticket存储
    /// </summary>
    public class EmptyWeChatSdkTicketStore : IWeChatSdkTicketStore
    {
        private readonly ILogger _logger;
        /// <summary>Ctor
        /// </summary>
        public EmptyWeChatSdkTicketStore(ILogger logger)
        {
            _logger = logger;
        }

        /// <summary>根据应用Id获取Sdk-Ticket
        /// </summary>
        public Task<SdkTicketModel> GetSdkTicketAsync(string appId, string ticketType)
        {
            _logger.LogWarning($"未实现方法:EmptyWeChatSdkTicketStore.GetSdkTicketAsync");
            return Task.FromResult<SdkTicketModel>(null);
        }

        /// <summary>创建或者修改Sdk-Ticket
        /// </summary>
        public Task CreateOrUpdateSdkTicketAsync(SdkTicketModel sdkTicket)
        {
            _logger.LogWarning($"未实现方法:EmptyWeChatSdkTicketStore.CreateOrUpdateSdkTicketAsync");
            return Task.FromResult(0);
        }

    }
}
