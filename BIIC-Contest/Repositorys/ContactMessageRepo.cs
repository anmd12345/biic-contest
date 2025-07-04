﻿using BIIC_Contest.Databases;
using BIIC_Contest.Models;
using System.Collections.Generic;
using System.Linq;

namespace BIIC_Contest.Repositorys
{
    // Các phương thức trong lớp này sẽ tương tác với cơ sở dữ liệu để quản lý thông tin liên hệ
    public class ContactMessageRepo
    {
        // Biến db được sử dụng để truy cập cơ sở dữ liệu
        private BIICConnectionDbContext db = BIICConnectionDbContext.getInstance;

        // Hàm thêm thông tin liên hệ
        public void createContactMessage(string fullname, string email, string phone, string message, string ip, string sendAt)
        {
            try
            {
                tbl_contact_message newContactMessage = createNewContactMessage(fullname, email, phone, message, ip, sendAt);
                db.tbl_contact_messages.InsertOnSubmit(newContactMessage);
                db.SubmitChanges();
            }
            catch
            {
            }
        }

        public tbl_contact_message findById(int id)
        {
            return db.tbl_contact_messages.FirstOrDefault(e=>e.contact_message_id == id);
        }


        public List<tbl_contact_message> findAll()
        {
            return db.tbl_contact_messages.ToList();
        }

        private tbl_contact_message createNewContactMessage(string fullname, string email, string phone, string message, string ip, string sendAt)
        {
            return new tbl_contact_message
            {
                fullname = fullname,
                email = email,
                phone = phone,
                message = message,
                send_at = sendAt,
                send_ip = ip
            };
        }
    }
}