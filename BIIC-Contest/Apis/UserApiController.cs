using BIIC_Contest.Constants;
using BIIC_Contest.Entitys;
using BIIC_Contest.Helpers;
using BIIC_Contest.Services;
using System;
using System.Web.Mvc;

namespace BIIC_Contest.Apis
{
    [RoutePrefix("apis/v1/user")]
    public class UserApiController : Controller
    {
        private UserService userService = new UserService();
        private ActivityLogService activityLogService = new ActivityLogService();

        [Route("login")]
        [HttpPost]
        public JsonResult Login(string username, string password)
        {
            try
            {
                var response = userService.login(username, password);
                if (response != null)
                {
                    //Gắn session
                    Session[SessionConstant.CURRENT_USER] = response;
                    
                    // Kết quả trả về của api
                    var message = new BasicResponseEntity(
                        true,
                        MessageConstant.SuccessNotifications[1],
                        response
                    );

                    //Ghi log hoạt động
                    activityLogService.writeLog(ActivityLogMessageEntity.getMessage(response.Fullname, ActivityLogTypeConstant.LOGGED_SUCCESSFULLY), response.Fullname);

                    return Json(message);
                }
                return Json(new BasicResponseEntity(
                    false,
                    MessageConstant.ErrorNotifications[11]
                ));
            }
            catch (Exception ex)
            {
                return Json(new BasicResponseEntity(
                    false,
                    MessageConstant.ErrorNotifications[12]
                ));
            }
        }

        [Route("logout")]
        [HttpPost]
        public JsonResult Logout()
        {
            try
            {
                Session[SessionConstant.CURRENT_USER] = null;
                return Json(new BasicResponseEntity(
                    true,
                    MessageConstant.SuccessNotifications[2]
                ));
            }
            catch (Exception ex)
            {
                return Json(new BasicResponseEntity(
                    false,
                    MessageConstant.ErrorNotifications[13]
                ));
            }
        }



        [Route("us-signup")]
        [HttpPost]
        public JsonResult UserSignup(string fullname, string email, string phone, string password, string rePass)
        {
            try
            {
                var response = userService.signup(fullname, email, phone, password, "", rePass, (short)RoleConstant.USER);

                if (response != null)
                {
                    Session[SessionConstant.CURRENT_USER] = response.Data;
                }
                return Json(response);
            }
            catch (Exception ex)
            {
                return Json(new BasicResponseEntity(
                    false,
                    MessageConstant.ErrorNotifications[2] + $"${ex.Message}"
                ));
            }
        }
    }
}