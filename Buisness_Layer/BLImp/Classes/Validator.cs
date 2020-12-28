using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLApi;
using BO;
using BL;


namespace BLImp
{
    static class Validator
    {
        public static void GoodLicense(long licenseNumber, DateTime dateTime)
        {
            if ((licenseNumber >= 1000000 && licenseNumber < 10000000 && dateTime.Year <= 2018) || licenseNumber >= 10000000 && licenseNumber < 100000000 && (dateTime.Year > 2018 || dateTime.Year == 0))
                return;
            throw new Exception("license number and year don't match!");

        }
        public static void ExistLicense(long licenseNumber)
        {
            if (BL.dal.GetAllBusses().Any(bus => bus.LicenseNumber == licenseNumber))
                return;
            throw new Exception("licenseNumber exists!!");
        }

        public static void GoodFuel(float fuel)//check this 1200
        {
            if (fuel >= 0 && fuel <= 1200)
                return;
            throw new Exception("fuel not good!!!");
        }
        public static void GoodStatus(int status)
        {
            if (status >= 0 && status <= 3)
                return;
            throw new Exception("status not correct!!");
        }

        public static void GoodInt(long number)
        {
            if (number > 0)
                return;
            throw new Exception("number negative!!!");
        }
        public static void GoodLong(long number)
        {
            if (number > 0)
                return;
            throw new Exception("number negative!!!");
        }
        public static void GoodFloat(float number)
        {
            if (number > 0)
                return;
            throw new Exception("number negative!!!");
        }
        public static void GoodString(string st)
        {
            if (!string.IsNullOrEmpty(st))
                return;
            throw new Exception("string is empty!!!");
        }
        public static void UserNameExist(string userName)
        {
            if (BL.dal.GetAllUsers().Any(user => user.UserName == userName))
                throw new Exception("user name already exists!!!");
            return;
        }
        public static void GoodPassword(string password)//
        {
            string exception = "";
            if (password.Length < 8 ||
                password.Length > 15) 
               exception += "length not good";

            bool containsDigits = false;
            bool containsSpecial = false;
            bool containsUpper = false;
            bool containsLower = false;

            foreach (char ch in password)
            {
                if (char.IsWhiteSpace(ch))
                {
                    exception += "password contains space";
                }

                if (char.IsDigit(ch))
                {
                    containsDigits = true;
                    continue;
                }

                if (char.IsLower(ch))
                {
                    containsLower = true;
                    continue;
                }

                if (char.IsUpper(ch))
                {
                    containsUpper = true;
                    continue;
                }

                if (char.IsPunctuation(ch))
                {
                    containsSpecial = true;
                    continue;
                }
            }
            if (!(containsDigits && containsSpecial && containsLower && containsUpper))
                exception += "password not strong enough!";

        }
        public static void GoodPermission(int permission)
        {
            if (permission == 0 || permission == 1)
                return;
            throw new Exception("permission not good!");
        }
        public static void GoodLongitude(double longitude)//34.3 - 35.5
        {
            if (longitude >= 34.3 && longitude <= 35.5)
                return;
            throw new Exception("lonigtude not between 34.3 - 35.5");
        }//31,33.3
        public static void GoodLatitude(double latitude)//31 - 33.3
        {
            if (latitude >= 31 && latitude <= 33.3)
                return;
            throw new Exception("latitude not between 31 - 33.3");
        }
    }
}
