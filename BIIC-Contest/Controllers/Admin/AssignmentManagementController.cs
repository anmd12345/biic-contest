using System.Web.Mvc;

namespace BIIC_Contest.Controllers.Admin
{
    public class AssignmentManagementController : BaseAdminController
    {
        [Route("danh-sach-cong-viec")]
        public ActionResult ListAssignment()
        {
            return View();
        }
    }
}