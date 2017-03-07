using System.Threading.Tasks;
using Abp.Application.Services;
using FAS.FirehousePro.Roles.Dto;

namespace FAS.FirehousePro.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
