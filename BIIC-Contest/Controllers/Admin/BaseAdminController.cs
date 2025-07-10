using BIIC_Contest.Constants;
using BIIC_Contest.Dtos;
using System.Web.Mvc;

namespace BIIC_Contest.Controllers.Admin
{
    public class BaseAdminController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var currentUser = Session[SessionConstant.CURRENT_USER] as UserDto;

            // 1. Kiểm tra nếu người dùng chưa đăng nhập
            if (currentUser == null)
            {
                filterContext.Result = new RedirectResult("/dang-nhap");
                return;
            }

            // 2. Kiểm tra vai trò (Role) của người dùng đã đăng nhập
            switch (currentUser.Role.RoleId)
            {
                case 1:
                    // RoleId = 1 là Admin, cho phép tiếp tục
                    break;

                case 2:
                    // RoleId = 2 là Examiner, chuyển hướng đến trang của Examiner
                    // Bạn có thể thay đổi URL "/examiner" thành URL thực tế của mình
                    filterContext.Result = new RedirectResult("/examiner");
                    return;

                default:
                    // Các vai trò còn lại không có quyền truy cập, chuyển về trang đăng nhập
                    filterContext.Result = new RedirectResult("/dang-nhap");
                    return;
            }

            // Chỉ khi RoleId = 1 thì code mới chạy đến dòng này
            base.OnActionExecuting(filterContext);
        }
    }
}