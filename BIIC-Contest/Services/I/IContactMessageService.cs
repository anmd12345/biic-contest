using BIIC_Contest.Dtos;
using System.Collections.Generic;

namespace BIIC_Contest.Services.I
{
    internal interface IContactMessageService
    {
        short createContactMessage(string fullname, string email, string phone, string message, string ip);
        List<ContactMessageDto> findAll();
    }
}
