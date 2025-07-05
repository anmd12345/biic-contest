using System.Web.Mvc;

namespace BIIC_Contest.Controllers.Admin
{
    [RoutePrefix("quan-ly-nguoi-dung")]
    public class UserManagementController : BaseAdminController
    {
        [Route("")]
        public ActionResult ListUser()
        {
            return View();
        }

        [Route("thong-tin-nguoi-dung")]
        public ActionResult UserInformation()
        {
            return View();
        }
    }
}