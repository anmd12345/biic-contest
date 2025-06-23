using System;
using System.Globalization;

namespace BIIC_Contest.Helpers
{
    public class DateTimeHelper
    {
        // Định dạng lại thời gian hiện tại theo dạng "dd/MM/yyyy-HH:mm"
        public static string getFormattedDateNow()
        {
            return DateTime.Now.ToString("dd/MM/yyyy-HH:mm");
        }

        public static string getFullFormattedDateNow()
        {
            return DateTime.Now.ToString("dd/MM/yyyy-HH:mm:ss");
        }

        public static string getFormatFriendlyDate(string time)
        {
            if (!DateTime.TryParseExact(time, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                return time;

            var today = DateTime.Today;
            var diff = (today - date).Days;

            if (diff == 0) return "Hôm nay";
            if (diff == 1) return "Hôm qua";
            if (diff == 2) return "2 ngày trước";
            if (diff == 3) return "3 ngày trước";

            return time;
        }

        public static string getFormatRelativeTime(string time)
        {
            if (!DateTime.TryParseExact(time, "dd/MM/yyyy-HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                return time;

            var now = DateTime.Now;
            var diff = now - date;

            if (diff.TotalMinutes < 1)
                return "Mới đây";

            if (diff.TotalMinutes < 60)
                return $"{(int)diff.TotalMinutes} phút trước";

            if (diff.TotalHours < 24 && now.Date == date.Date)
                return $"{(int)diff.TotalHours} giờ trước";

            string[] friendlyDates = time.Split('-');

            string friendlyDate = getFormatFriendlyDate(friendlyDates[0]);

            return $"{friendlyDate} lúc {friendlyDates[1]}";
        }
    }
}