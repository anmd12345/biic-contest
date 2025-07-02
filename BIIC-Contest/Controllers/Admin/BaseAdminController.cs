using BIIC_Contest.Constants;
using BIIC_Contest.Dtos;
using System.Web.Mvc;

namespace BIIC_Contest.Controllers.Admin
{
    public class BaseAdminController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session[SessionConstant.CURRENT_USER] == null || (Session[SessionConstant.CURRENT_USER] as UserDto).Role.RoleId == (int)RoleConstant.USER) {
                filterContext.Result = new RedirectResult("/dang-nhap");
                return;
            }
           
            base.OnActionExecuting(filterContext);
        }
    }
}