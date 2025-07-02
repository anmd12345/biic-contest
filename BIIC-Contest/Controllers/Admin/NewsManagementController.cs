using BIIC_Contest.Entitys;
using BIIC_Contest.Services;
using System.Web.Mvc;

namespace BIIC_Contest.Controllers.Admin
{
    public class NewsManagementController : BaseAdminController
    {
        private CategoryService categoryService = new CategoryService();

        [Route("tao-bai-viet-moi")]
        public ActionResult CreateNews()
        {
            BasicResponseEntity categories = categoryService.getAll();

            ViewBag.categories = categories.Data;
            return View();
        }

        [Route("danh-sach-bai-viet")]
        public ActionResult ListNews()
        {
            return View();
        }
    }
}