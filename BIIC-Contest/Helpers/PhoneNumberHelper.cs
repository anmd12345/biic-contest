using System.Linq;

namespace BIIC_Contest.Helpers
{
    public class PhoneNumberHelper
    {
        public static string formatPhoneNumber(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return string.Empty;

            phone = new string(phone.Where(char.IsDigit).ToArray());

            if (phone.Length != 10)
                return phone;

            return $"{phone.Substring(0, 4)}.{phone.Substring(4, 3)}.{phone.Substring(7, 3)}";
        }
    }
}