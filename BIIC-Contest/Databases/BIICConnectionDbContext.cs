using BIIC_Contest.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace BIIC_Contest.Databases
{
    public class BIICConnectionDbContext : BIICConnectionDbDataContext
    {
        private static BIICConnectionDbContext instance;
        private static readonly object lockProcess = new object();
        private static string connectionString = ConfigurationManager.ConnectionStrings["biic_contest_dbConnectionString"].ConnectionString;

        private BIICConnectionDbContext(string connectionString) : base(connectionString)
        {

        }

        public static BIICConnectionDbContext getInstance
        {
            get
            {
                lock (lockProcess)
                {
                    if (instance == null)
                    {
                        instance = new BIICConnectionDbContext(connectionString);
                    }
                    return instance;
                }
            }
        }
    }
}