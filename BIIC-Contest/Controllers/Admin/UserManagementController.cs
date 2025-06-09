using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BIIC_Contest.Controllers.Admin
{
    [RoutePrefix("quan-ly-nguoi-dung")]
    public class UserManagementController : Controller
    {
        [Route("")]
        public ActionResult ListUser()
        {
            return View();
        }
    }
}