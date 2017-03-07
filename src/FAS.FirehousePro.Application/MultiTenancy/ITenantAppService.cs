using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using FAS.FirehousePro.MultiTenancy.Dto;

namespace FAS.FirehousePro.MultiTenancy
{
    public interface ITenantAppService : IApplicationService
    {
        ListResultDto<TenantListDto> GetTenants();

        Task CreateTenant(CreateTenantInput input);
    }
}
