using BIIC_Contest.Helpers;

namespace BIIC_Contest.Dtos
{
    public class ActivityLogDto
    {
        private int logId;
        private string logDescription;
        private string createdAt;
        private string logger;
        private bool isRead;

        public int LogId { get => logId; set => logId = value; }
        public string LogDescription { get => logDescription; set => logDescription = value; }
        public string CreatedAt { get => createdAt; set => createdAt = value; }
        public string Logger { get => logger; set => logger = value; }
        public bool IsRead { get => isRead; set => isRead = value; }
    }
}