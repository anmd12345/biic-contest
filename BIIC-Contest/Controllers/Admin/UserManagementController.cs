using BIIC_Contest.Entitys;
using BIIC_Contest.Services;
using System.Web.Mvc;

namespace BIIC_Contest.Controllers.Admin
{
    [RoutePrefix("quan-ly-nguoi-dung")]
    public class UserManagementController : BaseAdminController
    {
        private UserService userService = new UserService();


        [Route("")]
        public ActionResult ListUser()
        {
            BasicResponseEntity reponse = userService.getUsers();

            ViewBag.users = reponse.Data;

            return View();
        }

        [Route("thong-tin-nguoi-dung/{id}")]
        public ActionResult UserInformation(int id)
        {
            return View();
        }
    }
}