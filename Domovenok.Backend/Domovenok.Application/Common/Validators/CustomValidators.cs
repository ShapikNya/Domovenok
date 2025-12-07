using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domovenok.Application.Common.Validators
{
    public static class CustomValidators
    {
        public static bool BeValidPhoneNumber(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return false;

            var digitsOnly = phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "");

            if (digitsOnly.Length < 10)
                return false;

            if (digitsOnly.StartsWith("+"))
            {
                return digitsOnly.Length >= 12 && digitsOnly.Length <= 15;
            }
            else
            {
                return digitsOnly.StartsWith("7") || digitsOnly.StartsWith("8")
                    ? digitsOnly.Length == 11
                    : digitsOnly.Length == 10;
            }
        }

        public static bool BeValidAge(DateTime birthDate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;

            if (birthDate.Date > today.AddYears(-age))
                age--;

            return age >= 12 && age <= 120;
        }

        public static bool BeValidUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return false;

            if (url.StartsWith("/") || url.StartsWith("~/"))
                return true;

            return Uri.TryCreate(url, UriKind.Absolute, out _);
        }
    }
}
