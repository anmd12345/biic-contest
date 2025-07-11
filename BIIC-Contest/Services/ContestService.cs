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

    }
}
