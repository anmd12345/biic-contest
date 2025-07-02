using BIIC_Contest.Services;
using System.Web.Mvc;
using BIIC_Contest.Constants;

namespace BIIC_Contest.Controllers
{
    public class BaseController : Controller
    {
        SystemService systemService = new SystemService();
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Session[SessionConstant.CURRENT_SYSTEM] = systemService.getSystemInfo();

            base.OnActionExecuting(filterContext);
        }
    }
}