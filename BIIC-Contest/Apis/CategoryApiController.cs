using BIIC_Contest.Entitys;
using BIIC_Contest.Services;
using System.Web.Mvc;

namespace BIIC_Contest.Apis
{
    [RoutePrefix("apis/v1/category")]
    public class CategoryApiController : Controller
    {
        private CategoryService categoryService = new CategoryService();

        [Route("list")]
        [HttpGet]
        public JsonResult ListCategory()
        {
            BasicResponseEntity categoriesResponse = categoryService.getAll();

            return Json(categoriesResponse, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("create")]
        public JsonResult CreateCategory(string categoryName, string description)
        {
            BasicResponseEntity response = categoryService.insert(categoryName, description);
            return Json(response);
        }


        [HttpPost]
        [Route("update")]
        public JsonResult UpdateCategory(short id, string categoryName, string description)
        {
            BasicResponseEntity response = categoryService.update(id, categoryName, description);
            return Json(response);
        }

        [HttpPost]
        [Route("delete")]
        public JsonResult DeleteCategory(short id)
        {
            BasicResponseEntity response = categoryService.delete(id);
            return Json(response);
        }
    }
}