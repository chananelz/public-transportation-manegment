using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;
using DalApi;



namespace DS
{

    public static class DataSource
    {
        static Random r = new Random();
        #region source 
        //public static string[] Addresses
        public static List<string> User_Name = new List<string>() { "Liam", "Noah", "Oliver", "William", "Elijah", "James", "Benjamin", "Lucas", "Mason", "Ethan", "Olivia", "Emma", "Ava", "Sophia", "Isabella", "Charlotte", "Charlotte", "Charlotte", "Harper", "Evelyn" };
        public static List<string> User_Travel = new List<string>() { "Liam", "Noah", "Oliver", "William", "Elijah", "James", "Benjamin", "Lucas", "Mason", "Ethan", "Olivia", "Emma", "Ava", "Sophia", "Isabella", "Charlotte", "Charlotte", "Charlotte", "Harper", "Evelyn" };
        public static List<string> Names_Of_Stations = new List<string>() { "Bar Lev / Ben Yehuda School", "Herzl / Bilu Junction", "The surge / fishermen", "Fried / The Six Days", "A. Lod Central / Download", "Hannah Avrech / Vulcani", "Herzl / Moshe Sharet", "The boys / Eli Cohen", "Weizmann / The Boys", "The iris / anemone", "The anemone / daffodil", "Eli Cohen / Ghetto Fighters", "Shabazi / Shabbat brothers", "Shabazi / Weizmann", "Haim Bar Lev / Yitzhak Rabin Boulevard", "Lev Hasharon Mental Health Center", "Holtzman / Science", "Zrifin Camp / Club", "Herzl / Golani", "Rotem / Deganiot", "The prairie", "Introduction to the vine / Slope of the fig", "The extension / veterans", "Airports / Aliyah Authority", "Wing / Cypress", "The gang / Dov Hoz", "Beit Halevi e", "First / Route 5700", "The genius Ben Ish Chai / Ceylon", "Okashi / Levi Eshkol", "Rest and estate / Yehuda Gorodisky", "GoroDSky / Yechiel Paldi", "Derech Menachem Begin / Yaakov Hazan", "Through the Park / Rabbi Neria", "The fig / vine", "Menachem Begin / Yitzhak Rabin", "Haim Herzog / Dolev", "Shades / Cedar School", "Through the trees / oak", "Through the Trees / Menachem Begin", "Independence / Weizmann", "Weizmann / The Magic Rug", "Tzala / Coral", "Hatzav / Tzala Garden", "Pines / Levinson", "Feinberg / Schachwitz ", "Ben Gurion / Fox", "Levi Eshkol / Rabbi David Israel", "Lily / Oppenheimer", "Rabbi David Israel / Arie Dolcin", "Kronenberg / Crimson", "Jacob Freiman / Benjamin Shmotkin", "Anielewicz / Hello Fire", "Nehemiah / The Cemetery", "Yehuda Halevi / Yohanan the shoemaker", "The defense / Hish", "Kiryat Ekron / Road 411", "Rat Junction / Road 411", "Greenspan / Yigal Alon", "The Guardian / Fathers", "Moshe Sharet / Yaakov Kenner", "The fishermen / surge", "Joseph Burg / Beacons Isaac", " ", " ", " ", " ", " ", "", " ", " ", " ", " ", " ", " ", " ", " " };
        public static List<string> Areas = new List<string>() { "Jerusalem", "Tel Aviv", "Raanana", "Beit Shemes", "Beer Sheva", "Tzefat", "MaaleAdumim", "Hayfa", "Aco", "Eilat" };
        #endregion


        public static List<Bus> BusesList = new List<Bus>();
        public static List<BusTravel> BusTravelList = new List<BusTravel>();
        public static List<Line> LineList = new List<Line>();
        public static List<LineDeparture> LineDepartureList = new List<LineDeparture>();
        public static List<LineStation> LineStationList = new List<LineStation>();
        public static List<SequentialStopInfo> SequentialStopInfoList = new List<SequentialStopInfo>();
        public static List<Stop> StopList = new List<Stop>();
        public static List<User> UserList = new List<User>();
        public static List<UserTravel> UserTravelList = new List<UserTravel>();

        static DataSource()
        {
            initBusesList();
            initStopList();
            initLineList();
            initBusTravelList();
            initLineDepartureList();
            initLineStationList();
            initSequentialStopInfoList();
            initUserList();
            initUserTravelList();
        }

