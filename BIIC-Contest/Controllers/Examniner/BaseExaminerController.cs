using BIIC_Contest.Constants;
using BIIC_Contest.Dtos;
using System.Web.Mvc;

namespace BIIC_Contest.Controllers
{
    public class BaseExaminerController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var currentUser = Session[SessionConstant.CURRENT_USER] as UserDto;

            // Chuyển hướng nếu chưa đăng nhập hoặc không phải là Examiner
            if (currentUser == null || currentUser.Role.RoleId != 2)
            {
                filterContext.Result = new RedirectResult("/dang-nhap");
                return;
            }

            base.OnActionExecuting(filterContext);
        }
    }
}