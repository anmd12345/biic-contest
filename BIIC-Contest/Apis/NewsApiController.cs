using BIIC_Contest.Constants;
using BIIC_Contest.Dtos;
using BIIC_Contest.Entitys;
using BIIC_Contest.Models;
using BIIC_Contest.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;


namespace BIIC_Contest.Apis
{
    [RoutePrefix("apis/v1/news")]
    public class NewsApiController : Controller
    {
        private NewsService newsService = new NewsService();

        //[HttpGet]
        //[Route("list")]
        //public JsonResult ListNews(int page = 1, int pageSize = 5)
        //{
        //    var response = newsService.getAllNews(); // Trả về BasicResponseEntity

        //    if (!response.Success)
        //    {
        //        return Json(new
        //        {
        //            Success = false,
        //            Message = response.Message
        //        }, JsonRequestBehavior.AllowGet);
        //    }

        //    var allNews = response.Data as List<tbl_new>;

        //    var pagedNews = allNews
        //        .OrderByDescending(n => n.created_at)
        //        .Skip((page - 1) * pageSize)
        //        .Take(pageSize)
        //        .Select(n => new
        //        {
        //            n.news_id,
        //            n.title,
        //            n.created_at,
        //            n.status,
        //            n.view,
        //            n.like,
        //            n.share,
        //            n.is_priority
        //        })
        //        .ToList();

        //    return Json(new
        //    {
        //        Success = true,
        //        Message = "Lấy danh sách thành công!",
        //        TotalRecords = allNews.Count,
        //        Data = pagedNews
        //    }, JsonRequestBehavior.AllowGet);
        //}




        // Tạo bài viết mới

        [HttpGet]
        [Route("list")]
        public JsonResult ListNews(int page = 1, int pageSize = 5, string sortBy = "created_at", string sortDir = "desc", int? categoryId = null)
        {
            var response = newsService.getAllNews();

            if (!response.Success)
            {
                return Json(new
                {
                    Success = false,
                    Message = response.Message
                }, JsonRequestBehavior.AllowGet);
            }

            var allNews = response.Data as List<tbl_new>;

            // ⚠️ Lọc theo category nếu có
            if (categoryId.HasValue)
            {
                allNews = allNews.Where(n => n.category_id == categoryId.Value).ToList();
            }

            // Sắp xếp động
            switch (sortBy)
            {
                case "title":
                    allNews = sortDir == "asc" ? allNews.OrderBy(n => n.title).ToList() : allNews.OrderByDescending(n => n.title).ToList();
                    break;
                case "status":
                    allNews = sortDir == "asc" ? allNews.OrderBy(n => n.status).ToList() : allNews.OrderByDescending(n => n.status).ToList();
                    break;
                case "view":
                    allNews = sortDir == "asc" ? allNews.OrderBy(n => n.view).ToList() : allNews.OrderByDescending(n => n.view).ToList();
                    break;
                case "like":
                    allNews = sortDir == "asc" ? allNews.OrderBy(n => n.like).ToList() : allNews.OrderByDescending(n => n.like).ToList();
                    break;
                case "share":
                    allNews = sortDir == "asc" ? allNews.OrderBy(n => n.share).ToList() : allNews.OrderByDescending(n => n.share).ToList();
                    break;
                default:
                    allNews = sortDir == "asc" ? allNews.OrderBy(n => n.created_at).ToList() : allNews.OrderByDescending(n => n.created_at).ToList();
                    break;
            }

            var pagedNews = allNews
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


        [HttpPost]
        [Route("create")]
        [ValidateInput(false)]
        public JsonResult CreateNews()
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

            try
            {
                var request = this.HttpContext.Request;


                string title = request.Form["Title"];
                string content = request.Form["Content"];
                short categoryId = short.Parse(request.Form["CategoryId"]);
                bool isPriority = bool.Parse(request.Form["IsPriority"]);
                short status = short.Parse(request.Form["Status"]);

                string bannerPath = "";

                var file = request.Files["Banner"];
                if (file != null && file.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(file.FileName);
                    string relativePath = "/assets/img/event/" + fileName;
                    string physicalPath = Server.MapPath("~" + relativePath);

                    // Đảm bảo thư mục tồn tại
                    string directory = Path.GetDirectoryName(physicalPath);
                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    file.SaveAs(physicalPath);
                    bannerPath = relativePath;
                }

                var newsDto = new NewsDto
                {
                    Title = title,
                    Content = content,
                    CategoryId = categoryId,
                    BannerUrl = bannerPath,
                    UserId = user.UserId,
                    Status = status,
                    IsPriority = isPriority
                };

                var response = newsService.createNews(newsDto);
                return Json(response);
            }
            catch (Exception ex)
            {
                return Json(new BasicResponseEntity
                {
                    Success = false,
                    Message = "Đã xảy ra lỗi khi tạo bài viết: " + ex.Message,
                    Data = null
                });
            }
        }


        [HttpPost]
        [Route("update")]
        [ValidateInput(false)]
        public JsonResult UpdateNews()
        {
            var user = Session[SessionConstant.CURRENT_USER] as UserDto;
            if (user == null)
            {
                return Json(new BasicResponseEntity(false, "Bạn chưa đăng nhập"));
            }

            var request = this.HttpContext.Request;

            try
            {
                int newsId = int.Parse(request.Form["NewsId"]);
                string title = request.Form["Title"];
                string content = request.Form["Content"];
                short categoryId = short.Parse(request.Form["CategoryId"]);
                bool isPriority = bool.Parse(request.Form["IsPriority"]);
                short status = short.Parse(request.Form["Status"]);

                string bannerPath = null;
                var file = request.Files["Banner"];
                if (file != null && file.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(file.FileName);
                    string relativePath = "/assets/img/event/" + fileName;
                    string physicalPath = Server.MapPath("~" + relativePath);

                    if (!Directory.Exists(Path.GetDirectoryName(physicalPath)))
                        Directory.CreateDirectory(Path.GetDirectoryName(physicalPath));

                    file.SaveAs(physicalPath);
                    bannerPath = relativePath;
                }

                var dto = new NewsDto
                {
                    NewsId = newsId,
                    Title = title,
                    Content = content,
                    CategoryId = categoryId,
                    BannerUrl = bannerPath, // có thể null nếu không chọn lại ảnh
                    Status = status,
                    IsPriority = isPriority
                };

                var response = newsService.updateNews(dto);
                return Json(response);
            }
            catch (Exception ex)
            {
                return Json(new BasicResponseEntity(false, "Lỗi khi cập nhật bài viết: " + ex.Message));
            }
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