        #region Bus_Travel //++
        static void initBusTravelList()
        {
            #region Bus_Travel # 1
            BusTravelList.Add(new BusTravel()
            {
                Valid = true,
                Id = Configuration.Bus_TravelCounter,
                LicenseNumber = 1000000,
                LineId = 10,
                FormalDepartureTime = new DateTime(2020, 12, 1, 06, 00, 0),
                RealDepartureTime = new DateTime(2020, 12, 1, 06, 05, 0),
                LastPassedStop = 570,
                LastPassedStopTime = new DateTime(2020, 12, 1, 06, 05, 0),
                NextStopTime = new DateTime(2020, 12, 1, 06, 8, 30),
                DriverId = User_Name[0]
            });
            #endregion

            #region Bus_Travel # 2

            BusTravelList.Add(new BusTravel()
            {
                Valid = true,
                Id = Configuration.Bus_TravelCounter,
                LicenseNumber = 1000001,
                LineId = 10,
                FormalDepartureTime = new DateTime(2020, 12, 2, 06, 30, 0),
                RealDepartureTime = new DateTime(2020, 12, 2, 06, 35, 0),
                LastPassedStop = 570,
                LastPassedStopTime = new DateTime(2020, 12, 2, 06, 35, 0),
                NextStopTime = new DateTime(2020, 12, 2, 06, 38, 35),
                DriverId = User_Name[1]
            });

            #endregion

            #region Bus_Travel # 3
            BusTravelList.Add(new BusTravel()
            {
                Valid = true,
                Id = Configuration.Bus_TravelCounter,
                LicenseNumber = 1000002,
                LineId = 10,
                FormalDepartureTime = new DateTime(2020, 12, 3, 07, 00, 0),
                RealDepartureTime = new DateTime(2020, 12, 3, 07, 05, 0),
                LastPassedStop = 570,
                LastPassedStopTime = new DateTime(2020, 3, 20, 07, 05, 0),
                NextStopTime = new DateTime(2020, 12, 3, 07, 8, 30),
                DriverId = User_Name[2]
            });
            #endregion

            #region Bus_Travel # 4
            BusTravelList.Add(new BusTravel()
            {
                Valid = true,
                Id = Configuration.Bus_TravelCounter,
                LicenseNumber = 1000003,
                LineId = 11,
                FormalDepartureTime = new DateTime(2020, 12, 4, 06, 00, 0),
                RealDepartureTime = new DateTime(2020, 12, 4, 06, 05, 0),
                LastPassedStop = 579,
                LastPassedStopTime = new DateTime(2020, 12, 4, 06, 05, 0),
                NextStopTime = new DateTime(2020, 12, 4, 06, 8, 30),
                DriverId = User_Name[3]
            });
            #endregion

            #region Bus_Travel # 5
            BusTravelList.Add(new BusTravel()
            {
                Valid = true,
                Id = Configuration.Bus_TravelCounter,
                LicenseNumber = 1000004,
                LineId = 11,
                FormalDepartureTime = new DateTime(2020, 12, 5, 06, 30, 0),
                RealDepartureTime = new DateTime(2020, 12, 5, 06, 35, 0),
                LastPassedStop = 579,
                LastPassedStopTime = new DateTime(2020, 12, 5, 06, 35, 0),
                NextStopTime = new DateTime(2020, 12, 20, 5, 38, 35),
                DriverId = User_Name[4]
            });
            #endregion

            #region Bus_Travel # 6
            BusTravelList.Add(new BusTravel()
            {
                Valid = true,
                Id = Configuration.Bus_TravelCounter,
                LicenseNumber = 1000005,
                LineId = 11,
                FormalDepartureTime = new DateTime(2020, 12, 6, 07, 00, 0),
                RealDepartureTime = new DateTime(2020, 12, 6, 07, 05, 0),
                LastPassedStop = 579,
                LastPassedStopTime = new DateTime(2020, 12, 6, 07, 05, 0),
                NextStopTime = new DateTime(2020, 12, 6, 07, 8, 30),
                DriverId = User_Name[5]
            });
            #endregion

            #region Bus_Travel # 7
            BusTravelList.Add(new BusTravel()
            {
                Valid = true,
                Id = Configuration.Bus_TravelCounter,
                LicenseNumber = 1000006,
                LineId = 12,
                FormalDepartureTime = new DateTime(2020, 12, 7, 06, 00, 0),
                RealDepartureTime = new DateTime(2020, 12, 7, 06, 05, 0),
                LastPassedStop = 585,
                LastPassedStopTime = new DateTime(2020, 12, 7, 06, 05, 0),
                NextStopTime = new DateTime(2020, 12, 7, 06, 8, 30),
                DriverId = User_Name[6]
            });
            #endregion

            #region Bus_Travel # 8
            BusTravelList.Add(new BusTravel()
            {
                Valid = true,
                Id = Configuration.Bus_TravelCounter,
                LicenseNumber = 1000007,
                LineId = 12,
                FormalDepartureTime = new DateTime(2020, 12, 8, 06, 30, 0),
                RealDepartureTime = new DateTime(2020, 12, 8, 06, 35, 0),
                LastPassedStop = 585,
                LastPassedStopTime = new DateTime(2020, 12, 8, 06, 35, 0),
                NextStopTime = new DateTime(2020, 12, 8, 06, 38, 35),
                DriverId = User_Name[7]
            });
            #endregion

            #region Bus_Travel # 9
            BusTravelList.Add(new BusTravel()
            {
                Valid = true,
                Id = Configuration.Bus_TravelCounter,
                LicenseNumber = 1000008,
                LineId = 12,
                FormalDepartureTime = new DateTime(2020, 12, 9, 07, 00, 0),
                RealDepartureTime = new DateTime(2020, 12, 9, 07, 05, 0),
                LastPassedStop = 585,
                LastPassedStopTime = new DateTime(2020, 12, 9, 07, 05, 0),
                NextStopTime = new DateTime(2020, 12, 9, 07, 8, 30),
                DriverId = User_Name[0]
            });
            #endregion

            #region Bus_Travel # 10
            BusTravelList.Add(new BusTravel()
            {
                Valid = true,
                Id = Configuration.Bus_TravelCounter,
                LicenseNumber = 1000009,
                LineId = 13,
                FormalDepartureTime = new DateTime(2020, 12, 10, 06, 00, 0),
                RealDepartureTime = new DateTime(2020, 12, 10, 06, 05, 0),
                LastPassedStop = 585,
                LastPassedStopTime = new DateTime(2020, 12, 10, 06, 05, 0),
                NextStopTime = new DateTime(2020, 12, 10, 06, 8, 30),
                DriverId = User_Name[1]
            });
            #endregion

            #region Bus_Travel # 11

            BusTravelList.Add(new BusTravel()
            {
                Valid = true,
                Id = Configuration.Bus_TravelCounter,
                LicenseNumber = 1000010,
                LineId = 13,
                FormalDepartureTime = new DateTime(2020, 12, 11, 06, 30, 0),
                RealDepartureTime = new DateTime(2020, 12, 11, 06, 35, 0),
                LastPassedStop = 585,
                LastPassedStopTime = new DateTime(2020, 12, 11, 06, 35, 0),
                NextStopTime = new DateTime(2020, 12, 11, 06, 38, 35),
                DriverId = User_Name[2]
            });
            #endregion

            #region Bus_Travel # 12
            BusTravelList.Add(new BusTravel()
            {
                Valid = true,
                Id = Configuration.Bus_TravelCounter,
                LicenseNumber = 1000011,
                LineId = 13,
                FormalDepartureTime = new DateTime(2020, 12, 12, 07, 00, 0),
                RealDepartureTime = new DateTime(2020, 12, 12, 07, 05, 0),
                LastPassedStop = 585,
                LastPassedStopTime = new DateTime(2020, 12, 12, 07, 05, 0),
                NextStopTime = new DateTime(2020, 12, 12, 07, 8, 30),
                DriverId = User_Name[3]
            });
            #endregion

            #region Bus_Travel # 13
            BusTravelList.Add(new BusTravel()
            {
                Valid = true,
                Id = Configuration.Bus_TravelCounter,
                LicenseNumber = 1000012,
                LineId = 18,
                FormalDepartureTime = new DateTime(2020, 12, 13, 16, 00, 0),
                RealDepartureTime = new DateTime(2020, 12, 13, 16, 05, 0),
                LastPassedStop = 570,
                LastPassedStopTime = new DateTime(2020, 12, 13, 16, 05, 0),
                NextStopTime = new DateTime(2020, 12, 13, 16, 8, 30),
                DriverId = User_Name[4]
            });
            #endregion

            #region Bus_Travel # 14

            BusTravelList.Add(new BusTravel()
            {
                Valid = true,
                Id = Configuration.Bus_TravelCounter,
                LicenseNumber = 1000013,
                LineId = 18,
                FormalDepartureTime = new DateTime(2020, 12, 14, 16, 30, 0),
                RealDepartureTime = new DateTime(2020, 12, 14, 16, 35, 0),
                LastPassedStop = 570,
                LastPassedStopTime = new DateTime(2020, 12, 14, 16, 35, 0),
                NextStopTime = new DateTime(2020, 12, 14, 16, 38, 35),
                DriverId = User_Name[5]
            });

            #endregion

            #region Bus_Travel # 15
            BusTravelList.Add(new BusTravel()
            {
                Valid = true,
                Id = Configuration.Bus_TravelCounter,
                LicenseNumber = 1000014,
                LineId = 18,
                FormalDepartureTime = new DateTime(2020, 12, 15, 17, 00, 0),
                RealDepartureTime = new DateTime(2020, 12, 15, 17, 05, 0),
                LastPassedStop = 570,
                LastPassedStopTime = new DateTime(2020, 12, 15, 17, 05, 0),
                NextStopTime = new DateTime(2020, 12, 15, 17, 8, 30),
                DriverId = User_Name[6]
            });
            #endregion

            #region Bus_Travel # 16
            BusTravelList.Add(new BusTravel()
            {
                Valid = true,
                Id = Configuration.Bus_TravelCounter,
                LicenseNumber = 1000015,
                LineId = 17,
                FormalDepartureTime = new DateTime(2020, 12, 16, 16, 00, 0),
                RealDepartureTime = new DateTime(2020, 12, 16, 16, 05, 0),
                LastPassedStop = 579,
                LastPassedStopTime = new DateTime(2020, 12, 16, 16, 05, 0),
                NextStopTime = new DateTime(2020, 12, 16, 16, 8, 30),
                DriverId = User_Name[7]
            });
            #endregion

            #region Bus_Travel # 17
            BusTravelList.Add(new BusTravel()
            {
                Valid = true,
                Id = Configuration.Bus_TravelCounter,
                LicenseNumber = 1000016,
                LineId = 17,
                FormalDepartureTime = new DateTime(2020, 12, 17, 16, 30, 0),
                RealDepartureTime = new DateTime(2020, 12, 17, 16, 35, 0),
                LastPassedStop = 579,
                LastPassedStopTime = new DateTime(2020, 12, 17, 16, 35, 0),
                NextStopTime = new DateTime(2020, 12, 17, 16, 38, 35),
                DriverId = User_Name[0]
            });
            #endregion

            #region Bus_Travel # 18
            BusTravelList.Add(new BusTravel()
            {
                Valid = true,
                Id = Configuration.Bus_TravelCounter,
                LicenseNumber = 1000017,
                LineId = 17,
                FormalDepartureTime = new DateTime(2020, 12, 18, 17, 00, 0),
                RealDepartureTime = new DateTime(2020, 12, 18, 17, 05, 0),
                LastPassedStop = 579,
                LastPassedStopTime = new DateTime(2020, 12, 18, 17, 05, 0),
                NextStopTime = new DateTime(2020, 12, 18, 17, 8, 30),
                DriverId = User_Name[1]
            });
            #endregion

            #region Bus_Travel # 19
            BusTravelList.Add(new BusTravel()
            {
                Valid = true,
                Id = Configuration.Bus_TravelCounter,
                LicenseNumber = 1000018,
                LineId = 15,
                FormalDepartureTime = new DateTime(2020, 12, 19, 16, 00, 0),
                RealDepartureTime = new DateTime(2020, 12, 19, 16, 05, 0),
                LastPassedStop = 585,
                LastPassedStopTime = new DateTime(2020, 12, 19, 16, 05, 0),
                NextStopTime = new DateTime(2020, 12, 19, 16, 8, 30),
                DriverId = User_Name[2]
            });
            #endregion

            #region Bus_Travel # 20
            BusTravelList.Add(new BusTravel()
            {
                Valid = true,
                Id = Configuration.Bus_TravelCounter,
                LicenseNumber = 1000019,
                LineId = 15,
                FormalDepartureTime = new DateTime(2020, 12, 20, 16, 30, 0),
                RealDepartureTime = new DateTime(2020, 12, 20, 16, 35, 0),
                LastPassedStop = 585,
                LastPassedStopTime = new DateTime(2020, 12, 20, 16, 35, 0),
                NextStopTime = new DateTime(2020, 12, 20, 16, 38, 35),
                DriverId = User_Name[3]
            });
            #endregion

            #region Bus_Travel # 21
            BusTravelList.Add(new BusTravel()
            {
                Valid = true,
                Id = Configuration.Bus_TravelCounter,
                LicenseNumber = 1000020,
                LineId = 15,
                FormalDepartureTime = new DateTime(2020, 12, 21, 17, 00, 0),
                RealDepartureTime = new DateTime(2020, 12, 21, 17, 05, 0),
                LastPassedStop = 585,
                LastPassedStopTime = new DateTime(2020, 12, 21, 17, 05, 0),
                NextStopTime = new DateTime(2020, 12, 21, 17, 8, 30),
                DriverId = User_Name[4]
            });
            #endregion


        }

        #endregion


        #region initBus //++
       
