using System.Collections.Generic;

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
            "Thông tin đăng nhập không chính xác!",
            "Lỗi hệ thống! Không thể đăng nhập bây giờ",
             "Lỗi hệ thống! Không thể đăng xuất bây giờ",
             "Bạn chưa phân quyền cho người dùng này!",
             "Bạn chưa nhập chuyên môn cho ban giám khảo!"
        };

        public static string[] SuccessNotifications = new string[]
        {
            "Đăng ký tài khoản thành công!",
            "Đăng nhập thành công!",
            "Đăng xuất thành công!",
        };

        //Category
        public static string[] CategoryMessage = new string[]
        {
            "Tên danh mục đã tồn tại!",
            "Tên danh mục không được để trống!",
            "Tạo danh mục mới thành công!",
            "Hệ thống đang gặp sự cố. Tạo danh mục không thành công!",
            "Danh mục trống!",
            "Lấy danh sách danh mục thành công!",
            "Cập nhật danh mục thành công!",
            "Cập nhật danh mục không thành công!",
            "Xóa danh mục không thành công!",
            "Xóa danh mục thành công!",
        };

        public static string[] SystemMessage = new string[]
        {
            "Cập nhật thông tin website thành công!",
            "Lỗi hệ thống! Vui lòng quay lại sau!",
            "Xóa logo thành công!",
            "Xóa logo không thành công!",
        };

        public static Dictionary<string, string> RoleNames = new Dictionary<string, string>
        {
            { "unknown", "Unknown role" },
            { "admin", "Quản trị trang" },
            { "examiner", "Giám khảo" },
            { "employee", "Nhân viên" },
            { "user", "Người dùng" }
        };
    }
}