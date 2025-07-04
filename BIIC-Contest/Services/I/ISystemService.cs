using BIIC_Contest.Dtos;
using BIIC_Contest.Entitys;

namespace BIIC_Contest.Services.I
{
    internal interface ISystemService
    {
        SystemDto getSystemInfo();

        BasicResponseEntity update(string shortTitle, string logoUrl, string phone, string email, string address, bool allowNotification, bool allowAccess);
    }
}
