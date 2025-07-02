using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BIIC_Contest.Controllers
{
    public class RegisterContestController : Controller
    {
        [Route("dang-ky-cuoc-thi")]
        public ActionResult RegisterContest()
        {
            return View();
        }
    }
}