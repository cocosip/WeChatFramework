using Abp.Domain.Repositories;
using DotCommon.AutoMapper;
using System.Threading.Tasks;
using WeChat.Framework.Model;

namespace WeChat.Framework.Infrastructure.Store
{

    /// <summary>微信Sdk-Ticket存储 Abp扩展
    /// </summary>
    public class AbpWeChatSdkTicketStore : IWeChatSdkTicketStore
    {
        private readonly IRepository<AbpSdkTicket> _abpSdkTicketRepository;

        /// <summary>Ctor
        /// </summary>
        public AbpWeChatSdkTicketStore(IRepository<AbpSdkTicket> abpSdkTicketRepository)
        {
            _abpSdkTicketRepository = abpSdkTicketRepository;
        }


        /// <summary>根据应用Id,ticket类型获取Sdk-Ticket
        /// </summary>
        /// <param name="appId">应用AppId</param>
        /// <param name="ticketType">Ticket类型</param>
        /// <returns></returns>
        public async Task<SdkTicketModel> GetSdkTicketAsync(string appId, string ticketType)
        {
            var abpSdkTicket = await _abpSdkTicketRepository.FirstOrDefaultAsync(x => x.AppId == appId && x.TicketType == ticketType);
            return abpSdkTicket.MapTo<SdkTicketModel>();
        }


        /// <summary>创建或者修改Sdk-Ticket
        /// </summary>
        public async Task CreateOrUpdateSdkTicketAsync(SdkTicketModel sdkTicket)
        {
            var abpSdkTicket = await _abpSdkTicketRepository.FirstOrDefaultAsync(x => x.AppId == sdkTicket.AppId && x.TicketType == sdkTicket.TicketType);
            if (abpSdkTicket == null)
            {
                abpSdkTicket = sdkTicket.MapTo<AbpSdkTicket>();
                await _abpSdkTicketRepository.InsertAsync(abpSdkTicket);
            }
            else
            {
                abpSdkTicket.Ticket = sdkTicket.Ticket;
                abpSdkTicket.ExpiredIn = sdkTicket.ExpiredIn;
                abpSdkTicket.LastModifiedTime = sdkTicket.LastModifiedTime;
            }
        }


    }
}
