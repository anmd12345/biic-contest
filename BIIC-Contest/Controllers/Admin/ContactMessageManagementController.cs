using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BIIC_Contest.Controllers.Admin
{
    [RoutePrefix("quan-ly-tin-nhan")]
    public class ContactMessageManagementController : Controller
    {
        [Route("danh-sach-tin-nhan")]
        public ActionResult ListContactMessage()
        {
            return View();
        }

        [Route("tin-nhan-chi-tiet")]
        public ActionResult ContactMessageDetail()
        {
            return View();
        }
    }
}