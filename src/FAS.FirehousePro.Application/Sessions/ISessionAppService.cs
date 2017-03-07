using System.Threading.Tasks;
using Abp.Application.Services;
using FAS.FirehousePro.Sessions.Dto;

namespace FAS.FirehousePro.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
