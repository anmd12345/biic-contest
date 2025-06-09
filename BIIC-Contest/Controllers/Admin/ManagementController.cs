using System.Web.Mvc;

namespace BIIC_Contest.Controllers.Admin
{
    [RoutePrefix("quan-ly-he-thong")]
    public class ManagementController : Controller
    {
        [Route("")]
        public ActionResult SystemConfig()
        {
            return View();
        }

        [Route("nhat-ky-hoat-dong")]
        public ActionResult ActivityLog()
        {
            return View();
        }
    }
}