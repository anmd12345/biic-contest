using BIIC_Contest.Entitys;
using BIIC_Contest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BIIC_Contest.Controllers.Admin
{
    public class CategoryManagementController : BaseAdminController
    {
        private CategoryService categoryService = new CategoryService();

        [Route("danh-sach-danh-muc")]
        public ActionResult ListCategory()
        {
            BasicResponseEntity categories = categoryService.getAll();

            ViewBag.categories = categories.Data;
            return View();
        }
    }
}