using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using FAS.FirehousePro.Authorization;
using FAS.FirehousePro.Users;
using Microsoft.AspNetCore.Mvc;

namespace FAS.FirehousePro.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Users)]
    public class UsersController : FirehouseProControllerBase
    {
        private readonly IUserAppService _userAppService;

        public UsersController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        public async Task<ActionResult> Index()
        {
            var output = await _userAppService.GetUsers();
            return View(output);
        }
    }
}