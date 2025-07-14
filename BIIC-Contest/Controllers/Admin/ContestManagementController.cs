using BIIC_Contest.Dtos;
using BIIC_Contest.Services;
using BIIC_Contest.Services.I;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BIIC_Contest.Controllers.Admin
{
    public class ContestManagementController : BaseAdminController
    {
        private readonly ContestService contestService = new ContestService();
        private NewsService newsService = new NewsService();

        [Route("tao-cuoc-thi")]
        public ActionResult CreateContest()
        {
            return View();
        }


        [Route("danh-sach-cuoc-thi")]
        public ActionResult ListContest()
        {

            
            var response = contestService.getAllContests();

            if (response.Success && response.Data is List<NewsDto> contests)
            {
                ViewBag.Contests = contests;
            }
            else
            {
                ViewBag.Contests = new List<NewsDto>();
            }

            return View();
        }


        [HttpGet]
        [Route("chinh-sua-cuoc-thi/{id}")]
        public ActionResult Edit(int id)
        {
            var response = newsService.getContestById(id); // dùng method mới
            if (!response.Success)
            {
                return RedirectToAction("Index", "Contest"); // hoặc về danh sách cuộc thi
            }

            ViewBag.news = response.Data as NewsDto;
            ViewBag.isEdit = true;
            ViewBag.contestCategoryId = 3;

            return View("CreateContest"); // dùng lại view CreateContest
        }




    }
}