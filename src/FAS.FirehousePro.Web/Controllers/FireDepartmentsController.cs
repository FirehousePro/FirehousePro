using Abp.AspNetCore.Mvc.Authorization;
using FAS.FirehousePro.Application.FireDepartments;
using FAS.FirehousePro.Authorization;
using FAS.FirehousePro.MultiTenancy;
using Microsoft.AspNetCore.Mvc;

namespace FAS.FirehousePro.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Tenants)]
    public class FireDepartmentsController : FirehouseProControllerBase
    {
        private readonly IFireDepartmentAppService _fireDepartmentAppService;

        public FireDepartmentsController(IFireDepartmentAppService fireDepartmentAppService)
        {
            _fireDepartmentAppService = fireDepartmentAppService;
        }

        public ActionResult Index()
        {
            var output = _fireDepartmentAppService.GetFireDepartments();
            return View(output);
        }
    }
}