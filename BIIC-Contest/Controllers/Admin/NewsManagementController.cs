using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BIIC_Contest.Controllers.Admin
{
    public class NewsManagementController : BaseAdminController
    {
        [Route("tao-bai-viet-moi")]
        public ActionResult CreateNews()
        {
            return View();
        }

        [Route("danh-sach-bai-viet")]
        public ActionResult ListNews()
        {
            return View();
        }
    }
}