using System.Web.Mvc;
using LocalOnlyAccessTest.Authorization;

namespace LocalOnlyAccessTest.Controllers
{
    [LocalOnlyAuthorization]
    public class YoMamaController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}