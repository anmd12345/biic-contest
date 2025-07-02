using BIIC_Contest.Services;
using System.Web.Mvc;

namespace BIIC_Contest.Controllers.Admin
{
    public class DashboardController : BaseAdminController
    {
        [Route("bang-dieu-khien")]
        public ActionResult Dashboard()
        {
            SystemService systemService = new SystemService();
            var systemInfo = systemService.getSystemInfo();

            ViewBag.systemInfo = systemInfo;
            return View();
        }
    }
}