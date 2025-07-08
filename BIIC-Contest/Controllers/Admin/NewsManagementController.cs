using BIIC_Contest.Dtos;
using BIIC_Contest.Entitys;
using BIIC_Contest.Services;
using BIIC_Contest.Services.I;
using System.Web.Mvc;

namespace BIIC_Contest.Controllers.Admin
{
    public class NewsManagementController : BaseAdminController
    {
        private CategoryService categoryService = new CategoryService();
        private NewsService newsService = new NewsService();

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


        [HttpGet]
        [Route("chinh-sua-bai-viet/{id}")]
        public ActionResult Edit(int id)
        {
            var response = newsService.getNewsById(id);
            if (!response.Success)
            {
                return RedirectToAction("Index", "News");
            }

            ViewBag.news = response.Data as NewsDto;
            ViewBag.isEdit = true;
            ViewBag.categories = categoryService.getAll().Data;

            return View("CreateNews");

        }

    }
}