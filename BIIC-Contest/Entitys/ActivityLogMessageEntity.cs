using BIIC_Contest.Constants;
using System.Collections.Generic;

namespace BIIC_Contest.Entitys

{
    public class ActivityLogMessageEntity
    {
        public static readonly Dictionary<int, string> Messages = new Dictionary<int, string>
        {
            {(int) ActivityLogTypeConstant.LOGGED_SUCCESSFULLY, "Đăng nhập thành công" },
            {(int) ActivityLogTypeConstant.LOGGED_FAILED, "Đăng nhập thất bại" },
            {(int) ActivityLogTypeConstant.REGISTERED_SUCCESSFULLY, "Đăng ký thành công" },
            {(int) ActivityLogTypeConstant.REGISTERED_CONTEST, "Đăng ký cuộc thi" },
            {(int) ActivityLogTypeConstant.UPDATED_WEBSITE_INORMATION, "Cập nhật thông tin website" },
            {(int) ActivityLogTypeConstant.SEND_CONTACT_MESSAGE, "Gửi tin nhắn liên hệ" }
        };

        public static string getMessage(int key)
        {
            return Messages.TryGetValue(key, out var message) ? message : "Không rõ hành động";
        }

        public static string getMessage(ActivityLogTypeConstant type)
        {
            return getMessage((int)type);
        }

        public static string getMessage(string author, ActivityLogTypeConstant type, string des)
        {
            return $"{author} - {getMessage(type)} {des}";
        }
    }
}