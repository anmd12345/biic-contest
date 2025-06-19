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

        //Thông báo lỗi
        public static string[] ErrorNotifications = new string[]
        {
            "Email đã được sử dụng, vui lòng sử dụng email khác!",
            "Số điện thoại đã được sử dụng, vui lòng sử dụng số điện thoại khác!",
            "Đã có lỗi xảy ra trong quá đăng ký tài khoản, vui lòng thử lại sau.",
            "Bạn chưa nhập nhập thông tin email!",
            "Bạn chưa nhập nhập số điện thoại!",
            "Bạn chưa nhập nhập họ tên!",
            "Bạn chưa nhập mật khẩu!",
            "Bạn chưa xác nhận mật khẩu!",
            "Xác nhận mật khẩu không hợp lệ, vui lòng nhập lại!",
            "Số điện thoại không hợp lệ, vui lòng nhập lại!",
            "Email không hợp lệ, vui lòng nhập lại!",
        };

        public static string[] SuccessNotifications = new string[]
        {
            "Đăng ký tài khoản thành công!",
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