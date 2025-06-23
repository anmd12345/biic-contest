using BIIC_Contest.Databases;
using BIIC_Contest.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Http.ExceptionHandling;

namespace BIIC_Contest.Repositorys
{
    public class ActivityLogRepo
    {
        private BIICConnectionDbContext db = BIICConnectionDbContext.getInstance;

        public List<tbl_activity_log> findAll()
        {
            return db.tbl_activity_logs.ToList();
        }

        public List<tbl_activity_log> findAll(int count)
        {
            return db.tbl_activity_logs
                .ToList()
                .Where(x => !string.IsNullOrWhiteSpace(x.created_at))
                .OrderByDescending(x =>DateTime.ParseExact(x.created_at, "dd/MM/yyyy-HH:mm:ss", CultureInfo.InvariantCulture))
                .Take(count)
                .ToList();
        }

        public void insert(string logDescription, string logger, string createdAt)
        {
            tbl_activity_log log = new tbl_activity_log
            {
                log_description = logDescription,
                is_read = false,
                logger = logger,
                created_at = createdAt
            };

            db.tbl_activity_logs.InsertOnSubmit(log);
            db.SubmitChanges();
        }
    }
}