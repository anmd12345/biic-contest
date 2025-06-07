using System.Text.RegularExpressions;

namespace BIIC_Contest.Helpers
{
    public class ValidateDataHelper
    {
        //Kiểm tra số điện thoại có dạng 10 chữ số, bắt đầu bằng 0 và không có khoảng trắng.
        //Trả về true nếu số điện thoại hợp lệ
        public static bool isValidPhoneNumber(string phoneNumber)
        {
            phoneNumber = phoneNumber.Trim();

            if (string.IsNullOrWhiteSpace(phoneNumber))
                return false;

            return Regex.IsMatch(phoneNumber, @"^0\d{9}$");
        }

        //Kiểm tra email có định dạng xxx@xxxx.xxx
        //Trả về true nếu email hợp lệ
        public static bool isValidEmail(string email)
        {
            /* if (string.IsNullOrWhiteSpace(email))
                 return false;

             email = email.Trim();

             return Regex.IsMatch(email,
                 @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                 RegexOptions.IgnoreCase);*/
            return true;
        }

        //Trả về true nếu chuỗi rỗng, null hoặc chỉ chứa khoảng trắng
        public static bool isNullOrEmpty(string text)
        {
            return string.IsNullOrWhiteSpace(text);
        }
    }
}