        static void initBusesList()
        {

            #region Bus # 1
            BusesList.Add(new Bus()
            {
                Valid = true,
                LicenseNumber = Configuration.BusCounter,
                LicenseDate = new DateTime(2020, 2, 1),
                KM = (float)r.NextDouble() + r.Next(1, 1199),
                Fuel = r.Next(0, 1199) + (float)r.NextDouble(),
                Status = status.TRAVELING
            });
            #endregion

            #region Bus # 2
            BusesList.Add(new Bus()
            {
                Valid = true,
                LicenseNumber = Configuration.BusCounter,
                LicenseDate = new DateTime(2020, 2, 2),
                KM = (float)r.NextDouble() + r.Next(1, 1199),
                Fuel = r.Next(0, 1199) + (float)r.NextDouble(),
                Status = status.TRAVELING
            });
            #endregion

            #region Bus # 3
            BusesList.Add(new Bus()
            {
                Valid = true,
                LicenseNumber = Configuration.BusCounter,
                LicenseDate = new DateTime(2020, 2, 3),
                KM = (float)r.NextDouble() + r.Next(1, 1199),
                Fuel = r.Next(0, 1199) + (float)r.NextDouble(),
                Status = status.TRAVELING
            });
            #endregion

            #region Bus # 4
            BusesList.Add(new Bus()
            {
                Valid = true,
                LicenseNumber = Configuration.BusCounter,
                LicenseDate = new DateTime(2020, 2, 4),
                KM = (float)r.NextDouble() + r.Next(1, 1199),
                Fuel = r.Next(0, 1199) + (float)r.NextDouble(),
                Status = status.TRAVELING
            });
            #endregion

            #region Bus # 5
            BusesList.Add(new Bus()
            {
                Valid = true,
                LicenseNumber = Configuration.BusCounter,
                LicenseDate = new DateTime(2020, 2, 5),
                KM = (float)r.NextDouble() + r.Next(1, 1199),
                Fuel = r.Next(0, 1199) + (float)r.NextDouble(),
                Status = status.TRAVELING
            });
            #endregion

            #region Bus # 6
            BusesList.Add(new Bus()
            {
                Valid = true,
                LicenseNumber = Configuration.BusCounter,
                LicenseDate = new DateTime(2020, 2, 6),
                KM = (float)r.NextDouble() + r.Next(1, 1199),
                Fuel = r.Next(0, 1199) + (float)r.NextDouble(),
                Status = status.TRAVELING
            });
            #endregion

            #region Bus # 7
            BusesList.Add(new Bus()
            {
                Valid = true,
                LicenseNumber = Configuration.BusCounter,
                LicenseDate = new DateTime(2020, 2, 7),
                KM = (float)r.NextDouble() + r.Next(1, 1199),
                Fuel = r.Next(0, 1199) + (float)r.NextDouble(),
                Status = status.TRAVELING
            });
            #endregion

            #region Bus # 8
            BusesList.Add(new Bus()
            {
                Valid = true,
                LicenseNumber = Configuration.BusCounter,
                LicenseDate = new DateTime(2020, 2, 8),
                KM = (float)r.NextDouble() + r.Next(1, 1199),
                Fuel = r.Next(0, 1199) + (float)r.NextDouble(),
                Status = status.TRAVELING
            });
            #endregion

            #region Bus # 9
            BusesList.Add(new Bus()
            {
                Valid = true,
                LicenseNumber = Configuration.BusCounter,
                LicenseDate = new DateTime(2020, 2, 9),
                KM = (float)r.NextDouble() + r.Next(1, 1199),
                Fuel = r.Next(0, 1199) + (float)r.NextDouble(),
                Status = status.TRAVELING
            });
            #endregion

            #region Bus # 10
            BusesList.Add(new Bus()
            {
                Valid = true,
                LicenseNumber = Configuration.BusCounter,
                LicenseDate = new DateTime(2020, 2, 10),
                KM = (float)r.NextDouble() + r.Next(1, 1199),
                Fuel = r.Next(0, 1199) + (float)r.NextDouble(),
                Status = status.TRAVELING
            });
            #endregion

            #region Bus # 11
            BusesList.Add(new Bus()
            {
                Valid = true,
                LicenseNumber = Configuration.BusCounter,
                LicenseDate = new DateTime(2020, 2, 11),
                KM = (float)r.NextDouble() + r.Next(1, 1199),
                Fuel = r.Next(0, 1199) + (float)r.NextDouble(),
                Status = status.TRAVELING
            });
            #endregion

            #region Bus # 12
            BusesList.Add(new Bus()
            {
                Valid = true,
                LicenseNumber = Configuration.BusCounter,
                LicenseDate = new DateTime(2020, 2, 12),
                KM = (float)r.NextDouble() + r.Next(1, 1199),
                Fuel = r.Next(0, 1199) + (float)r.NextDouble(),
                Status = status.TRAVELING
            });
            #endregion

            #region Bus # 13
            BusesList.Add(new Bus()
            {
                Valid = true,
                LicenseNumber = Configuration.BusCounter,
                LicenseDate = new DateTime(2020, 2, 13),
                KM = (float)r.NextDouble() + r.Next(1, 1199),
                Fuel = r.Next(0, 1199) + (float)r.NextDouble(),
                Status = status.TRAVELING
            });
            #endregion

            #region Bus # 14
            BusesList.Add(new Bus()
            {
                Valid = true,
                LicenseNumber = Configuration.BusCounter,
                LicenseDate = new DateTime(2020, 2, 14),
                KM = (float)r.NextDouble() + r.Next(1, 1199),
                Fuel = r.Next(0, 1199) + (float)r.NextDouble(),
                Status = status.TRAVELING
            });
            #endregion

            #region Bus # 15
            BusesList.Add(new Bus()
            {
                Valid = true,
                LicenseNumber = Configuration.BusCounter,
                LicenseDate = new DateTime(2020, 2, 15),
                KM = (float)r.NextDouble() + r.Next(1, 1199),
                Fuel = r.Next(0, 1199) + (float)r.NextDouble(),
                Status = status.TRAVELING
            });
            #endregion

            #region Bus # 16
            BusesList.Add(new Bus()
            {
                Valid = true,
                LicenseNumber = Configuration.BusCounter,
                LicenseDate = new DateTime(2020, 2, 16),
                KM = (float)r.NextDouble() + r.Next(1, 1199),
                Fuel = r.Next(0, 1199) + (float)r.NextDouble(),
                Status = status.TRAVELING
            });
            #endregion

            #region Bus # 17
            BusesList.Add(new Bus()
            {
                Valid = true,
                LicenseNumber = Configuration.BusCounter,
                LicenseDate = new DateTime(2020, 2, 17),
                KM = (float)r.NextDouble() + r.Next(1, 1199),
                Fuel = r.Next(0, 1199) + (float)r.NextDouble(),
                Status = status.TRAVELING
            });
            #endregion

            #region Bus # 18
            BusesList.Add(new Bus()
            {
                Valid = true,
                LicenseNumber = Configuration.BusCounter,
                LicenseDate = new DateTime(2020, 2, 18),
                KM = (float)r.NextDouble() + r.Next(1, 1199),
                Fuel = r.Next(0, 1199) + (float)r.NextDouble(),
                Status = status.TRAVELING
            });
            #endregion

            #region Bus # 19
            BusesList.Add(new Bus()
            {
                Valid = true,
                LicenseNumber = Configuration.BusCounter,
                LicenseDate = new DateTime(2020, 2, 19),
                KM = (float)r.NextDouble() + r.Next(1, 1199),
                Fuel = r.Next(0, 1199) + (float)r.NextDouble(),
                Status = status.TRAVELING
            });
            #endregion

            #region Bus # 20
            BusesList.Add(new Bus()
            {
                Valid = true,
                LicenseNumber = Configuration.BusCounter,
                LicenseDate = new DateTime(2020, 2, 20),
                KM = (float)r.NextDouble() + r.Next(1, 1199),
                Fuel = r.Next(0, 1199) + (float)r.NextDouble(),
                Status = status.TRAVELING
            });
            #endregion

            #region Bus # 21
            BusesList.Add(new Bus()
            {
                Valid = true,
                LicenseNumber = Configuration.BusCounter,
                LicenseDate = new DateTime(2020, 2, 21),
                KM = (float)r.NextDouble() + r.Next(1, 1199),
                Fuel = r.Next(0, 1199) + (float)r.NextDouble(),
                Status = status.TRAVELING
            });
            #endregion

            #region Bus # 22
            BusesList.Add(new Bus()
            {
                Valid = true,
                LicenseNumber = Configuration.BusCounter,
                LicenseDate = new DateTime(2020, 4, 22),
                KM = (float)r.NextDouble() + r.Next(1, 1199),
                Fuel = r.Next(0, 1199) + (float)r.NextDouble(),
                Status = status.REFULING
            });
            #endregion

            #region Bus # 23
            BusesList.Add(new Bus()
            {
                Valid = true,
                LicenseNumber = Configuration.BusCounter,
                LicenseDate = new DateTime(2020, 4, 23),
                KM = (float)r.NextDouble() + r.Next(1, 1199),
                Fuel = r.Next(0, 1199) + (float)r.NextDouble(),
                Status = status.REFULING
            });
            #endregion

            #region Bus # 24
            BusesList.Add(new Bus()
            {
                Valid = true,
                LicenseNumber = Configuration.BusCounter,
                LicenseDate = new DateTime(2020, 4, 24),
                KM = (float)r.NextDouble() + r.Next(1, 1199),
                Fuel = r.Next(0, 1199) + (float)r.NextDouble(),
                Status = status.TREATING
            });
            #endregion


            #region Bus # 25
            BusesList.Add(new Bus()
            {
                Valid = true,
                LicenseNumber = Configuration.BusCounter,
                LicenseDate = new DateTime(2020, 4, 25),
                KM = (float)r.NextDouble() + r.Next(1, 1199),
                Fuel = r.Next(0, 1199) + (float)r.NextDouble(),
                Status = status.TREATING
            });
            #endregion


            #region Bus # 26
            BusesList.Add(new Bus()
            {
                Valid = true,
                LicenseNumber = Configuration.BusCounter,
                LicenseDate = new DateTime(2020, 4, 26),
                KM = (float)r.NextDouble() + r.Next(1, 1199),
                Fuel = r.Next(0, 1199) + (float)r.NextDouble(),
                Status = status.READY_FOR_DRIVE
            });
            #endregion

            #region Bus # 27
            BusesList.Add(new Bus()
            {
                Valid = true,
                LicenseNumber = Configuration.BusCounter,
                LicenseDate = new DateTime(2020, 4, 27),
                KM = (float)r.NextDouble() + r.Next(1, 1199),
                Fuel = r.Next(0, 1199) + (float)r.NextDouble(),
                Status = status.READY_FOR_DRIVE
            });
            #endregion


            #region Bus # 28
            BusesList.Add(new Bus()
            {
                Valid = true,
                LicenseNumber = Configuration.BusCounter,
                LicenseDate = new DateTime(2020, 3, 24),
                KM = (float)r.NextDouble() + r.Next(1, 1199),
                Fuel = r.Next(0, 1199) + (float)r.NextDouble(),
                Status = status.READY_FOR_DRIVE
            });
            #endregion


            #region Bus # 29
            BusesList.Add(new Bus()
            {
                Valid = true,
                LicenseNumber = Configuration.BusCounter,
                LicenseDate = new DateTime(2020, 3, 25),
                KM = (float)r.NextDouble() + r.Next(1, 1199),
                Fuel = r.Next(0, 1199) + (float)r.NextDouble(),
                Status = status.READY_FOR_DRIVE
            });
            #endregion


            #region Bus # 30
            BusesList.Add(new Bus()
            {
                Valid = true,
                LicenseNumber = Configuration.BusCounter,
                LicenseDate = new DateTime(2020, 3, 26),
                KM = (float)r.NextDouble() + r.Next(1, 1199),
                Fuel = r.Next(0, 1199) + (float)r.NextDouble(),
                Status = status.READY_FOR_DRIVE
            });
            #endregion

            #region Bus # 31
            BusesList.Add(new Bus()
            {
                Valid = true,
                LicenseNumber = Configuration.BusCounter,
                LicenseDate = new DateTime(2020, 3, 27),
                KM = (float)r.NextDouble() + r.Next(1, 1199),
                Fuel = r.Next(0, 1199) + (float)r.NextDouble(),
                Status = status.READY_FOR_DRIVE
            });
            #endregion


        }
        #endregion

