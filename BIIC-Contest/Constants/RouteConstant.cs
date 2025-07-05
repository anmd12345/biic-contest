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
        public const string CONTACT_PAGE = "/lien-he";
        public const string HOME_PAGE = "/trang-chu";
        public const string NEWS_PAGE = "/tin-tuc";
        public const string LOGIN_PAGE = "/dang-nhap";
        public const string SIGNUP_PAGE = "/dang-ky";
        public const string REGISTER_CONTEST_PAGE = "/dang-ky-cuoc-thi";
        public const string FORGOT_PASSWORD_PAGE = "/quen-mat-khau";


        //Admin Routes
        public const string ACTIVITY_LOG_PAGE = "/nhat-ky-hoat-dong";
        public const string BASE_CONTACT_MESSAGE_DETAIL_ROUTE = "/tin-nhan/chi-tiet-tin-nhan";
        public const string BASE_USER_INFO_ROUTE = "/quan-ly-nguoi-dung/thong-tin-nguoi-dung";
        public const string BASE_LIST_SUBMISSION_ROUTE = "/danh-sach-bai-du-thi";
        public const string CONTACT_MESSAGE_MANAGEMENT_PAGE = "/tin-nhan/danh-sach-tin-nhan";
        public const string CREATE_NEWS_PAGE = "/tao-bai-viet-moi";
        public const string CREATE_CONTEST_PAGE = "/tao-cuoc-thi";
        public const string DASHBOARD_PAGE = "/bang-dieu-khien";
        public const string LIST_NEWS_PAGE = "/danh-sach-bai-viet";
        public const string LIST_CONTEST_PAGE = "/danh-sach-cuoc-thi";
        public const string LIST_CATEGORY_PAGE = "/danh-sach-danh-muc";
        public const string USER_MANAGEMENT_PAGE = "/quan-ly-nguoi-dung";
        public const string LIST_ASSIGNMENT_PAGE = "/danh-sach-cong-viec";
        public const string VIEW_ASSIGNMENT_WItH_EXAMINER = "/chi-tiet-bai-du-thi-v1";
        public const string VIEW_ASSIGNMENT_WItH_EMPLOYEE = "/chi-tiet-bai-du-thi-v2";
        
    }
}