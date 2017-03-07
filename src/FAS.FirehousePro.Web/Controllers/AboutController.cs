using Microsoft.AspNetCore.Mvc;

namespace FAS.FirehousePro.Web.Controllers
{
    public class AboutController : FirehouseProControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}