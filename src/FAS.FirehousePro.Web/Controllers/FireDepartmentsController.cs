using Abp.AspNetCore.Mvc.Authorization;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using FAS.FirehousePro.Application.Commons.Dto;
using FAS.FirehousePro.Application.FireDepartments;
using FAS.FirehousePro.Application.FireDepartments.Dto;
using FAS.FirehousePro.Authorization;
using FAS.FirehousePro.MultiTenancy;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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

        public async Task<ActionResult> Index()
        {
            var output = await _fireDepartmentAppService.GetFireDepartments();
            return View(output);
        }

        public ActionResult Create()
        {
            var input = new CreateFireDepartmentInput();
            input.Address = new CreateAddressInput();
            return View(input);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateFireDepartmentInput input)
        {
            await _fireDepartmentAppService.CreateFireDepartment(input);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Edit(int id)
        {
            var fireDept = await _fireDepartmentAppService.GetFireDepartment(id);
            var input = fireDept.MapTo<UpdateFireDepartmentInput>();

            return View(input);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(UpdateFireDepartmentInput input)
        {
            await _fireDepartmentAppService.UpdateFireDepartment(input);
            return RedirectToAction("Index");
        }
    }
}