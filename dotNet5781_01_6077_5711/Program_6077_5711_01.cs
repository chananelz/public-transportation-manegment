using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
//netanel bashan 0323056077
//chananel zaguri 206275711


namespace dotNet5781_01_6077_5711
{
    /// <summary>
    /// main program
    /// </summary>
    public class Program_6077_5711_01
    {
        enum Menu
        {
            ADD = 1, START, CHECKUP, TOTALTRAVEL, EXIT
        }; //save the choise

        /// <summary>
        /// main Function
        /// </summary>
        /// <param name="args">input from cmd</param>
        public static void Main(string[] args)
        {
            busManagement();  // this primary Function  
            Console.ReadKey();
        }

        private static void busManagement()
        {
            //***************************************************   MY VARIABLES   ******************************************************

            string licenseNum, yearTreat, monthTreat, dayTreat = "";
            int realLicenseNum = 0, year = 0, realYear = 0, realYearTreat = 0, realMonthTreat = 0, realDayTreat = 0;
            float numKm;
            DateTime lasTreatmentDate = DateTime.Now;
            BusLine myBusLine = new BusLine();
            Bus myBus = new Bus();
            Boolean NotEnd = true, licenseOk = false, found = false;
            //***************************************************************************************************************************
            while (NotEnd)
            {
                Console.WriteLine("options:\n1: add a bus\n2: start travel\n3: bus check up\n4: total travel from last treatment\n5: exit");
                string choice = "";
                int realChoice = 0;
                getInt(choice, ref realChoice);
                switch (realChoice)
                {
                    case (int)Menu.ADD:
                        ////////////////////////////////////////////////////////////////////////////////////////
                        /////                      GETING INPUT FROM USER
                        ///////////////////////////////////////////////////////////////////////////////////////

                        ///************************************ START YEAR INPUT *********************************
                        Console.WriteLine("please enter start year:");
                        //year = Console.ReadLine(); // get the year 
                        //Int32.TryParse(year, out realYear);
                        realYear = getYear(out yearTreat, out realYearTreat);
                        ///************************************ LICENCE NUMBER INPUT *********************************

                        if (realYear <= 2018)
                        {
                            while (!licenseOk)
                            {
                                Console.WriteLine("please enter 7 digit license number");
                                licenseNum = Console.ReadLine();
                                Int32.TryParse(licenseNum, out realLicenseNum);
                                if (realLicenseNum >= 1000000 && realLicenseNum < 10000000)
                                {
                                    licenseOk = true;
                                }
                                else
                                {
                                    Console.WriteLine("the number you have enered isn't 7 digit number please try again!");
                                }
                            }
                            licenseOk = false;
                        }
                        else
                        {
                            while (!licenseOk)
                            {
                                Console.WriteLine("please enter 8 digit license number");
                                licenseNum = Console.ReadLine();
                                Int32.TryParse(licenseNum, out realLicenseNum);
                                if (realLicenseNum >= 10000000 && realLicenseNum < 100000000)
                                {
                                    licenseOk = true;
                                }
                                else
                                {
                                    Console.WriteLine("the number you have enered isn't 7 digit number please try again!");
                                }
                            }
                        }

                        ///************************************ LAST TREATMENT DATE INPUT *********************************

                        Console.WriteLine("please enter last treat date:");

                        getYear(out yearTreat, out realYearTreat);
                        getMonth(out monthTreat, out realMonthTreat);
                        getDay(out dayTreat, out realDayTreat);
                        lasTreatmentDate.AddYears(realYearTreat);
                        lasTreatmentDate.AddMonths(realMonthTreat);
                        lasTreatmentDate.AddDays(realDayTreat);

                        ///************************************ CREATING BUS FROM INPUT *********************************

                        Bus myNewBus = new Bus(realLicenseNum, 0, realYear, lasTreatmentDate);
                        myBusLine.add(myNewBus);
                        break;
                    case (int)Menu.START: // choice the bus that we want to use 
                        Console.WriteLine("please enter the license number");
                        licenseNum = Console.ReadLine();
                        Int32.TryParse(licenseNum, out realLicenseNum);
                        Random r = new Random();
                        numKm = (float)r.NextDouble();
                        numKm += r.Next(1200);
                        if (!startTravel(realLicenseNum, numKm, myBusLine))
                        {
                            Console.WriteLine("can't start this travel");
                        }

                        break;
                    case (int)Menu.CHECKUP:
                        Console.WriteLine("license number:");
                        licenseNum = Console.ReadLine();
                        Int32.TryParse(licenseNum, out realLicenseNum);
                        Console.WriteLine("treatment - 1 , refueling 2 ");
                        choice = Console.ReadLine();
                        Int32.TryParse(choice, out realChoice);
                        foreach (Bus CBus in myBusLine.m_busList)
                        {
                            if (CBus.m_licenseNum == realLicenseNum)
                            {
                                switch (realChoice)
                                {

                                    case 1:
                                        CBus.m_time_Treat = DateTime.Now;
                                        Console.WriteLine("success!!");
                                        break;
                                    case 2:
                                        CBus.m_fuel = 0;
                                        Console.WriteLine("success!!");
                                        break;
                                    default:
                                        Console.WriteLine("you entered a wrong number!");
                                        break;
                                }
                            }

                        }
                        break;
                    case (int)Menu.TOTALTRAVEL:
                        Console.WriteLine("License Number:");

                        foreach (Bus CBus in myBusLine.m_busList)
                        {
                            if (CBus.m_yearStart <= 2018)
                            {
                                Console.WriteLine("{0} - {1} - {2} ", CBus.m_licenseNum / 100000, (CBus.m_licenseNum / 100) % 1000, CBus.m_licenseNum % 100);
                            }
                            else
                            {
                                Console.WriteLine("{0} - {1} - {2} ", CBus.m_licenseNum / 100000, (CBus.m_licenseNum / 1000) % 100, CBus.m_licenseNum % 1000);
                            }

                            Console.WriteLine("{0},sum travel from last treatment!", CBus.m_sum_Tr_Treat);
                        }
                        break;
                    case (int)Menu.EXIT:
                        Console.WriteLine("bye bye!!!");
                        NotEnd = false;
                        break;
                    default:
                        Console.WriteLine("wrong choice please try again!");
                        break;
                }
                int[,] p = new int[1, 3];
                int sum = p.GetLength(0);
            }

        }

