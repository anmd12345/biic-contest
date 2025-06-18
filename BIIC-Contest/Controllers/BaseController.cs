using BIIC_Contest.Services;
using System.Web.Mvc;
using BIIC_Contest.Constants;

namespace BIIC_Contest.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            SystemService systemService = new SystemService();

            Session[SessionConstant.CURRENT_SYSTEM] = systemService.getSystemInfo();

            base.OnActionExecuting(filterContext);
        }
    }
}