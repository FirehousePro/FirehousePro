using Abp.AspNetCore.Mvc.Authorization;
using FAS.FirehousePro.Authorization;
using FAS.FirehousePro.MultiTenancy;
using Microsoft.AspNetCore.Mvc;

namespace FAS.FirehousePro.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Tenants)]
    public class TenantsController : FirehouseProControllerBase
    {
        private readonly ITenantAppService _tenantAppService;

        public TenantsController(ITenantAppService tenantAppService)
        {
            _tenantAppService = tenantAppService;
        }

        public ActionResult Index()
        {
            var output = _tenantAppService.GetTenants();
            return View(output);
        }
    }
}