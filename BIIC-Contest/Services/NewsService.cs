using BIIC_Contest.Dtos;
using BIIC_Contest.Entitys;
using BIIC_Contest.Models;
using BIIC_Contest.Repositorys;
using BIIC_Contest.Services.I;
using System;

namespace BIIC_Contest.Services
{
    public class NewsService : INewsService  // Implement INewsService
    {
        private NewsRepository newsRepo = new NewsRepository();

        // Phương thức để thêm bài viết
        public BasicResponseEntity createNews(NewsDto newsDto)
        {
            if (newsDto == null)
            {
                return new BasicResponseEntity
                {
                    Success = false,
                    Message = "Dữ liệu không hợp lệ!",
                    Data = null
                };
            }

            try
            {
                // Chuyển DTO sang model entity tbl_new
                var newNews = new tbl_new
                {
                    title = newsDto.Title,
                    content = newsDto.Content,
                    category_id = (short?)newsDto.CategoryId,
                    banner_url = newsDto.BannerUrl,
                    user_id = newsDto.UserId,
                    created_at = DateTime.Now.ToString("yyyy-MM-dd"),
                    status = newsDto.Status, 
                    is_priority = newsDto.IsPriority,

                    like = 0,
                    share = 0,
                    view = 0,

                };

                // Lưu bài viết vào cơ sở dữ liệu qua NewsRepository
                newsRepo.createNews(newNews);

                return new BasicResponseEntity
                {
                    Success = true,
                    Message = "Bài viết đã được tạo thành công!",
                    Data = newsDto
                };
            }
            catch (Exception ex)
            {
                return new BasicResponseEntity
                {
                    Success = false,
                    Message = "Có lỗi xảy ra: " + ex.Message,
                    Data = null
                };
            }
        }

        // Phương thức lấy tất cả bài viết
        public BasicResponseEntity getAllNews()
        {
            try
            {
                var newsList = newsRepo.findAll();

                return new BasicResponseEntity
                {
                    Success = true,
                    Message = "Lấy danh sách bài viết thành công!",
                    Data = newsList
                };
            }
            catch (Exception ex)
            {
                return new BasicResponseEntity
                {
                    Success = false,
                    Message = "Có lỗi xảy ra: " + ex.Message,
                    Data = null
                };
            }
        }

        // Phương thức lấy bài viết theo ID
        public NewsDto getNewsById(int id)
        {
            var news = newsRepo.findById(id);
            return news != null ? new NewsDto
            {
                NewsId = news.news_id,
                Title = news.title,
                Content = news.content,
                CategoryId = (int)news.category_id,
                BannerUrl = news.banner_url,
                CreatedAt = news.created_at,
                Status = (short)news.status
            } : null;
        }

        public BasicResponseEntity updateNews(NewsDto newsDto)
        {
            try
            {
                var updatedNews = new tbl_new
                {
                    news_id = newsDto.NewsId,
                    title = newsDto.Title,
                    content = newsDto.Content,
                    category_id = (short?)newsDto.CategoryId,
                    banner_url = newsDto.BannerUrl,
                    created_at = DateTime.Now.ToString("yyyy-MM-dd"),
                    status = newsDto.Status
                };

                // Gọi repository để cập nhật bài viết
                newsRepo.updateNews(updatedNews);

                return new BasicResponseEntity
                {
                    Success = true,
                    Message = "Bài viết đã được cập nhật thành công!",
                    Data = newsDto
                };
            }
            catch (Exception ex)
            {
                return new BasicResponseEntity
                {
                    Success = false,
                    Message = "Có lỗi xảy ra: " + ex.Message,
                    Data = null
                };
            }
        }

        public BasicResponseEntity deleteNews(int id)
        {
            try
            {
                // Gọi repository để xóa bài viết
                newsRepo.deleteNews(id);

                return new BasicResponseEntity
                {
                    Success = true,
                    Message = "Bài viết đã được xóa thành công!",
                    Data = null
                };
            }
            catch (Exception ex)
            {
                return new BasicResponseEntity
                {
                    Success = false,
                    Message = "Có lỗi xảy ra: " + ex.Message,
                    Data = null
                };
            }
        }

    }
}
