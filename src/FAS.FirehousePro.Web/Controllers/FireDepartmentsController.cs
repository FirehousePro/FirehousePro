using Abp.AspNetCore.Mvc.Authorization;
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
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateFireDepartmentInput input)
        {
            if (ModelState.IsValid)
            {
                await _fireDepartmentAppService.CreateFireDepartment(input);
                return RedirectToAction("Index");
            }

            return View(input);
        }

        public ActionResult Edit(int id)
        {
            var output = _fireDepartmentAppService.GetFireDepartments();
            return View(output);
        }

        [HttpPost]
        public ActionResult Edit(UpdateFireDepartmentInput input)
        {
            var output = _fireDepartmentAppService.GetFireDepartments();
            return View(output);
        }
    }
}