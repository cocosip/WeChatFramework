using DotCommon.Caching;
using System.Threading.Tasks;
using WeChat.Framework.Model;

namespace WeChat.Framework.Infrastructure.Store
{
    /// <summary>空的微信Sdk-Ticket存储
    /// </summary>
    public class MemoryWeChatSdkTicketStore : IWeChatSdkTicketStore
    {
        private readonly IDistributedCache<SdkTicketModel> _sdkTicketCache;

        /// <summary>Ctor
        /// </summary>
        public MemoryWeChatSdkTicketStore(IDistributedCache<SdkTicketModel> sdkTicketCache)
        {
            _sdkTicketCache = sdkTicketCache;
        }

        /// <summary>根据应用Id获取Sdk-Ticket
        /// </summary>
        public async Task<SdkTicketModel> GetSdkTicketAsync(string appId, string ticketType)
        {
            var sdkTicket = await _sdkTicketCache.GetAsync($"{appId}-{ticketType}");
            return sdkTicket;
        }

        /// <summary>创建或者修改Sdk-Ticket
        /// </summary>
        public async Task CreateOrUpdateSdkTicketAsync(SdkTicketModel sdkTicket)
        {
            await _sdkTicketCache.SetAsync($"{sdkTicket.AppId}-{sdkTicket.TicketType}", sdkTicket);
        }

    }
}
