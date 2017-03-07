using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FAS.FirehousePro.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : FirehouseProControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}