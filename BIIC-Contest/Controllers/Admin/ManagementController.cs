using System.Web.Mvc;

namespace BIIC_Contest.Controllers.Admin
{
    [RoutePrefix("quan-ly-he-thong")]
    public class ManagementController : Controller
    {
        [Route("cai-dat-thong-tin")]
        public ActionResult SystemConfig()
        {
            return View();
        }

        [Route("hoat-dong")]
        public ActionResult ActivityLog()
        {
            return View();
        }

        [Route("quan-ly-nguoi-dung")]
        public ActionResult UserManagement()
        {
            return View();
        }
    }
}