using BIIC_Contest.Dtos;
using BIIC_Contest.Helpers;
using BIIC_Contest.Models;
using BIIC_Contest.Repositorys;
using BIIC_Contest.Services.I;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BIIC_Contest.Services
{
    public class ContactMessageService : IContactMessageService, IBaseService
    {
        // Lớp này sẽ sử lý logic và thực hiện các thao tác liên quan đến thông tin liên hệ
        private ContactMessageRepo repo = new ContactMessageRepo();

        public short createContactMessage(string fullname, string email, string phone, string message, string ip)
        {
            try
            {
                if (ValidateDataHelper.isNullOrEmpty(fullname)) return 1;
                if (ValidateDataHelper.isNullOrEmpty(phone)) return 2;
                if (!ValidateDataHelper.isValidPhoneNumber(phone)) return 3;
                if (ValidateDataHelper.isNullOrEmpty(email)) return 4;
                if (!ValidateDataHelper.isValidEmail(email)) return 5;
                if (ValidateDataHelper.isNullOrEmpty(message)) return 6;

                string sendAt = DateTimeHelper.getFormattedDateNow();

                repo.createContactMessage(fullname, email, phone, message, ip, sendAt);
                return 0;
            }
            catch
            {
                return 7;
            }
        }

        public List<ContactMessageDto> findAll()
        {
            List<tbl_contact_message> contactMessages = repo.findAll();

            List<ContactMessageDto> contactMessageDtos = toDtos(contactMessages);

            contactMessageDtos = contactMessageDtos.OrderByDescending(x => x.SendAt).ToList();

            return contactMessageDtos;
        }

        public dynamic toDto(dynamic model)
        {
            tbl_contact_message contactMessage = model as tbl_contact_message;

            if (contactMessage == null)
            {
                return null;
            }

            return new ContactMessageDto
            {
                ContactMessageId = contactMessage.contact_message_id,
                Fullname = contactMessage.fullname,
                Email = contactMessage.email,
                Phone = contactMessage.phone,
                Message = contactMessage.message,
                SendIp = contactMessage.send_ip,
                SendAt = contactMessage.send_at,
                IsSeen = (bool)contactMessage.is_seen,

            };
        }

        public dynamic toModel(dynamic dto)
        {
            throw new NotImplementedException();
        }

        public dynamic toDtos(dynamic models)
        {
            List<tbl_contact_message> contactMessages = models as List<tbl_contact_message>;

            List<ContactMessageDto> contactMessageDtos = new List<ContactMessageDto>();

            foreach (var contactMessage in contactMessages)
            {
                contactMessageDtos.Add(toDto(contactMessage));
            }

            return contactMessageDtos;
        }

        public dynamic toModels(dynamic dtos)
        {
            throw new NotImplementedException();
        }

        public ContactMessageDto getContactMessageById(int id)
        {
            var contactMessage = repo.findById(id);

            var data = toDto(contactMessage);

            return data;
        }
    }
}