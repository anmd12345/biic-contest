using BIIC_Contest.Constants;
using BIIC_Contest.Dtos;
using BIIC_Contest.Entitys;
using BIIC_Contest.Models;
using BIIC_Contest.Services;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;


namespace BIIC_Contest.Apis
{
    [RoutePrefix("apis/v1/news")]
    public class NewsApiController : Controller
    {
        private NewsService newsService = new NewsService();

        // Lấy tất cả bài viết
        //[HttpGet]
        //[Route("list")]
        //public JsonResult ListNews()
        //{
        //    var response = newsService.getAllNews();
        //    return Json(response, JsonRequestBehavior.AllowGet);  // Sử dụng JsonRequestBehavior.AllowGet để cho phép GET
        //}

        [HttpGet]
        [Route("list")]
        public JsonResult ListNews(int page = 1, int pageSize = 5)
        {
            var response = newsService.getAllNews(); // Trả về BasicResponseEntity

            if (!response.Success)
            {
                return Json(new
                {
                    Success = false,
                    Message = response.Message
                }, JsonRequestBehavior.AllowGet);
            }

            var allNews = response.Data as List<tbl_new>;

            var pagedNews = allNews
                .OrderByDescending(n => n.created_at)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(n => new
                {
                    n.news_id,
                    n.title,
                    n.created_at,
                    n.status,
                    n.view,
                    n.like,
                    n.share,
                    n.is_priority
                })
                .ToList();

            return Json(new
            {
                Success = true,
                Message = "Lấy danh sách thành công!",
                TotalRecords = allNews.Count,
                Data = pagedNews
            }, JsonRequestBehavior.AllowGet);
        }




        // Tạo bài viết mới
        [HttpPost]
        [Route("create")]
        public JsonResult CreateNews(string title, string content, short categoryId, string bannerUrl, bool isPriority, short status)
        {

            // Lấy thông tin người dùng từ session
            var user = Session[SessionConstant.CURRENT_USER] as UserDto;

            if (user == null)
            {
                return Json(new BasicResponseEntity
                {
                    Success = false,
                    Message = "Bạn chưa đăng nhập",
                    Data = null
                });
            }

            var response = newsService.createNews(new NewsDto
            {
                Title = title,
                Content = content,
                CategoryId = categoryId,
                BannerUrl = bannerUrl,
                UserId = user.UserId,
                Status = status,
                IsPriority = isPriority

            });
            return Json(response);
        }

        // Cập nhật bài viết
        [HttpPost]
        [Route("update")]
        public JsonResult UpdateNews(int id, string title, string content, short categoryId, string bannerUrl, short status)
        {

            // Lấy thông tin người dùng từ session
            var user = Session[SessionConstant.CURRENT_USER] as UserDto;

            if (user == null)
            {
                return Json(new BasicResponseEntity
                {
                    Success = false,
                    Message = "Bạn chưa đăng nhập",
                    Data = null
                });
            }

            var response = newsService.updateNews(new NewsDto
            {
                NewsId = id,
                Title = title,
                Content = content,
                CategoryId = categoryId,
                BannerUrl = bannerUrl,
                Status = status,
                
            });
            return Json(response);
        }

        // Xóa bài viết
        [HttpPost]
        [Route("delete")]
        public JsonResult DeleteNews(int id)
        {
            var response = newsService.deleteNews(id);
            return Json(response);
        }
    }
}
