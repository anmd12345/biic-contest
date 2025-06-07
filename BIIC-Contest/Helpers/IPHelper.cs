using System.Web;

namespace BIIC_Contest.Helpers
{
    public class IPHelper
    {
        public static string GetClientIp()
        {
            var context = HttpContext.Current;
            if (context == null) return null;

            string ip = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (!string.IsNullOrEmpty(ip))
            {
                string[] addresses = ip.Split(',');
                if (addresses.Length > 0)
                    return addresses[0];
            }

            return context.Request.ServerVariables["REMOTE_ADDR"];
        }
    }
}