using BIIC_Contest.Databases;
using BIIC_Contest.Models;
using System.Linq;

namespace BIIC_Contest.Repositorys
{
    public class SystemRepo
    {
        private BIICConnectionDbContext db = BIICConnectionDbContext.getInstance;

        public tbl_system getSystemInfo()
        {
            return db.tbl_systems.Where(e => e.id == 1).FirstOrDefault();
        }

        public bool update(string shortTitle, string logoUrl, string phone, string email, string address, bool allowNotification, bool allowAccess)
        {
            tbl_system system = getSystemInfo();

            if (system != null)
            {
                system.short_title = shortTitle;
                system.logo_url = logoUrl == "" ? system.logo_url : logoUrl;
                system.phone = phone;
                system.email = email;
                system.address = address;
                system.is_show_notification = allowNotification;
                system.is_allow = allowAccess;
                db.SubmitChanges();
                return true;
            }
            return false;
        }


        public bool update()
        {
            tbl_system system = getSystemInfo();

            if (system != null)
            {
                system.logo_url = "";
                db.SubmitChanges();
                return true;
            }
            return false;
        }
    }
}