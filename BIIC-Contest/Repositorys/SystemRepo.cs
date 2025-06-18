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
            return db.tbl_systems.FirstOrDefault();
        }
    }
}