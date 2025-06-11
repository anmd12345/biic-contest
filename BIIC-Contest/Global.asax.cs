using BIIC_Contest.Constants;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BIIC_Contest
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ConfigureApiResponsesToJson();
        }

        //Chặn request chứa script nguy hiểm
        protected void Application_BeginRequest()
        {
            string requestUrl = Request.RawUrl;
            string postData = Request.Form.ToString();

            if (Regex.IsMatch(requestUrl + postData, @"<script|x8s\.pw", RegexOptions.IgnoreCase))
            {
                Response.StatusCode = 403;
                Response.End();
            }
        }

        private void ConfigureApiResponsesToJson()
        {
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings =
                new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    TypeNameHandling = TypeNameHandling.All,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    PreserveReferencesHandling = PreserveReferencesHandling.None
                };
            GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
        }

        protected void Application_Error()
        {
            var exception = Server.GetLastError() as HttpException;

            if (exception != null && exception.GetHttpCode() == 404)
            {
                string currentUrl = Request.Url.AbsolutePath;
                Response.Redirect(RouteConstant._404);

            }
            else if (exception != null && exception.GetHttpCode() == 500)
            {
                //Response.Redirect(RouteConstant.SERVER_INTERNAL);
            }
        }


    }
}
