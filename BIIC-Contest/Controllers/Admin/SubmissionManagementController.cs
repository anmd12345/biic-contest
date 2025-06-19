using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BIIC_Contest.Controllers.Admin
{
    public class SubmissionManagementController : Controller
    {
        [Route("danh-sach-bai-du-thi")]
        public ActionResult ListSubmission()
        {
            return View();
        }


        [Route("chi-tiet-bai-du-thi-v2")]
        public ActionResult SubmissionDetail()
        {
            return View();
        }

    }
}