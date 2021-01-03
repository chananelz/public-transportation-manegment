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
    public class Validator
    {

        #region general // כאן כתבתי כל מה שיהיה משותף כמעט לכל המחלקות

        public void GoodString(string st)
        {
            if (!string.IsNullOrEmpty(st))
                return;
            throw new ArgumentNullException("string is empty!!!");
        }


        public static void GetGoodString(string st)
        {
            if (!string.IsNullOrEmpty(st))
                return;
            throw new ArgumentNullException("string is empty!!!");
        }


        public void GoodLong(long number)
        {
            if (number > 0)
                return;
            throw new Exception("number negative!!!");
        }

        public void GoodPositiveInt(int number)
        {
            if (number > 0)
                return;
            throw new Exception("number negative!!!");
        }

        #endregion


        #region Bus

        public void GoodLicense(long licenseNumber, DateTime dateTime)
        {
            if ((licenseNumber >= 1000000 && licenseNumber < 10000000 && dateTime.Year <= 2018) || licenseNumber >= 10000000 && licenseNumber < 100000000 && (dateTime.Year > 2018 || dateTime.Year == 0))
                return;
            throw new BOBadBusIdException(licenseNumber, "license number and year don't match!");

        }

        public static void GoodTimeformat(int day, int month, int year)//check this 1200
        {
            if (day < 1 || day > 31 || month < 1 || month > 12 || year < 1950)
            {
                throw new BO.BOBusException();
            }
        }

        public static void GoodPositiveLicenseNumber(long number)
        {
            if (number > 0)
                return;
            throw new BO.BOBusException("number negative!!!");
        }

        public static void GoodPositiveStatus(int result)
        {
            if (result > 0 && result <= 3)
                return;
            throw new BO.BOBusException("number negative!!!");
        }

        public static void GoodPositiveflout(float number)
        {
            if (number > 0)
                return;
            throw new BO.BOBusException("number negative!!!");
        }


        public void GoodFuel(float fuel)//check this 1200
        {
            if (fuel >= 0 && fuel <= 1200)
                return;
            throw new BOBusException("fuel not good!!!");
        }


        public void GoodStatus(int status)
        {
            if (status >= 0 && status <= 3)
                return;
            throw new BOBusException("status not correct!!");
        }


        public void GoodFloat(float number)
        {
            if (number > 0)
                return;
            throw new BOBusException("number negative!!!");
        }

        #endregion

        #region BusTravel
        public void TimeAfter(DateTime dateTime1, DateTime dateTime2, string f, string l)
        {
            if (dateTime1 < dateTime2)
                return;
            throw new Exception(f + " doesn't come before " + l);
        }
        #endregion

        #region BusTravel + line

        public void GoodInt(long number)
        {
            if (number > 0)
                return;
            throw new Exception("number negative!!!");
        }

        #endregion

        #region BusTravel +Bus


        public void ExistLicense(long licenseNumber)
        {
            if (BL.dal.GetAllBusses().Any(bus => bus.LicenseNumber == licenseNumber))
                return;
            throw new BOBadBusIdException(licenseNumber, "licenseNumber exists!!");
        }

        public void ExistLicenseNumber(long licenseNumber)
        {
            if (!(BL.dal.GetAllBusses().Any(bus => bus.LicenseNumber == licenseNumber)))
                return;

            throw new BOBadBusIdException(licenseNumber, "licenseNumber not exists!!");


        }

        #endregion

        #region Line

        public static void GoodLinePositiveLong(long number)
        {
            if (number > 0)
                return;
            throw new BOBadLineIdException(number, "number negative!!!");
        }
        #endregion

        #region LineDeparture


        public void GoodDate(DateTime firstTime, DateTime secondTime) // מקבל שני תאריכים ובודק אם השני אחרי הראשון
        {
            if (firstTime <= secondTime)
                return;
            throw new Exception("firstTime after last time");

        }

        #endregion

        #region LineStation

        public void NumberInLineExist(long lineId, long numberInLine)//not good function
        {
            BL bl = new BL();
            var a = bl.GetAllLineStations().Count();
            if (a > numberInLine)
                return;
            throw new Exception("number in line doesn't fit!");
        }
        public void StopCodeExist(long stopCode)
        {
            BL bl = new BL();
            var a = bl.GetAllStops().Where(stop => stop.StopCode == stopCode);
            if (a.Count() != 0)
                return;
            throw new Exception("no such stop exists!");
        }

        #endregion

        #region LineStation + bus

        public void LineIdExist(long lineId)
        {
            BL bl = new BL();
            var a = bl.RequestLineById(lineId);
            if (a != null)
                return;
            throw new Exception("line doesn't exist!");
        }

        #endregion

        #region SequentialStopInfo

        #endregion

        #region Stop

        public void GoodLongitude(double longitude)
        {
            if (longitude >= 34.3 && longitude <= 35.5)
                return;
            throw new ArgumentOutOfRangeException("lonigtude not between 34.3 - 35.5");
        }//31,33.3
        public void GoodLatitude(double latitude)
        {
            if (latitude >= 31 && latitude <= 33.3)
                return;
            throw new ArgumentOutOfRangeException("latitude not between 31 - 33.3");
        }

        public static void GetGoodLongitude(double longitude)
        {
            if (longitude >= 34.3 && longitude <= 35.5)
                return;
            throw new ArgumentOutOfRangeException("lonigtude not between 34.3 - 35.5");
        }//31,33.3
        public static void GetGoodLatitude(double latitude)
        {
            if (latitude >= 31 && latitude <= 33.3)
                return;
            throw new ArgumentOutOfRangeException("latitude not between 31 - 33.3");
        }

        #endregion

        #region User

        public void UserNameExist(string userName)
        {
            if (BL.dal.GetAllUsers().Any(user => user.UserName == userName))
                throw new Exception("user name already exists!!!");
            return;
        }


        public void GoodPassword(string password)//
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

        public void GoodPermission(int permission)
        {
            if (permission == 0 || permission == 1)
                return;
            throw new Exception("permission not good!");
        }

        #endregion

        #region UserTravel

        #endregion
       
    }
}
