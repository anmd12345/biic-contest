using BIIC_Contest.Databases;
using BIIC_Contest.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BIIC_Contest.Repositorys
{
    public class NewsRepository
    {
        private BIICConnectionDbContext db = BIICConnectionDbContext.getInstance;

        public List<tbl_new> findByCategoryId(int categoryId)
        {
            return db.tbl_news.Where(n => n.category_id == categoryId).ToList();
        }


        // Phương thức để thêm bài viết vào cơ sở dữ liệu
        public void createNews(tbl_new news)
        {
            try
            {
                db.tbl_news.InsertOnSubmit(news);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lưu contest: " + ex.Message);
                throw; // Bắt buộc phải throw lại
            }
        }


        // Phương thức tìm bài viết theo ID
        public tbl_new findById(int id)
        {
            return db.tbl_news.FirstOrDefault(e => e.news_id == id);
        }

        // Phương thức tìm tất cả bài viết
        public List<tbl_new> findAll()
        {
            return db.tbl_news.ToList();  // Lấy tất cả bài viết
        }



        public void updateNews(tbl_new news)
        {
            try
            {
                var existingNews = db.tbl_news.FirstOrDefault(e => e.news_id == news.news_id);
                if (existingNews != null)
                {
                    // Cập nhật các trường trong bài viết
                    existingNews.title = news.title;
                    existingNews.content = news.content;
                    existingNews.category_id = news.category_id;
                    existingNews.banner_url = news.banner_url;
                    existingNews.created_at = news.created_at;
                    existingNews.status = news.status;

                    db.SubmitChanges();  // Lưu thay đổi vào cơ sở dữ liệu
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi (nếu cần)
            }
        }

        public void deleteNews(int id)
        {
            try
            {
                var newsToDelete = db.tbl_news.FirstOrDefault(e => e.news_id == id);
                if (newsToDelete != null)
                {
                    db.tbl_news.DeleteOnSubmit(newsToDelete);  // Xóa bài viết
                    db.SubmitChanges();  // Lưu thay đổi vào cơ sở dữ liệu
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi (nếu cần)
            }
        }



    }
}
