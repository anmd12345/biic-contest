using BIIC_Contest.Dtos;
using BIIC_Contest.Helpers;
using BIIC_Contest.Models;
using BIIC_Contest.Repositorys;
using BIIC_Contest.Services.I;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace BIIC_Contest.Services
{
    public class ActivityLogService : IActivityLogService, IBaseService
    {
        private ActivityLogRepo repo = new ActivityLogRepo();

        public Dictionary<string, List<ActivityLogDto>> getAllActivityLog()
        {
            List<ActivityLogDto> logs = toDtos(repo.findAll(1000));

            Dictionary<string, List<ActivityLogDto>> result = logs
                .GroupBy(log =>DateTime.ParseExact(log.CreatedAt, "dd/MM/yyyy-HH:mm:ss", CultureInfo.InvariantCulture).ToString("dd/MM/yyyy"))
                .ToDictionary(g => g.Key, g => g.ToList());
            
            return result;
        }

        public void writeLog(string logDes, string logger)
        {
            if (string.IsNullOrEmpty(logDes))
            {
                return;
            }

            repo.insert(logDes, logger,DateTimeHelper.getFullFormattedDateNow());
        }



        public dynamic toDto(dynamic model)
        {
            tbl_activity_log log = model as tbl_activity_log;

            if (log != null)
            {
                return new ActivityLogDto
                {
                    LogId = log.activity_log_id,
                    CreatedAt = log.created_at,
                    LogDescription = log.log_description,
                    Logger = log.logger,
                    IsRead = (bool)log.is_read,
                    
                };
            }

            return null;
        }

        public dynamic toDtos(dynamic models)
        {
            List<tbl_activity_log> logs = models as List<tbl_activity_log>;
            List<ActivityLogDto> dtos = new List<ActivityLogDto>();

            foreach (var log in logs)
            {
                dtos.Add(toDto(log));
            }

            return dtos;
        }

        public dynamic toModel(dynamic dto)
        {
            throw new NotImplementedException();
        }

        public dynamic toModels(dynamic dtos)
        {
            throw new NotImplementedException();
        }
    }
}