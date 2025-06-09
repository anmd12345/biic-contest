using BIIC_Contest.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BIIC_Contest.Controllers
{
    public class HomeController : Controller
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