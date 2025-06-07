using System;

namespace BIIC_Contest.Helpers
{
    public class DateTimeHelper
    {
        // Định dạng lại thời gian hiện tại theo dạng "dd/MM/yyyy-HH:mm"
        public static string getFormattedDateNow()
        {
            return DateTime.Now.ToString("dd/MM/yyyy-HH:mm");
        }
    }
}