        #region initStop //++
        static void initStopList()
        {
            #region Stop #1
            StopList.Add(new Stop()
            {
                Valid = true,
                StopCode = Configuration.StopCounter,
                Latitude = 31.8822308,
                Longitude = 35.2385864,
                StopName = "Tel Tsion Terminal",
                Address = "Tel Zion Terminal Street"
            });
            #endregion

            #region Stop #2
            StopList.Add(new Stop()
            {
                Valid = true,
                StopCode = Configuration.StopCounter,
                Latitude = 31.8813897,
                Longitude = 35.2381133,
                StopName = "Ahavat Israel D",
                Address = "Tel Zion Ahavat Israel Street"
            });
            #endregion

            #region Stop #3
            StopList.Add(new Stop()
            {
                Valid = true,
                StopCode = Configuration.StopCounter,
                Latitude = 31.8809719,
                Longitude = 35.2382622,
                StopName = "Ahavat Israel B",
                Address = "Tel Zion Ahavat Israel Street"
            });
            #endregion

            #region Stop #4
            StopList.Add(new Stop()
            {
                Valid = true,
                StopCode = Configuration.StopCounter,
                Latitude = 31.8800756,
                Longitude = 35.2386322,
                StopName = "Ahavat Israel/Minhat Aharon",
                Address = "Tel Zion Ahavat Israel Street"
            });
            #endregion

            #region Stop #5
            StopList.Add(new Stop()
            {
                Valid = true,
                StopCode = Configuration.StopCounter,
                Latitude = 31.8791467,
                Longitude = 35.2381019,
                StopName = "Ahavat Israel G",
                Address = "Tel Zion Ahavat Israel Street"
            });
            #endregion

            #region Stop #6
            StopList.Add(new Stop()
            {
                Valid = true,
                StopCode = Configuration.StopCounter,
                Latitude = 31.8789331,
                Longitude = 35.2380067,
                StopName = "Club/Ahavat Israel",
                Address = "Tel Zion Ahavat Israel Street"
            });
            #endregion

            #region Stop #7
            StopList.Add(new Stop()
            {
                Valid = true,
                StopCode = Configuration.StopCounter,
                Latitude = 31.8776150,
                Longitude = 35.2373886,
                StopName = "Ahavat Israel A",
                Address = "Tel Zion Ahavat Israel Street"
            });
            #endregion

            #region Stop #8
            StopList.Add(new Stop()
            {
                Valid = true,
                StopCode = Configuration.StopCounter,
                Latitude = 31.8775711,
                Longitude = 35.2381517,
                StopName = "Ahavat Israel Vav",
                Address = "Tel Zion Ahavat Israel Street"
            });
            #endregion

            #region Stop #9
            StopList.Add(new Stop()
            {
                Valid = true,
                StopCode = Configuration.StopCounter,
                Latitude = 31.8793372,
                Longitude = 35.2399406,
                StopName = "Ahavat Israel/Kehilat Ya'akov",
                Address = "Tel Zion Ahavat Israel Street"
            });
            #endregion

            #region Stop #10
            StopList.Add(new Stop()
            {
                Valid = true,
                StopCode = Configuration.StopCounter,
                Latitude = 31.8805753,
                Longitude = 35.2407075,
                StopName = "Ahavat Israel/Ma'alot HaHokhma",
                Address = "Tel Zion Ahavat Israel Street"
            });
            #endregion

            #region Stop #11
            StopList.Add(new Stop()
            {
                Valid = true,
                StopCode = Configuration.StopCounter,
                Latitude = 31.8783017,
                Longitude = 35.2398606,
                StopName = "Makor Baruch/Ahavat Israel",
                Address = "Tel Zion Makor Baruch Street"
            });
            #endregion

            #region Stop #12
            StopList.Add(new Stop()
            {
                Valid = true,
                StopCode = Configuration.StopCounter,
                Latitude = 31.8771917,
                Longitude = 35.2401275,
                StopName = "Makor Baruch 4",
                Address = "Tel Zion Makor Baruch Street"
            });
            #endregion

            #region Stop #13
            StopList.Add(new Stop()
            {
                Valid = true,
                StopCode = Configuration.StopCounter,
                Latitude = 31.8768444,
                Longitude = 35.2398147,
                StopName = "Makor Baruch 3",
                Address = "Tel Zion Makor Baruch Street"
            });
            #endregion

            #region Stop #14
            StopList.Add(new Stop()
            {
                Valid = true,
                StopCode = Configuration.StopCounter,
                Latitude = 31.8768006,
                Longitude = 35.2391167,
                StopName = "Makor Baruch 2",
                Address = "Tel Zion Makor Baruch Street"
            });
            #endregion

            #region Stop #15
            StopList.Add(new Stop()
            {
                Valid = true,
                StopCode = Configuration.StopCounter,
                Latitude = 31.8782464,
                Longitude = 35.2398644,
                StopName = "Makor Baruch/Ahavat Israel",
                Address = "Tel Zion Makor Baruch Street"
            });
            #endregion

            #region Stop #16
            StopList.Add(new Stop()
            {
                Valid = true,
                StopCode = Configuration.StopCounter,
                Latitude = 31.8845539,
                Longitude = 35.2412986,
                StopName = "Caravans Quarter",
                Address = "Kokhav Ya'akov Caravans Quarter"
            });
            #endregion

            #region Stop #17
            StopList.Add(new Stop()
            {
                Valid = true,
                StopCode = Configuration.StopCounter,
                Latitude = 31.8797475,
                Longitude = 35.2430458,
                StopName = "Kokhav Ya'akov Road/Simhat Olam",
                Address = "Kochav Yaakov Simchat Olam Street"
            });
            #endregion

            #region Stop #18
            StopList.Add(new Stop()
            {
                Valid = true,
                StopCode = Configuration.StopCounter,
                Latitude = 31.8796500,
                Longitude = 35.2438775,
                StopName = "Simhat Olam/Or Hadash",
                Address = "Kochav Yaakov Simchat Olam Street"
            });
            #endregion

            #region Stop #19
            StopList.Add(new Stop()
            {
                Valid = true,
                StopCode = Configuration.StopCounter,
                Latitude = 31.8798886,
                Longitude = 35.2443925,
                StopName = "Simhat Olam/Abir Ya'akov Boulevard",
                Address = "Kochav Yaakov Simchat Olam Street"
            });
            #endregion

            #region Stop #20
            StopList.Add(new Stop()
            {
                Valid = true,
                StopCode = Configuration.StopCounter,
                Latitude = 31.8797817,
                Longitude = 35.2452964,
                StopName = "Abir Ya'akov/Avne Hefets",
                Address = "Kochav Yaakov Avne Hefets Street"
            });
            #endregion

            #region Stop #21
            StopList.Add(new Stop()
            {
                Valid = true,
                StopCode = Configuration.StopCounter,
                Latitude = 31.8800658,
                Longitude = 35.2469825,
                StopName = "Mishkenot Haro'im/Avne Hefets",
                Address = "Kochav Yaakov Avne Hefets Street"
            });
            #endregion

            #region Stop #22
            StopList.Add(new Stop()
            {
                Valid = true,
                StopCode = Configuration.StopCounter,
                Latitude = 31.8791600,
                Longitude = 35.2480431,
                StopName = "Mishkenot Haro'im/Shalom River",
                Address = "Kochav Yaakov Shalom River Street"
            });
            #endregion

            #region Stop #23
            StopList.Add(new Stop()
            {
                Valid = true,
                StopCode = Configuration.StopCounter,
                Latitude = 31.8783397,
                Longitude = 35.2478256,
                StopName = "Abir Ya'akov/Ma'ayane HaYeshua",
                Address = "Kochav Yaakov Ma'ayane HaYeshua Street"
            });
            #endregion

            #region Stop #24
            StopList.Add(new Stop()
            {
                Valid = true,
                StopCode = Configuration.StopCounter,
                Latitude = 31.8771572,
                Longitude = 35.2470550,
                StopName = "Kokhav Ya'akov Road",
                Address = "Kochav Yaakov"
            });
            #endregion

            #region Stop #25
            StopList.Add(new Stop()
            {
                Valid = true,
                StopCode = Configuration.StopCounter,
                Latitude = 31.8729000,
                Longitude = 35.2593497,
                StopName = "Gas Station/Kokhav Ya'akov",
                Address = "Kochav Yaakov"
            });
            #endregion

            #region Stop #26
            StopList.Add(new Stop()
            {
                Valid = true,
                StopCode = Configuration.StopCounter,
                Latitude = 31.8962994,
                Longitude = 35.2248383,
                StopName = "Psagot Center",
                Address = "Psagot Nevo Street"
            });
            #endregion

            #region Stop #27
            StopList.Add(new Stop()
            {
                Valid = true,
                StopCode = Configuration.StopCounter,
                Latitude = 31.8987694,
                Longitude = 35.2253494,
                StopName = "Mateh Binyamin Regional Council",
                Address = "Mateh Binyamin Regional Council"
            });
            #endregion

            #region Stop #28
            StopList.Add(new Stop()
            {
                Valid = true,
                StopCode = Configuration.StopCounter,
                Latitude = 31.9012108,
                Longitude = 35.2226714,
                StopName = "Psagot/Ashkubiyot",
                Address = "Psagot Ashkubiyot Street"
            });
            #endregion

            #region Stop #29
            StopList.Add(new Stop()
            {
                Valid = true,
                StopCode = Configuration.StopCounter,
                Latitude = 31.9029294,
                Longitude = 35.2231369,
                StopName = "Psagot Exit",
                Address = "Psagot Ashkubiyot Street"
            });
            #endregion

            #region Stop #30
            StopList.Add(new Stop()
            {
                Valid = true,
                StopCode = Configuration.StopCounter,
                Latitude = 31.8648664,
                Longitude = 35.2619172,
                StopName = "Sha'ar Binyamin Terminal/Alighting",
                Address = "Sha'ar Binyamin hamasger"
            });
            #endregion

            #region Stop #31
            StopList.Add(new Stop()
            {
                Valid = true,
                StopCode = Configuration.StopCounter,
                Latitude = 31.8649083,
                Longitude = 35.2614058,
                StopName = "Sha'ar Binyamin Industrial Zone",
                Address = "Sha'ar Binyamin hamasger street"
            });
            #endregion

            #region Stop #32
            StopList.Add(new Stop()
            {
                Valid = true,
                StopCode = Configuration.StopCounter,
                Latitude = 31.8648853,
                Longitude = 35.2616844,
                StopName = "Sha'ar Binyamin Terminal/Boarding",
                Address = "Sha'ar Binyamin hamasger street"
            });
            #endregion

            #region Stop #33
            StopList.Add(new Stop()
            {
                Valid = true,
                StopCode = Configuration.StopCounter,
                Latitude = 31.8530006,
                Longitude = 35.2663078,
                StopName = "Adam Boulevard/437",
                Address = "Adam Boulevard street"
            });
            #endregion

            #region Stop #34
            StopList.Add(new Stop()
            {
                Valid = true,
                StopCode = Configuration.StopCounter,
                Latitude = 31.8521136,
                Longitude = 35.2673186,
                StopName = "Adam Boulevard/Savyon",
                Address = "Adam Boulevard street"
            });
            #endregion

            #region Stop #35
            StopList.Add(new Stop()
            {
                Valid = true,
                StopCode = Configuration.StopCounter,
                Latitude = 31.8520547,
                Longitude = 35.2698669,
                StopName = "Adam Blvd/Bosmat",
                Address = "Adam Bosmat street"
            });
            #endregion

            #region Stop #36
            StopList.Add(new Stop()
            {
                Valid = true,
                StopCode = Configuration.StopCounter,
                Latitude = 31.8519325,
                Longitude = 35.2725144,
                StopName = "Adam Boulevard/Harduf Hanehalim",
                Address = "Adam Bosmat street"
            });
            #endregion

            #region Stop #37
            StopList.Add(new Stop()
            {
                Valid = true,
                StopCode = Configuration.StopCounter,
                Latitude = 31.8510208,
                Longitude = 35.2729722,
                StopName = "Harduf Hanehalim/Kalanit",
                Address = "Adam Harduf street"
            });
            #endregion

            #region Stop #38
            StopList.Add(new Stop()
            {
                Valid = true,
                StopCode = Configuration.StopCounter,
                Latitude = 31.8497486,
                Longitude = 35.2730256,
                StopName = "Harduf Hanehalim/Karkum",
                Address = "Adam Harduf street"
            });
            #endregion

            #region Stop #39
            StopList.Add(new Stop()
            {
                Valid = true,
                StopCode = Configuration.StopCounter,
                Latitude = 31.8489703,
                Longitude = 35.2725297,
                StopName = "Harduf Hanehalim/Rakefet",
                Address = "Adam Harduf street"
            });
            #endregion

            #region Stop #40
            StopList.Add(new Stop()
            {
                Valid = true,
                StopCode = Configuration.StopCounter,
                Latitude = 31.8479175,
                Longitude = 35.2716408,
                StopName = "Harduf Hanehalim/Yasmin",
                Address = "Adam Harduf street"
            });
            #endregion

            #region Stop #41
            StopList.Add(new Stop()
            {
                Valid = true,
                StopCode = Configuration.StopCounter,
                Latitude = 31.8472539,
                Longitude = 35.2734450,
                StopName = "Yasmin/Parag",
                Address = "Adam Yasmin street"
            });
            #endregion

            #region Stop #42
            StopList.Add(new Stop()
            {
                Valid = true,
                StopCode = Configuration.StopCounter,
                Latitude = 31.8480281,
                Longitude = 35.2762222,
                StopName = "Parag/Irus",
                Address = "Adam Parag street"
            });
            #endregion

            #region Stop #43
            StopList.Add(new Stop()
            {
                Valid = true,
                StopCode = Configuration.StopCounter,
                Latitude = 31.8477858,
                Longitude = 35.2784881,
                StopName = "Levona/Vered",
                Address = "Adam Levona street"
            });
            #endregion

            #region Stop #44
            StopList.Add(new Stop()
            {
                Valid = true,
                StopCode = Configuration.StopCounter,
                Latitude = 31.8481883,
                Longitude = 35.2804489,
                StopName = "Levona",
                Address = "Adam Levona street"
            });
            #endregion

            #region Stop #45
            StopList.Add(new Stop()
            {
                Valid = true,
                StopCode = Configuration.StopCounter,
                Latitude = 31.8497275,
                Longitude = 35.2816200,
                StopName = "Levona/Adam Blvd",
                Address = "Adam Levona street"
            });
            #endregion

            #region Stop #46
            StopList.Add(new Stop()
            {
                Valid = true,
                StopCode = Configuration.StopCounter,
                Latitude = 31.8511658,
                Longitude = 35.2778244,
                StopName = "Adam Boulevard",
                Address = "Adam Boulevard street"
            });
            #endregion

            #region Stop #47
            StopList.Add(new Stop()
            {
                Valid = true,
                StopCode = Configuration.StopCounter,
                Latitude = 31.8504886,
                Longitude = 35.2796783,
                StopName = "Adam Boulevard/Levona",
                Address = "Adam Boulevard street"
            });
            #endregion

            #region Stop #48
            StopList.Add(new Stop()
            {
                Valid = true,
                StopCode = Configuration.StopCounter,
                Latitude = 31.8501014,
                Longitude = 35.2775497,
                StopName = "Kalanit/Nurit",
                Address = "Adam Kalanit street"
            });
            #endregion

            #region Stop #49
            StopList.Add(new Stop()
            {
                Valid = true,
                StopCode = Configuration.StopCounter,
                Latitude = 31.8488981,
                Longitude = 35.2781067,
                StopName = "Synagogue/HaLilakh",
                Address = "Adam Synagogue street"
            });
            #endregion

            #region Stop #50
            StopList.Add(new Stop()
            {
                Valid = true,
                StopCode = Configuration.StopCounter,
                Latitude = 31.8487453,
                Longitude = 35.2781181,
                StopName = "Yasmin/Kalanit",
                Address = "Adam Yasmin street"
            });
            #endregion





        }
        #endregion

