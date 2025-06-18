using BIIC_Contest.Constants;
using System.Web.Mvc;

namespace BIIC_Contest.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return Redirect(RouteConstant.HOME_PAGE);
        }

        [Route("trang-chu")]
        public ActionResult Home()
        {
            return View();
        }

        [Route("lien-he")]
        public ActionResult Contact()
        {
            return View();
        }
    }
}