namespace BIIC_Contest.Constants
{
    public class MessageConstant
    {
        public static string[] ContactNotifications = new string[]
        {
            "Gửi thông tin liên hệ thành công, chúng tôi sẽ phản hồi trong thời gian sớm nhất.",
            "Vui lòng nhập họ tên của bạn.",
            "Vui lòng nhập số điện thoại của bạn.",
            "Số điện thoại không hợp lệ, vui lòng nhập lại.",
            "Vui lòng nhập địa chỉ email của bạn.",
            "Địa chỉ email không hợp lệ, vui lòng nhập lại.",
            "Vui lòng nhập nội dung tin nhắn của bạn.",
            "Đã có lỗi xảy ra trong quá trình gửi thông tin liên hệ, vui lòng thử lại sau."
        };

        //Tên quyền + mô tả
        public static string[][] RoleNames = new string[][]
        {
            new string[] { "unknown", "Unknown role" },
            new string[] { "admin", "Quản trị trang" },
            new string[] { "examiner", "Giám khảo" },
            new string[] { "employee", "Nhân viên" },
            new string[] { "user", "Người dùng" },
        };
    }
}