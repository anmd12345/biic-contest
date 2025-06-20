﻿using BIIC_Contest.Constants;
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

        [Route("login")]
        [HttpPost]
        public JsonResult Login(string username, string password)
        {
            try
            {
                var response = userService.login(username, password);
                if (response != null)
                {
                    Session[SessionConstant.CURRENT_USER] = response;
                    var message = new BasicResponseEntity(
                        true,
                        "Đăng nhập thành công!",
                        response
                    );

                    return Json(message);
                }
                return Json(new BasicResponseEntity(
                    false,
                    "Thông tin đăng nhập không chính xác!"
                ));
            }
            catch (Exception ex)
            {
                return Json(new BasicResponseEntity(
                    false,
                    "Lỗi hệ thống! Không thể đăng nhập bây giờ (" + ex.Message + ")."
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