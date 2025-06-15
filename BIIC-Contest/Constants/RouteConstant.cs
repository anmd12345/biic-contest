namespace BIIC_Contest.Constants
{
    public class RouteConstant
    {
        //Api routes
        public const string LOGIN_API = "/apis/v1/user/login";


        //Error Routes
        public const string _404 = "/404";
        public const string _500 = "/500";

        //Classic Routes
        public const string HOME_PAGE = "/trang-chu";
        public const string CONTACT_PAGE = "/lien-he";
        public const string NEWS_PAGE = "/tin-tuc";
        public const string LOGIN_PAGE = "/dang-nhap";
        public const string SIGNUP_PAGE = "/dang-ky";
        public const string FORGOT_PASSWORD_PAGE = "/quen-mat-khau";


        //Admin Routes
        public const string CONFIG_WEB_PAGE = "/quan-ly-he-thong";
        public const string ACTIVITY_LOG_PAGE = "/quan-ly-he-thong/nhat-ky-hoat-dong";
        public const string USER_MANAGEMENT_PAGE = "/quan-ly-nguoi-dung";
        public const string CONTACT_MESSAGE_MANAGEMENT_PAGE = "/quan-ly-tin-nhan/danh-sach-tin-nhan";
    }
}