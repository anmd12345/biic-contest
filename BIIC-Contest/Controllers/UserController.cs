using BIIC_Contest.Constants;
using Microsoft.Ajax.Utilities;
using System.Web.Mvc;

namespace BIIC_Contest.Controllers
{
    public class UserController : BaseController
    {
        // GET: User

        [Route("dang-nhap")]
        public ActionResult Login()
        {
            if(Session[SessionConstant.CURRENT_USER] != null)
            {
                return Redirect(RouteConstant.HOME_PAGE);
            }
            return View();
        }

        [Route("dang-ky")]
        public ActionResult Signup()
        {
            if (Session[SessionConstant.CURRENT_USER] != null)
            {
                return Redirect(RouteConstant.HOME_PAGE);
            }
            return View();
        }

        [Route("ho-so")]
        public ActionResult Profile()
        {
            if (Session[SessionConstant.CURRENT_USER] == null)
            {
                return Redirect(RouteConstant._404);
            }
            return View();
        }
    }
}