using BIIC_Contest.Dtos;
using BIIC_Contest.Models;
using BIIC_Contest.Repositorys;
using BIIC_Contest.Services.I;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIIC_Contest.Services
{
    public class SystemService : ISystemService
    {
        private SystemRepo repo = new SystemRepo();

        public SystemDto getSystemInfo()
        {
            tbl_system system = repo.getSystemInfo();

            return new SystemDto
            {
                LogoUrl = system.logo_url,
                ShortTitle = system.short_title,
                Address = system.address,
                Phone = system.phone,
                Email = system.email,
                IsShowNotification = (bool)system.is_show_notification,
                IsAllow = (bool)system.is_allow,
            };
        }
    }
}