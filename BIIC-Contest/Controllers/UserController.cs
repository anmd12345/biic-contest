﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BIIC_Contest.Controllers
{
    public class UserController : BaseController
    {
        // GET: User

        [Route("dang-nhap")]
        public ActionResult Login()
        {
            return View();
        }

        [Route("dang-ky")]
        public ActionResult Signup()
        {
            return View();
        }

        [Route("ho-so")]
        public ActionResult Profile()
        {
           
            return View();
        }
    }
}