        public static bool startTravel(int realLicenseNum, float numKm, BusLine myBusLine)
        {
            bool canStart = false;
            foreach (Bus CBus in myBusLine.m_busList)
            {

                if (CBus.m_licenseNum == realLicenseNum)
                {

                    //if (!((CBus.m_sum_Tr_Treat + numKm) > 20000 || (CBus.m_fuel + numKm) > 1200))
                    //{
                    //    //how do we use throw in C#
                    //    Console.WriteLine("can't do this travel - passed your limit!");
                    //}
                   if (!((CBus.m_sum_Tr_Treat + numKm) > 20000 || (CBus.m_fuel + numKm) > 1200))
                    {
                        CBus.m_sum_Tr_Treat += numKm;
                        CBus.m_fuel += numKm;
                        myBusLine.m_totalTravel += numKm;
                        CBus.m_sum_Tr += numKm;
                       // Console.WriteLine("success!!");
                    }
                    break;
                }
            }

            return canStart;
        }

        /// <summary>
        /// get license number from string to int 
        /// </summary>
        /// <param name="choice">string license number</param>
        /// <param name="realChoice">return value</param>
        /// <returns></returns>
        public static int getInt(string choice, ref int realChoice)
        {
            choice = Console.ReadLine();
            try
            {
                if (Int32.TryParse(choice, out realChoice))
                {
                    return realChoice;
                }
                else
                {
                    Console.WriteLine("enter numbers only!");
                    return getInt(choice, ref realChoice);
                }
            }
            catch
            {
                Console.WriteLine("enter numbers only!");
                return 0;
            }
        }
        /// <summary>
        /// get currect day and turn from string to int
        /// </summary>
        /// <param name="dayTreat">day treatment in string</param>
        /// <param name="realDayTreat">day treatmnet in int that will be changed</param>
        private static void getDay(out string dayTreat, out int realDayTreat)
        {
            Console.WriteLine("day:");
            dayTreat = "";
            realDayTreat = 0;
            realDayTreat = getInt(dayTreat, ref realDayTreat);
            while (realDayTreat < 0 || realDayTreat >= 32)
            {
                Console.WriteLine("ERROR!! \nday:");
                realDayTreat = getInt(dayTreat, ref realDayTreat);
            }
        }
        /// <summary>
        ///  get currect month and turn from string to int
        /// </summary>
        /// <param name="monthTreat">month treatment in string</param>
        /// <param name="realMonthTreat">month treatment in integer</param>
        private static void getMonth(out string monthTreat, out int realMonthTreat)
        {
            Console.WriteLine("month:");
            monthTreat = "";
            realMonthTreat = 0;
            realMonthTreat = getInt(monthTreat, ref realMonthTreat);
            while (realMonthTreat < 0 || realMonthTreat >= 13)
            {
                Console.WriteLine("ERROR!! \nmonth:");
                realMonthTreat = getInt(monthTreat, ref realMonthTreat);
            }
        }
        /// <summary>
        /// get currect year and turn from string to int
        /// </summary>
        /// <param name="yearTreat"></param>
        /// <param name="realYearTreat"></param>
        /// <returns></returns>
        private static int getYear(out string yearTreat, out int realYearTreat) //
        {
            Console.WriteLine("year: 1000-3000");
            yearTreat = "";
            realYearTreat = 0;
            realYearTreat = getInt(yearTreat, ref realYearTreat);
            while (realYearTreat <= 1000 || realYearTreat >= 3000)
            {
                Console.WriteLine("ERROR!! \nyear: 1000-3000");
                realYearTreat = getInt(yearTreat, ref realYearTreat);
            }
            return realYearTreat;
        }
    }
}
