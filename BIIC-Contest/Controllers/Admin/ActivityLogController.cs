using BIIC_Contest.Services;
using System.Web.Mvc;

namespace BIIC_Contest.Controllers.Admin
{
    public class ActivityLogController : BaseAdminController
    {
        ActivityLogService activityLogService = new ActivityLogService();

        [Route("nhat-ky-hoat-dong")]
        public ActionResult ActivityLog()
        {
            var logs = activityLogService.getAllActivityLog();

            ViewBag.logs = logs;

            return View();
        }
    }
}