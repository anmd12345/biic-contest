using BIIC_Contest.Constants;
using System.Collections.Generic;

namespace BIIC_Contest.Entitys

{
    public class ActivityLogMessageEntity
    {
        public static readonly Dictionary<int, string> Messages = new Dictionary<int, string>
        {
            {(int) ActivityLogTypeConstant.LOGGED_SUCCESSFULLY, "Đăng nhập thành công" },
        };

        public static string getMessage(int key)
        {
            return Messages.TryGetValue(key, out var message) ? message : "Không rõ hành động";
        }

        public static string getMessage(ActivityLogTypeConstant type)
        {
            return getMessage((int)type);
        }

        public static string getMessage(string author, ActivityLogTypeConstant type)
        {
            return $"{author} - {getMessage(type)}";
        }
    }
}