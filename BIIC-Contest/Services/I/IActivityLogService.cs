using BIIC_Contest.Dtos;
using System.Collections.Generic;

namespace BIIC_Contest.Services.I
{
    internal interface IActivityLogService
    {
        void writeLog(string logDes, string logger);

        Dictionary<string, List<ActivityLogDto>> getAllActivityLog();
    }
}