        #region initUser //++

        static void initUserList()
        {
            #region User #0 //temp erase it!
            UserList.Add(new User()
            {
                Password = "1",
                Valid = true,
                UserName = "a",
                Permission = authority.Passenger
            });
            #endregion

            #region User #0 ////temp erase it!
            UserList.Add(new User()
            {
                Password = "2",
                Valid = true,
                UserName = "b",
                Permission = authority.Driver
            });
            #endregion
            #region User #0 ////temp erase it!
            UserList.Add(new User()
            {
                Password = "3",
                Valid = true,
                UserName = "c",
                Permission = authority.Driver
            });
            #endregion

            #region User #1
            UserList.Add(new User()
            {
                Password = "123123",
                Valid = true,
                UserName = User_Name[0],
                Permission = authority.Passenger
            });
            #endregion

            #region User #2
            UserList.Add(new User()
            {
                Password = "123123",
                Valid = true,
                UserName = User_Name[1],
                Permission = authority.Passenger
            });
            #endregion

            #region User #3
            UserList.Add(new User()
            {
                Password = "123123",
                Valid = true,
                UserName = User_Name[2],
                Permission = authority.Passenger
            });
            #endregion

            #region User #4
            UserList.Add(new User()
            {
                Password = "123123",
                Valid = true,
                UserName = User_Name[3],
                Permission = authority.Passenger
            });
            #endregion

            #region User #5
            UserList.Add(new User()
            {
                Password = "123123",
                Valid = true,
                UserName = User_Name[4],
                Permission = authority.Passenger
            });
            #endregion

            #region User #6
            UserList.Add(new User()
            {
                Password = "123123",
                Valid = true,
                UserName = User_Name[5],
                Permission = authority.Passenger
            });
            #endregion

            #region User #7
            UserList.Add(new User()
            {
                Password = "123123",
                Valid = true,
                UserName = User_Name[6],
                Permission = authority.Passenger
            });
            #endregion

            #region User #8
            UserList.Add(new User()
            {
                Password = "123123",
                Valid = true,
                UserName = User_Name[7],
                Permission = authority.Passenger
            });
            #endregion

            #region User #9
            UserList.Add(new User()
            {
                Password = "123123",
                Valid = true,
                UserName = User_Name[8],
                Permission = authority.Passenger
            });
            #endregion

            #region User #10
            UserList.Add(new User()
            {
                Password = "123123",
                Valid = true,
                UserName = User_Name[9],
                Permission = authority.Passenger
            });
            #endregion

            #region User #11
            UserList.Add(new User()
            {
                Password = "123123",
                Valid = true,
                UserName = User_Name[10],
                Permission = authority.Driver
            });
            #endregion

            #region User #12
            UserList.Add(new User()
            {
                Password = "123123",
                Valid = true,
                UserName = User_Name[11],
                Permission = authority.Driver
            });
            #endregion

            #region User #13
            UserList.Add(new User()
            {
                Password = "123123",
                Valid = true,
                UserName = User_Name[12],
                Permission = authority.Driver
            });
            #endregion

            #region User #14
            UserList.Add(new User()
            {
                Password = "123123",
                Valid = true,
                UserName = User_Name[13],
                Permission = authority.Driver
            });
            #endregion

            #region User #15
            UserList.Add(new User()
            {
                Password = "123123",
                Valid = true,
                UserName = User_Name[14],
                Permission = authority.Driver
            });
            #endregion

            #region User #16
            UserList.Add(new User()
            {
                Password = "123123",
                Valid = true,
                UserName = User_Name[15],
                Permission = authority.Driver
            });
            #endregion

            #region User #17
            UserList.Add(new User()
            {
                Password = "123123",
                Valid = true,
                UserName = User_Name[16],
                Permission = authority.Driver
            });
            #endregion

            #region User #18
            UserList.Add(new User()
            {
                Password = "123123",
                Valid = true,
                UserName = User_Name[17],
                Permission = authority.Driver
            });
            #endregion

            #region User #19
            UserList.Add(new User()
            {
                Password = "123123",
                Valid = true,
                UserName = User_Name[18],
                Permission = authority.Driver
            });
            #endregion

            #region User #20
            UserList.Add(new User()
            {
                Password = "123123",
                Valid = true,
                UserName = User_Name[19],
                Permission = authority.Driver
            });
            #endregion
            #region User #21
            UserList.Add(new User()
            {
                Password = "0",
                Valid = true,
                UserName = "N",
                Permission = authority.CEO
            });
            #endregion

        }
        #endregion

