using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BIIC_Contest.Controllers.Admin
{
    public class ContestManagementController : BaseAdminController
    {

        [Route("tao-cuoc-thi")]
        public ActionResult CreateContest()
        {
            return View();
        }


        [Route("danh-sach-cuoc-thi")]
        public ActionResult ListContest()
        {
            return View();
        }
    }
}