using BIIC_Contest.Models;
using System.Configuration;

namespace BIIC_Contest.Databases
{
    public sealed class BIICConnectionDbContext : BIICConnectionDbDataContext
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["biic_contest_dbConnectionString"].ConnectionString;

        private BIICConnectionDbContext(string connectionString) : base(connectionString)
        {

        }

        public static BIICConnectionDbContext getInstance
        {
            get
            {
                return new BIICConnectionDbContext(connectionString);
            }
        }
    }
}