        #region initLineStation //++
        static void initLineStationList()
        {

            #region LineStation #1
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 10,
                Code = 570,
                NumberInLine = 1
            });
            #endregion

            #region LineStation #2
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 10,
                Code = 571,
                NumberInLine = 2
            });
            #endregion

            #region LineStation #3
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 10,
                Code = 572,
                NumberInLine = 3
            });
            #endregion

            #region LineStation #4
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 10,
                Code = 573,
                NumberInLine = 4
            });
            #endregion

            #region LineStation #5
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 10,
                Code = 574,
                NumberInLine = 5
            });
            #endregion

            #region LineStation #6
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 10,
                Code = 575,
                NumberInLine = 6
            });
            #endregion

            #region LineStation #7
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 10,
                Code = 576,
                NumberInLine = 7
            });
            #endregion

            #region LineStation #8
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 10,
                Code = 577,
                NumberInLine = 8
            });
            #endregion

            #region LineStation #9
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 10,
                Code = 578,
                NumberInLine = 9
            });
            #endregion

            #region LineStation #10
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 10,
                Code = 555,
                NumberInLine = 10
            });
            #endregion

            #region LineStation #11
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 11,
                Code = 579,
                NumberInLine = 1
            });
            #endregion

            #region LineStation #12
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 11,
                Code = 580,
                NumberInLine = 2
            });
            #endregion

            #region LineStation #13
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 11,
                Code = 581,
                NumberInLine = 3
            });
            #endregion

            #region LineStation #14
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 11,
                Code = 582,
                NumberInLine = 4
            });

            #endregion

            #region LineStation #15
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 11,
                Code = 583,
                NumberInLine = 5
            });
            #endregion

            //---------------------------------------------------------------
            #region LineStation #16
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 11,
                Code = 584,
                NumberInLine = 6
            });
            #endregion

           
            #region LineStation #17
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 11,
                Code = 585,
                NumberInLine = 7
            });
            #endregion

            #region LineStation #18
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 11,
                Code = 586,
                NumberInLine = 8
            });
            #endregion

            #region LineStation #19
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 11,
                Code = 587,
                NumberInLine = 9
            });
            #endregion

            #region LineStation #20
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 11,
                Code = 598,
                NumberInLine = 10
            });
            #endregion
            #region LineStation #21
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 12,
                Code = 585,
                NumberInLine = 1
            });
            #endregion

            #region LineStation #22
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 12,
                Code = 578,
                NumberInLine = 2
            });
            #endregion

            #region LineStation #23
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 12,
                Code = 577,
                NumberInLine = 3
            });
            #endregion

            #region LineStation #24
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 12,
                Code = 576,
                NumberInLine = 4
            });
            #endregion

            #region LineStation #25
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 12,
                Code = 574,
                NumberInLine = 5
            });
            #endregion

            #region LineStation #26
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 12,
                Code = 573,
                NumberInLine = 6
            });
            #endregion

            #region LineStation #27
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 12,
                Code = 572,
                NumberInLine = 7
            });
            #endregion

            #region LineStation #28
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 12,
                Code = 571,
                NumberInLine = 8
            });
            #endregion

            #region LineStation #29
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 12,
                Code = 569,
                NumberInLine = 9
            });
            #endregion

            #region LineStation #30
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 12,
                Code = 570,
                NumberInLine = 10
            });
            #endregion
            #region LineStation #31
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 13,
                Code = 585,
                NumberInLine = 1
            });
            #endregion

            #region LineStation #32
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 13,
                Code = 564,
                NumberInLine = 2
            });
            #endregion

            #region LineStation #33
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 13,
                Code = 563,
                NumberInLine = 3
            });
            #endregion

            #region LineStation #34
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 13,
                Code = 562,
                NumberInLine = 4
            });
            #endregion

            #region LineStation #35
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 13,
                Code = 561,
                NumberInLine = 5
            });
            #endregion

            #region LineStation #36
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 13,
                Code = 560,
                NumberInLine = 6
            });
            #endregion

            #region LineStation #37
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 13,
                Code = 559,
                NumberInLine = 7
            });
            #endregion

            #region LineStation #38
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 13,
                Code = 558,
                NumberInLine = 8
            });
            #endregion

            #region LineStation #39
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 13,
                Code = 557,
                NumberInLine = 9
            });
            #endregion

            #region LineStation #40
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 13,
                Code = 555,
                NumberInLine = 10
            });
            #endregion
            #region LineStation #41
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 14,
                Code = 585,
                NumberInLine = 1
            });
            #endregion

            #region LineStation #42
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 14,
                Code = 584,
                NumberInLine = 2
            });
            #endregion

            #region LineStation #43
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 14,
                Code = 586,
                NumberInLine = 3
            });
            #endregion

            #region LineStation #44
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 14,
                Code = 577,
                NumberInLine = 4
            });
            #endregion

            #region LineStation #45
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 14,
                Code = 579,
                NumberInLine = 5
            });
            #endregion

            #region LineStation #46
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 14,
                Code = 578,
                NumberInLine = 6
            });
            #endregion

            #region LineStation #47
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 14,
                Code = 583,
                NumberInLine = 7
            });
            #endregion

            #region LineStation #48
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 14,
                Code = 582,
                NumberInLine = 8
            });
            #endregion

            #region LineStation #49
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 14,
                Code = 581,
                NumberInLine = 9
            });
            #endregion

            #region LineStation #50
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 14,
                Code = 580,
                NumberInLine = 10
            });
            #endregion
            #region LineStation #51
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 15,
                Code = 598,
                NumberInLine = 1
            });
            #endregion

            #region LineStation #52
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 15,
                Code = 578,
                NumberInLine = 2
            });
            #endregion

            #region LineStation #53
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 15,
                Code = 577,
                NumberInLine = 3
            });
            #endregion

            #region LineStation #54
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 15,
                Code = 576,
                NumberInLine = 4
            });
            #endregion

            #region LineStation #55
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 15,
                Code = 574,
                NumberInLine = 5
            });
            #endregion

            #region LineStation #56
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 15,
                Code = 573,
                NumberInLine = 6
            });
            #endregion

            #region LineStation #57
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 15,
                Code = 572,
                NumberInLine = 7
            });
            #endregion

            #region LineStation #58
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 15,
                Code = 571,
                NumberInLine = 8
            });
            #endregion

            #region LineStation #59
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 15,
                Code = 569,
                NumberInLine = 9
            });
            #endregion

            #region LineStation #60
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 15,
                Code = 570,
                NumberInLine = 10
            });
            #endregion
            #region LineStation #61
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 16,
                Code = 598,
                NumberInLine = 1
            });
            #endregion

            #region LineStation #62
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 16,
                Code = 590,
                NumberInLine = 2
            });
            #endregion

            #region LineStation #63
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 16,
                Code = 591,
                NumberInLine = 3
            });
            #endregion

            #region LineStation #64
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 16,
                Code = 592,
                NumberInLine = 4
            });
            #endregion

            #region LineStation #65
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 16,
                Code = 593,
                NumberInLine = 5
            });
            #endregion

            #region LineStation #66
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 16,
                Code = 594,
                NumberInLine = 6
            });
            #endregion

            #region LineStation #67
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 16,
                Code = 583,
                NumberInLine = 7
            });
            #endregion

            #region LineStation #68
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 16,
                Code = 582,
                NumberInLine = 8
            });
            #endregion

            #region LineStation #69
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 16,
                Code = 581,
                NumberInLine = 9
            });
            #endregion

            #region LineStation #70
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 16,
                Code = 580,
                NumberInLine = 10
            });
            #endregion
            #region LineStation #71
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 17,
                Code = 570,
                NumberInLine = 1
            });
            #endregion

            #region LineStation #72
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 17,
                Code = 574,
                NumberInLine = 2
            });
            #endregion

            #region LineStation #73
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 17,
                Code = 573,
                NumberInLine = 3
            });
            #endregion

            #region LineStation #74
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 17,
                Code = 572,
                NumberInLine = 4
            });
            #endregion

            #region LineStation #75
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 17,
                Code = 571,
                NumberInLine = 5
            });
            #endregion

            #region LineStation #76
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 17,
                Code = 569,
                NumberInLine = 6
            });
            #endregion

            #region LineStation #77
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 17,
                Code = 583,
                NumberInLine = 7
            });
            #endregion

            #region LineStation #78
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 17,
                Code = 582,
                NumberInLine = 8
            });
            #endregion

            #region LineStation #79
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 17,
                Code = 581,
                NumberInLine = 9
            });
            #endregion

            #region LineStation #80
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 17,
                Code = 580,
                NumberInLine = 10
            });
            #endregion
            #region LineStation #81
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 18,
                Code = 598,
                NumberInLine = 1
            });
            #endregion

            #region LineStation #82
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 18,
                Code = 580,
                NumberInLine = 2
            });
            #endregion

            #region LineStation #83
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 18,
                Code = 588,
                NumberInLine = 3
            });
            #endregion

            #region LineStation #84
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 18,
                Code = 589,
                NumberInLine = 4
            });
            #endregion

            #region LineStation #85
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 18,
                Code = 590,
                NumberInLine = 5
            });
            #endregion

            #region LineStation #86
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 18,
                Code = 591,
                NumberInLine = 6
            });
            #endregion

            #region LineStation #87
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 18,
                Code = 592,
                NumberInLine = 7
            });
            #endregion

            #region LineStation #88
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 18,
                Code = 593,
                NumberInLine = 8
            });
            #endregion

            #region LineStation #89
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 18,
                Code = 594,
                NumberInLine = 9
            });
            #endregion

            #region LineStation #90
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 18,
                Code = 595,
                NumberInLine = 10
            });
            #endregion


            #region LineStation #91
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 19,
                Code = 570,
                NumberInLine = 1
            });
            #endregion

            #region LineStation #92
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 19,
                Code = 577,
                NumberInLine = 2
            });
            #endregion

            #region LineStation #93
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 19,
                Code = 576,
                NumberInLine = 3
            });
            #endregion

            #region LineStation #94
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 19,
                Code = 574,
                NumberInLine = 4
            });
            #endregion

            #region LineStation #95
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 19,
                Code = 573,
                NumberInLine = 5
            });
            #endregion

            #region LineStation #96
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 19,
                Code = 572,
                NumberInLine = 6
            });
            #endregion

            #region LineStation #97
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 19,
                Code = 571,
                NumberInLine = 7
            });
            #endregion

            #region LineStation #98
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 19,
                Code = 569,
                NumberInLine = 8
            });
            #endregion

            #region LineStation #99
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 19,
                Code = 577,
                NumberInLine = 9
            });
            #endregion

            #region LineStation #100
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                LineId = 19,
                Code = 578,
                NumberInLine = 10
            });
            #endregion

        }
        #endregion

        #region initLine //++
        static void initLineList()
        {

            #region initLineList #1
            LineList.Add(new Line()
            {
                Valid = true,
                Id = Configuration.LineCounter,
                Number = 143,
                Area = "Benjamin East",
                FirstStop = 570,
                LastStop = 555
            });
            #endregion

            #region initLineList#2
            LineList.Add(new Line()
            {
                Valid = true,
                Id = Configuration.LineCounter,
                Number = 142,
                Area = "Benjamin North",
                FirstStop = 579,
                LastStop = 598

            });
            #endregion

            #region initLineList #3
            LineList.Add(new Line()
            {
                Valid = true,
                Id = Configuration.LineCounter,
                Number = 145,
                Area = "Benjamin East",
                FirstStop = 585,
                LastStop = 570
            });
            #endregion

            #region initLineList #4
            LineList.Add(new Line()
            {
                Valid = true,
                Id = Configuration.LineCounter,
                Number = 144,
                Area = "Benjamin East",
                FirstStop = 585,
                LastStop = 555

            });
            #endregion

            #region initLineList #5
            LineList.Add(new Line()
            {
                Valid = true,
                Id = Configuration.LineCounter,
                Number = 148,
                Area = "Benjamin Southeast",
                FirstStop = 585,
                LastStop = 580
            });
            #endregion

            #region initLineList #6
            LineList.Add(new Line()
            {
                Valid = true,
                Id = Configuration.LineCounter,
                Number = 472,
                Area = "Benjamin North",
                FirstStop = 598,
                LastStop = 570

            });
            #endregion

            #region initLineList #7
            LineList.Add(new Line()
            {
                Valid = true,
                Id = Configuration.LineCounter,
                Number = 141,
                Area = "Benjamin North",
                FirstStop = 598,
                LastStop = 580
            });
            #endregion

            #region initLineList #8
            LineList.Add(new Line()
            {
                Valid = true,
                Id = Configuration.LineCounter,
                Number = 442,
                Area = "Benjamin Southeast",
                FirstStop = 570,
                LastStop = 580

            });
            #endregion

            #region initLineList #9
            LineList.Add(new Line()
            {
                Valid = true,
                Id = Configuration.LineCounter,
                Number = 433,
                Area = "Benjamin North",
                FirstStop = 598,
                LastStop = 595
            });
            #endregion

            #region initLineList #10
            LineList.Add(new Line()
            {
                Valid = true,
                Id = Configuration.LineCounter,
                Number = 456,
                Area = "Benjamin East",
                FirstStop = 570,
                LastStop = 578

            });
            #endregion

        }
        #endregion

        #region initUser_Travel // ++
        static void initUserTravelList()
        {
            #region User_Travel
            UserTravelList.Add(new UserTravel()
            {
                Valid = true,
                IdTravel = Configuration.User_TravelCounter,
                LineId = 10,
                OffStopId = 571,
                OffStopTime = new DateTime(2020, 12, 20, 06, 8, 30),
                OnStopId = 570,
                OnStopTime = new DateTime(2020, 12, 20, 06, 05, 0),
                UserName = User_Name[0]
            });
            #endregion

            #region User_Travel
            UserTravelList.Add(new UserTravel()
            {
                Valid = true,
                IdTravel = Configuration.User_TravelCounter,
                LineId = 10,
                OffStopId = 571,
                OffStopTime = new DateTime(2020, 12, 20, 06, 38, 35),
                OnStopId = 570,
                OnStopTime = new DateTime(2020, 12, 20, 06, 35, 0),
                UserName = User_Name[1]
            });
            #endregion

            #region User_Travel
            UserTravelList.Add(new UserTravel()
            {
                Valid = true,
                IdTravel = Configuration.User_TravelCounter,
                LineId = 11,
                OffStopId = 580,
                OffStopTime = new DateTime(2020, 01, 12, 6, 49, 46),
                OnStopId = 579,
                OnStopTime = new DateTime(2020, 12, 20, 06, 35, 0),
                UserName = User_Name[2]
            });
            #endregion

            #region User_Travel
            UserTravelList.Add(new UserTravel()
            {
                Valid = true,
                IdTravel = Configuration.User_TravelCounter,
                LineId = 11,
                OffStopId = 580,
                OffStopTime = new DateTime(2020, 12, 20, 6, 19, 46),
                OnStopId = 579,
                OnStopTime = new DateTime(2020, 12, 20, 06, 05, 0),
                UserName = User_Name[3]
            });
            #endregion

            #region User_Travel
            UserTravelList.Add(new UserTravel()
            {
                Valid = true,
                IdTravel = Configuration.User_TravelCounter,
                LineId = 12,
                OffStopId = 578,
                OffStopTime = new DateTime(2020, 01, 12, 6, 6, 57),
                OnStopId = 585,
                OnStopTime = new DateTime(2020, 12, 20, 06, 05, 0),
                UserName = User_Name[4]
            });

            #endregion

            #region User_Travel
            UserTravelList.Add(new UserTravel()
            {
                Valid = true,
                IdTravel = Configuration.User_TravelCounter,
                LineId = 12,
                OffStopId = 578,
                OffStopTime = new DateTime(2020, 01, 12, 06, 26, 57),
                OnStopId = 585,
                OnStopTime = new DateTime(2020, 12, 20, 06, 35, 0),
                UserName = User_Name[5]
            });
            #endregion
        }
        #endregion

        #region initSequential_Stop_Info //++


        static void initSequentialStopInfoList()
        {
            #region initSequential #1
            SequentialStopInfoList.Add(new SequentialStopInfo()
            {
                Valid = true,
                stationCodeF = 570,
                stationCodeS = 571,
                distance = 587,
                travelTime = new TimeSpan(0, 3, 30)
            });
            #endregion

            #region initSequential #2
            SequentialStopInfoList.Add(new SequentialStopInfo()
            {
                Valid = true,
                stationCodeF = 571,
                stationCodeS = 572,
                distance = 87,
                travelTime = new TimeSpan(0, 1, 10)
            });
            #endregion

            #region initSequential #3
            SequentialStopInfoList.Add(new SequentialStopInfo()
            {
                Valid = true,
                stationCodeF = 572,
                stationCodeS = 573,
                distance = 55,
                travelTime = new TimeSpan(0, 1, 08)
            });
            #endregion

            #region initSequential #4
            SequentialStopInfoList.Add(new SequentialStopInfo()
            {
                Valid = true,
                stationCodeF = 573,
                stationCodeS = 574,
                distance = 86,
                travelTime = new TimeSpan(0, 1, 15)
            });
            #endregion

            #region initSequential #5
            SequentialStopInfoList.Add(new SequentialStopInfo()
            {
                Valid = true,
                stationCodeF = 574,
                stationCodeS = 575,
                distance = 162,
                travelTime = new TimeSpan(0, 1, 53)
            });
            #endregion

            #region initSequential #6
            SequentialStopInfoList.Add(new SequentialStopInfo()
            {
                Valid = true,
                stationCodeF = 575,
                stationCodeS = 576,
                distance = 142,
                travelTime = new TimeSpan(0, 1, 15)
            });
            #endregion

            #region initSequential #7
            SequentialStopInfoList.Add(new SequentialStopInfo()
            {
                Valid = true,
                stationCodeF = 576,
                stationCodeS = 577,
                distance = 93,
                travelTime = new TimeSpan(0, 1, 03)
            });
            #endregion

            #region initSequential #8
            SequentialStopInfoList.Add(new SequentialStopInfo()
            {
                Valid = true,
                stationCodeF = 577,
                stationCodeS = 578,
                distance = 152,
                travelTime = new TimeSpan(0, 1, 12)
            });
            #endregion

            #region initSequential #9
            SequentialStopInfoList.Add(new SequentialStopInfo()
            {
                Valid = true,
                stationCodeF = 578,
                stationCodeS = 555,
                distance = 979,
                travelTime = new TimeSpan(0, 7, 26)
            });
            #endregion

            #region initSequential #10
            SequentialStopInfoList.Add(new SequentialStopInfo()
            {
                Valid = true,
                stationCodeF = 579,
                stationCodeS = 580,
                distance = 2297,
                travelTime = new TimeSpan(0, 14, 46)
            });
            #endregion

            #region initSequential #11
            SequentialStopInfoList.Add(new SequentialStopInfo()
            {
                Valid = true,
                stationCodeF = 580,
                stationCodeS = 581,
                distance = 137,
                travelTime = new TimeSpan(0, 1, 16)
            });
            #endregion

            #region initSequential #12
            SequentialStopInfoList.Add(new SequentialStopInfo()
            {
                Valid = true,
                stationCodeF = 581,
                stationCodeS = 582,
                distance = 241,
                travelTime = new TimeSpan(0, 2, 18)
            });
            #endregion

            #region initSequential #13
            SequentialStopInfoList.Add(new SequentialStopInfo()
            {
                Valid = true,
                stationCodeF = 582,
                stationCodeS = 583,
                distance = 251,
                travelTime = new TimeSpan(0, 2, 33)
            });
            #endregion

            #region initSequential #14
            SequentialStopInfoList.Add(new SequentialStopInfo()
            {
                Valid = true,
                stationCodeF = 583,
                stationCodeS = 584,
                distance = 248,
                travelTime = new TimeSpan(0, 2, 21)
            });
            #endregion

            #region initSequential #15
            SequentialStopInfoList.Add(new SequentialStopInfo()
            {
                Valid = true,
                stationCodeF = 584,
                stationCodeS = 585,
                distance = 98,
                travelTime = new TimeSpan(0, 1, 12)
            });
            #endregion

            #region initSequential #16
            SequentialStopInfoList.Add(new SequentialStopInfo()
            {
                Valid = true,
                stationCodeF = 585,
                stationCodeS = 586,
                distance = 80,
                travelTime = new TimeSpan(0, 1, 08)
            });
            #endregion

            #region initSequential #17
            SequentialStopInfoList.Add(new SequentialStopInfo()
            {
                Valid = true,
                stationCodeF = 586,
                stationCodeS = 587,
                distance = 57,
                travelTime = new TimeSpan(0, 1, 04)
            });
            #endregion

            #region initSequential #18
            SequentialStopInfoList.Add(new SequentialStopInfo()
            {
                Valid = true,
                stationCodeF = 587,
                stationCodeS = 598,
                distance = 824,
                travelTime = new TimeSpan(0, 7, 17)
            });
            #endregion

            #region initSequential #19
            SequentialStopInfoList.Add(new SequentialStopInfo()
            {
                Valid = true,
                stationCodeF = 585,
                stationCodeS = 578,
                distance = 201,
                travelTime = new TimeSpan(0, 1, 57)
            });
            #endregion

            #region initSequential #20
            SequentialStopInfoList.Add(new SequentialStopInfo()
            {
                Valid = true,
                stationCodeF = 578,
                stationCodeS = 577,
                distance = 152,
                travelTime = new TimeSpan(0, 1, 17)
            });
            #endregion

            #region initSequential #21
            SequentialStopInfoList.Add(new SequentialStopInfo()
            {
                Valid = true,
                stationCodeF = 577,
                stationCodeS = 576,
                distance = 93,
                travelTime = new TimeSpan(0, 1, 17)
            });
            #endregion

            #region initSequential #22
            SequentialStopInfoList.Add(new SequentialStopInfo()
            {
                Valid = true,
                stationCodeF = 576,
                stationCodeS = 574,
                distance = 86,
                travelTime = new TimeSpan(0, 1, 26)
            });
            #endregion

            #region initSequential #23
            SequentialStopInfoList.Add(new SequentialStopInfo()
            {
                Valid = true,
                stationCodeF = 574,
                stationCodeS = 573,
                distance = 87,
                travelTime = new TimeSpan(0, 1, 16)
            });
            #endregion

            #region initSequential #24
            SequentialStopInfoList.Add(new SequentialStopInfo()
            {
                Valid = true,
                stationCodeF = 573,
                stationCodeS = 572,
                distance = 55,
                travelTime = new TimeSpan(0, 1, 08)
            });
            #endregion

            #region initSequential #25
            SequentialStopInfoList.Add(new SequentialStopInfo()
            {
                Valid = true,
                stationCodeF = 572,
                stationCodeS = 571,
                distance = 87,
                travelTime = new TimeSpan(0, 1, 16)
            });
            #endregion

            #region initSequential #26
            SequentialStopInfoList.Add(new SequentialStopInfo()
            {
                Valid = true,
                stationCodeF = 571,
                stationCodeS = 569,
                distance = 702,
                travelTime = new TimeSpan(0, 5, 46)
            });
            #endregion

            #region initSequential #27
            SequentialStopInfoList.Add(new SequentialStopInfo()
            {
                Valid = true,
                stationCodeF = 569,
                stationCodeS = 570,
                distance = 154,
                travelTime = new TimeSpan(0, 1, 23)
            });
            #endregion

            #region initSequential #28
            SequentialStopInfoList.Add(new SequentialStopInfo()
            {
                Valid = true,
                stationCodeF = 585,
                stationCodeS = 564,
                distance = 753,
                travelTime = new TimeSpan(0, 5, 42)
            });
            #endregion

            #region initSequential #29
            SequentialStopInfoList.Add(new SequentialStopInfo()
            {
                Valid = true,
                stationCodeF = 564,
                stationCodeS = 563,
                distance = 917,
                travelTime = new TimeSpan(0, 7, 15)
            });
            #endregion

            #region initSequential #30
            SequentialStopInfoList.Add(new SequentialStopInfo()
            {
                Valid = true,
                stationCodeF = 563,
                stationCodeS = 562,
                distance = 72,
                travelTime = new TimeSpan(0, 1, 04)
            });
            #endregion

            #region initSequential #31
            SequentialStopInfoList.Add(new SequentialStopInfo()
            {
                Valid = true,
                stationCodeF = 562,
                stationCodeS = 561,
                distance = 158,
                travelTime = new TimeSpan(0, 2, 06)
            });
            #endregion

            #region initSequential #32
            SequentialStopInfoList.Add(new SequentialStopInfo()
            {
                Valid = true,
                stationCodeF = 561,
                stationCodeS = 560,
                distance = 26,
                travelTime = new TimeSpan(0, 1, 01)
            });
            #endregion

            #region initSequential #33
            SequentialStopInfoList.Add(new SequentialStopInfo()
            {
                Valid = true,
                stationCodeF = 560,
                stationCodeS = 559,
                distance = 115,
                travelTime = new TimeSpan(0, 1, 17)
            });
            #endregion


        }
        #endregion

        #region initLine_Departure //++
        static void initLineDepartureList()
        {
            #region LineDeparture # 1

            LineDepartureList.Add(new LineDeparture()
            {
                Valid = true,
                Frequency = 5,
                Id = 10,
                Time_Start = new DateTime(2020, 12, 20, 06, 00, 0),
                Time_End = new DateTime(2020, 12, 20, 10, 00, 0)

            });

            #endregion

            #region LineDeparture # 2
            LineDepartureList.Add(new LineDeparture()
            {
                Valid = true,
                Frequency = 6,
                Id = 10,
                Time_Start = new DateTime(2020, 12, 20, 10, 00, 0),
                Time_End = new DateTime(2020, 12, 20, 14, 00, 0)

            });
            #endregion

            #region LineDeparture # 3
            LineDepartureList.Add(new LineDeparture()
            {
                Valid = true,
                Frequency = 7,
                Id = 10,
                Time_Start = new DateTime(2020, 12, 20, 14, 00, 0),
                Time_End = new DateTime(2020, 12, 20, 22, 0, 0)

            });
            #endregion

            #region LineDeparture # 4

            LineDepartureList.Add(new LineDeparture()
            {
                Valid = true,
                Frequency = 5,
                Id = 11,
                Time_Start = new DateTime(2020, 12, 20, 06, 00, 0),
                Time_End = new DateTime(2020, 12, 20, 10, 00, 0)

            });
            #endregion

            #region LineDeparture # 5
            LineDepartureList.Add(new LineDeparture()
            {
                Valid = true,
                Frequency = 6,
                Id = 11,
                Time_Start = new DateTime(2020, 12, 20, 10, 00, 0),
                Time_End = new DateTime(2020, 12, 20, 14, 00, 0)

            });
            #endregion

            #region LineDeparture # 6
            LineDepartureList.Add(new LineDeparture()
            {
                Valid = true,
                Frequency = 7,
                Id = 11,
                Time_Start = new DateTime(2020, 12, 20, 14, 00, 0),
                Time_End = new DateTime(2020, 12, 20, 22, 0, 0)

            });

            #endregion

            #region LineDeparture # 7
            LineDepartureList.Add(new LineDeparture()
            {
                Valid = true,
                Frequency = 5,
                Id = 12,
                Time_Start = new DateTime(2020, 12, 20, 06, 00, 0),
                Time_End = new DateTime(2020, 12, 20, 10, 00, 0)

            });
            #endregion

            #region LineDeparture # 8
            LineDepartureList.Add(new LineDeparture()
            {
                Valid = true,
                Frequency = 6,
                Id = 12,
                Time_Start = new DateTime(2020, 12, 20, 10, 00, 0),
                Time_End = new DateTime(2020, 12, 20, 14, 00, 0)

            });

            #endregion

            #region LineDeparture # 9
            LineDepartureList.Add(new LineDeparture()
            {
                Valid = true,
                Frequency = 7,
                Id = 12,
                Time_Start = new DateTime(2020, 12, 20, 14, 00, 0),
                Time_End = new DateTime(2020, 12, 20, 22, 0, 0)

            });
            #endregion

         
        }
        #endregion 

    }
}

