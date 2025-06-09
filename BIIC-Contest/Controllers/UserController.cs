using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BIIC_Contest.Controllers
{
    public class UserController : Controller
    {
        // GET: User

        [Route("dang-nhap")]
        public ActionResult Login()
        {
            return View();
        }

        [Route("dang-ky")]
        public ActionResult Signup()
        {
            return View();
        }
    }
}