using BIIC_Contest.Constants;
using BIIC_Contest.Dtos;
using BIIC_Contest.Entitys;
using BIIC_Contest.Models;
using BIIC_Contest.Repositorys;
using BIIC_Contest.Services.I;

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

        public BasicResponseEntity update(string shortTitle, string logoUrl, string phone, string email, string address, bool allowNotification, bool allowAccess)
        {
            bool response = repo.update(shortTitle, logoUrl, phone, email, address, allowNotification, allowAccess);

            if (response)
            {
                return new BasicResponseEntity
                {
                    Success = true,
                    Message = MessageConstant.SystemMessage[0],
                    Data = getSystemInfo()
                };
            }

            return new BasicResponseEntity
            {
                Success = false,
                Message = MessageConstant.SystemMessage[1],
                Data = null
            };
        }
    }
}