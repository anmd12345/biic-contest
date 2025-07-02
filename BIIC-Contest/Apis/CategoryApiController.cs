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
    }
}