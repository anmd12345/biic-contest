using System;

namespace BIIC_Contest.Dtos
{
    public class NewsDto
    {
        private int newsId;
        private string title;
        private string content;
        private int categoryId;
        private string bannerUrl;
        private string createdAt;
        private short status;
        private string rule;
        private string prize;
        private string schedule;
        private string sponsors;
        private string beginTime;
        private string endTime;
        private string attachmentFiles;
        private string criterias;
        private bool isPriority;
        private int userId;
        private int? like;
        private int? share;
        private int? view;

        public int NewsId { get => newsId; set => newsId = value; }
        public string Title { get => title; set => title = value; }
        public string Content { get => content; set => content = value; }
        public int CategoryId { get => categoryId; set => categoryId = value; }
        public string BannerUrl { get => bannerUrl; set => bannerUrl = value; }
        public string CreatedAt { get => createdAt; set => createdAt = value; }
        public short Status { get => status; set => status = value; }
        public string Rule { get => rule; set => rule = value; }
        public string Prize { get => prize; set => prize = value; }
        public string Schedule { get => schedule; set => schedule = value; }
        public string Sponsors { get => sponsors; set => sponsors = value; }
        public string BeginTime { get => beginTime; set => beginTime = value; }
        public string EndTime { get => endTime; set => endTime = value; }
        public string AttachmentFiles { get => attachmentFiles; set => attachmentFiles = value; }
        public string Criterias { get => criterias; set => criterias = value; }
        public bool IsPriority { get => isPriority; set => isPriority = value; }

        public int UserId { get => userId; set => userId = value; }
        public int? Like { get => like; set => like = value; }
        public int? Share { get => share; set => share = value; }
        public int? View { get => view; set => view = value; }
    }
}
