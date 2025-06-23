using BIIC_Contest.Services;
using System.Web.Mvc;

namespace BIIC_Contest.Controllers.Admin
{
    [RoutePrefix("quan-ly-he-thong")]
    public class ManagementController : BaseController
    {
        private ActivityLogService activityLogService = new ActivityLogService();


        [Route("")]
        public ActionResult SystemConfig()
        {
            return View();
        }

        [Route("nhat-ky-hoat-dong")]
        public ActionResult ActivityLog()
        {
            var logs = activityLogService.getAllActivityLog();

            ViewBag.logs = logs;

            return View();
        }
    }
}