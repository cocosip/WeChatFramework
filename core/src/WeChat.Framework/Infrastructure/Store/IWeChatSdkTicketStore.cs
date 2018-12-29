using System.Threading.Tasks;
using WeChat.Framework.Model;

namespace WeChat.Framework.Infrastructure.Store
{
    /// <summary>微信Sdk-Ticket存储
    /// </summary>
    public interface IWeChatSdkTicketStore
    {
        /// <summary>根据应用Id,ticket类型获取Sdk-Ticket
        /// </summary>
        Task<SdkTicketModel> GetSdkTicketAsync(string appId, string ticketType);

        /// <summary>创建或者修改Sdk-Ticket
        /// </summary>
        Task CreateOrUpdateSdkTicketAsync(SdkTicketModel sdkTicket);
    }
}
