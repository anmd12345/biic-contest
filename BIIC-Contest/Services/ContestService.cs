using BIIC_Contest.Dtos;
using BIIC_Contest.Entitys;
using BIIC_Contest.Models;
using BIIC_Contest.Repositorys;
using BIIC_Contest.Services.I;
using System;

namespace BIIC_Contest.Services
{
    public class ContestService : IContestService
    {
        private NewsRepository newsRepo = new NewsRepository();

        public BasicResponseEntity getContestById(int id)
        {
            var news = newsRepo.findById(id);
            if (news == null)
                return new BasicResponseEntity(false, "Không tìm thấy cuộc thi");

            var dto = new NewsDto
            {
                NewsId = news.news_id,
                Title = news.title,
                Content = news.content,
                CategoryId = (int)news.category_id,
                BannerUrl = news.banner_url,
                CreatedAt = news.created_at,
                Status = (short)news.status,
                Rule = news.rule,
                Prize = news.prize,
                Schedule = news.schedule,
                Sponsors = news.sponsors,
                BeginTime = news.begin_time,
                EndTime = news.end_time,
                AttachmentFiles = news.attachment_files,
                Criterias = news.criterias,
                IsPriority = news.is_priority ?? false
            };

            return new BasicResponseEntity(true, "Lấy cuộc thi thành công", dto);
        }


        public BasicResponseEntity createContest(NewsDto dto)
        {
            if (dto == null)
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
                var entity = new tbl_new
                {
                    title = dto.Title,
                    content = dto.Content,
                    category_id = (short?)dto.CategoryId,
                    banner_url = dto.BannerUrl,
                    user_id = dto.UserId,
                    created_at = DateTime.Now.ToString("dd/MM/yyyy - HH:mm"),
                    status = dto.Status,
                    is_priority = dto.IsPriority,

                    rule = dto.Rule,
                    prize = dto.Prize,
                    schedule = dto.Schedule,
                    sponsors = dto.Sponsors,
                    criterias = dto.Criterias,
                    begin_time = dto.BeginTime,
                    end_time = dto.EndTime,
                    attachment_files = dto.AttachmentFiles,

                    like = 0,
                    share = 0,
                    view = 0
                };

                newsRepo.createNews(entity); // dùng chung NewsRepository
                dto.NewsId = entity.news_id;

                return new BasicResponseEntity
                {
                    Success = true,
                    Message = "Tạo cuộc thi thành công!",
                    Data = dto
                };
            }
            catch (Exception ex)
            {
                return new BasicResponseEntity
                {
                    Success = false,
                    Message = "Lỗi khi tạo cuộc thi: " + ex.Message,
                    Data = null
                };
            }
        }


        public BasicResponseEntity getAllContests()
        {
            try
            {
                // category_id của cuộc thi là 3
                int contestCategoryId = 3;
                var contests = newsRepo.findByCategoryId(contestCategoryId);

                return new BasicResponseEntity
                {
                    Success = true,
                    Message = "Lấy danh sách cuộc thi thành công!",
                    Data = contests
                };
            }
            catch (Exception ex)
            {
                return new BasicResponseEntity
                {
                    Success = false,
                    Message = "Lỗi khi lấy danh sách cuộc thi: " + ex.Message,
                    Data = null
                };
            }
        }


        public BasicResponseEntity updateContest(NewsDto dto)
        {
            if (dto == null || dto.NewsId <= 0)
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
                var existingNews = newsRepo.findById(dto.NewsId);
                if (existingNews == null)
                {
                    return new BasicResponseEntity
                    {
                        Success = false,
                        Message = "Không tìm thấy cuộc thi để cập nhật!",
                        Data = null
                    };
                }

                // Cập nhật thông tin
                existingNews.title = dto.Title;
                existingNews.content = dto.Content;
                existingNews.category_id = (short?)dto.CategoryId;
                existingNews.status = dto.Status;
                existingNews.is_priority = dto.IsPriority;
                existingNews.rule = dto.Rule;
                existingNews.prize = dto.Prize;
                existingNews.schedule = dto.Schedule;
                existingNews.sponsors = dto.Sponsors;
                existingNews.criterias = dto.Criterias;
                existingNews.begin_time = dto.BeginTime;
                existingNews.end_time = dto.EndTime;
                existingNews.attachment_files = dto.AttachmentFiles;

                // Nếu có banner mới thì gán
                if (!string.IsNullOrEmpty(dto.BannerUrl))
                    existingNews.banner_url = dto.BannerUrl;

                newsRepo.updateNews(existingNews); // dùng phương thức update

                return new BasicResponseEntity
                {
                    Success = true,
                    Message = "Cập nhật cuộc thi thành công!",
                    Data = dto
                };
            }
            catch (Exception ex)
            {
                return new BasicResponseEntity
                {
                    Success = false,
                    Message = "Lỗi khi cập nhật cuộc thi: " + ex.Message,
                    Data = null
                };
            }
        }


        public BasicResponseEntity deleteContest(int id)
        {
            try
            {
                var contest = newsRepo.findById(id);
                if (contest == null)
                {
                    return new BasicResponseEntity
                    {
                        Success = false,
                        Message = "Không tìm thấy cuộc thi để xoá!",
                        Data = null
                    };
                }

                newsRepo.deleteNews(id); // ✅ truyền id đúng với định nghĩa

                return new BasicResponseEntity
                {
                    Success = true,
                    Message = "Xoá cuộc thi thành công!",
                    Data = null
                };
            }
            catch (Exception ex)
            {
                return new BasicResponseEntity
                {
                    Success = false,
                    Message = "Lỗi khi xoá cuộc thi: " + ex.Message,
                    Data = null
                };
            }
        }




    }
}
