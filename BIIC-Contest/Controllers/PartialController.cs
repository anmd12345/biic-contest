using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BIIC_Contest.Controllers
{
    public class PartialController : Controller
    {
        public ActionResult NavbarPartial()
        {
            return PartialView();
        }

        public ActionResult SupportChatPartial()
        {
            return PartialView();
        }

        public ActionResult SettingCanvasPartial()
        {
            return PartialView();
        }

        public ActionResult SearchModalPartial()
        {
            return PartialView();
        }


        public ActionResult Footer1Partial()
        {
            return PartialView();
        }

        public ActionResult Footer2Partial()
        {
            return PartialView();
        }
    }
}