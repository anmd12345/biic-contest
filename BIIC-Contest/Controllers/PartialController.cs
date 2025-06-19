using System.Web.Mvc;

namespace BIIC_Contest.Controllers
{
    public class PartialController : BaseController
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

        public ActionResult FaviconPartial()
        {
            return PartialView();
        }
    }
}