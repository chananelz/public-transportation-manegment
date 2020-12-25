using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;



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
                License_Number = 1000000,
                Line_Id = 10,
                Formal_Departure_Time = new DateTime(2020, 12, 20, 06, 00, 0),
                Real_Departure_Time = new DateTime(2020, 12, 20, 06, 05, 0),
                Last_Passed_Stop = 570,
                Last_Passed_Stop_Time = new DateTime(2020, 12, 20, 06, 05, 0),
                Next_Stop_Time = new DateTime(2020, 12, 20, 06, 8, 30),
                DriverId = 206275811
            });
            #endregion


            #region Bus_Travel # 2

            BusTravelList.Add(new BusTravel()
            {
                Valid = true,
                Id = Configuration.Bus_TravelCounter,
                License_Number = 1000001,
                Line_Id = 10,
                Formal_Departure_Time = new DateTime(2020, 12, 20, 06, 30, 0),
                Real_Departure_Time = new DateTime(2020, 12, 20, 06, 35, 0),
                Last_Passed_Stop = 570,
                Last_Passed_Stop_Time = new DateTime(2020, 12, 20, 06, 35, 0),
                Next_Stop_Time = new DateTime(2020, 12, 20, 06, 38, 35),
                DriverId = 206275812
            });

            #endregion

            #region Bus_Travel # 3
            BusTravelList.Add(new BusTravel()
            {
                Valid = true,
                Id = Configuration.Bus_TravelCounter,
                License_Number = 1000002,
                Line_Id = 10,
                Formal_Departure_Time = new DateTime(2020, 12, 20, 07, 00, 0),
                Real_Departure_Time = new DateTime(2020, 12, 20, 07, 05, 0),
                Last_Passed_Stop = 570,
                Last_Passed_Stop_Time = new DateTime(2020, 12, 20, 07, 05, 0),
                Next_Stop_Time = new DateTime(2020, 12, 20, 07, 8, 30),
                DriverId = 206275813
            });
            #endregion

            #region Bus_Travel # 4
            BusTravelList.Add(new BusTravel()
            {
                Valid = true,
                Id = Configuration.Bus_TravelCounter,
                License_Number = 1000003,
                Line_Id = 11,
                Formal_Departure_Time = new DateTime(2020, 12, 20, 06, 00, 0),
                Real_Departure_Time = new DateTime(2020, 12, 20, 06, 05, 0),
                Last_Passed_Stop = 579,
                Last_Passed_Stop_Time = new DateTime(2020, 12, 20, 06, 05, 0),
                Next_Stop_Time = new DateTime(2020, 12, 20, 06, 8, 30),
                DriverId = 206275814
            });
            #endregion

            #region Bus_Travel # 5
            BusTravelList.Add(new BusTravel()
            {
                Valid = true,
                Id = Configuration.Bus_TravelCounter,
                License_Number = 1000004,
                Line_Id = 11,
                Formal_Departure_Time = new DateTime(2020, 12, 20, 06, 30, 0),
                Real_Departure_Time = new DateTime(2020, 12, 20, 06, 35, 0),
                Last_Passed_Stop = 579,
                Last_Passed_Stop_Time = new DateTime(2020, 12, 20, 06, 35, 0),
                Next_Stop_Time = new DateTime(2020, 12, 20, 06, 38, 35),
                DriverId = 206275815
            });
            #endregion

            #region Bus_Travel # 6
            BusTravelList.Add(new BusTravel()
            {
                Valid = true,
                Id = Configuration.Bus_TravelCounter,
                License_Number = 1000005,
                Line_Id = 11,
                Formal_Departure_Time = new DateTime(2020, 12, 20, 07, 00, 0),
                Real_Departure_Time = new DateTime(2020, 12, 20, 07, 05, 0),
                Last_Passed_Stop = 579,
                Last_Passed_Stop_Time = new DateTime(2020, 12, 20, 07, 05, 0),
                Next_Stop_Time = new DateTime(2020, 12, 20, 07, 8, 30),
                DriverId = 206275816
            });
            #endregion

            #region Bus_Travel # 7
            BusTravelList.Add(new BusTravel()
            {
                Valid = true,
                Id = Configuration.Bus_TravelCounter,
                License_Number = 1000006,
                Line_Id = 12,
                Formal_Departure_Time = new DateTime(2020, 12, 20, 06, 00, 0),
                Real_Departure_Time = new DateTime(2020, 12, 20, 06, 05, 0),
                Last_Passed_Stop = 585,
                Last_Passed_Stop_Time = new DateTime(2020, 12, 20, 06, 05, 0),
                Next_Stop_Time = new DateTime(2020, 12, 20, 06, 8, 30),
                DriverId = 206275817
            });
            #endregion

            #region Bus_Travel # 8
            BusTravelList.Add(new BusTravel()
            {
                Valid = true,
                Id = Configuration.Bus_TravelCounter,
                License_Number = 1000007,
                Line_Id = 12,
                Formal_Departure_Time = new DateTime(2020, 12, 20, 06, 30, 0),
                Real_Departure_Time = new DateTime(2020, 12, 20, 06, 35, 0),
                Last_Passed_Stop = 585,
                Last_Passed_Stop_Time = new DateTime(2020, 12, 20, 06, 35, 0),
                Next_Stop_Time = new DateTime(2020, 12, 20, 06, 38, 35),
                DriverId = 206275818
            });
            #endregion

            #region Bus_Travel # 9
            BusTravelList.Add(new BusTravel()
            {
                Valid = true,
                Id = Configuration.Bus_TravelCounter,
                License_Number = 1000008,
                Line_Id = 12,
                Formal_Departure_Time = new DateTime(2020, 12, 20, 07, 00, 0),
                Real_Departure_Time = new DateTime(2020, 12, 20, 07, 05, 0),
                Last_Passed_Stop = 585,
                Last_Passed_Stop_Time = new DateTime(2020, 12, 20, 07, 05, 0),
                Next_Stop_Time = new DateTime(2020, 12, 20, 07, 8, 30),
                DriverId = 206275819
            });
            #endregion

            #region Bus_Travel # 10
            BusTravelList.Add(new BusTravel()
            {
                Valid = true,
                Id = Configuration.Bus_TravelCounter,
                License_Number = 1000009,
                Line_Id = 13,
                Formal_Departure_Time = new DateTime(2020, 12, 20, 06, 00, 0),
                Real_Departure_Time = new DateTime(2020, 12, 20, 06, 05, 0),
                Last_Passed_Stop = 585,
                Last_Passed_Stop_Time = new DateTime(2020, 12, 20, 06, 05, 0),
                Next_Stop_Time = new DateTime(2020, 12, 20, 06, 8, 30),
                DriverId = 206275820
            });
            #endregion

            #region Bus_Travel # 11

            BusTravelList.Add(new BusTravel()
            {
                Valid = true,
                Id = Configuration.Bus_TravelCounter,
                License_Number = 1000010,
                Line_Id = 13,
                Formal_Departure_Time = new DateTime(2020, 12, 20, 06, 30, 0),
                Real_Departure_Time = new DateTime(2020, 12, 20, 06, 35, 0),
                Last_Passed_Stop = 585,
                Last_Passed_Stop_Time = new DateTime(2020, 12, 20, 06, 35, 0),
                Next_Stop_Time = new DateTime(2020, 12, 20, 06, 38, 35),
                DriverId = 206275821
            });
            #endregion

            #region Bus_Travel # 12
            BusTravelList.Add(new BusTravel()
            {
                Valid = true,
                Id = Configuration.Bus_TravelCounter,
                License_Number = 1000011,
                Line_Id = 13,
                Formal_Departure_Time = new DateTime(2020, 12, 20, 07, 00, 0),
                Real_Departure_Time = new DateTime(2020, 12, 20, 07, 05, 0),
                Last_Passed_Stop = 585,
                Last_Passed_Stop_Time = new DateTime(2020, 12, 20, 07, 05, 0),
                Next_Stop_Time = new DateTime(2020, 12, 20, 07, 8, 30),
                DriverId = 206275822
            });
            #endregion
        }

        #endregion

        #region initBus //++
        public static status getRandomStatus()
        {
            int a = r.Next(4);

            switch (a)
            {
                case 0:
                    return status.READY_FOR_DRIVE;
                case 1:
                    return status.REFULING;
                case 2:
                    return status.TRAVELING;
                case 3:
                    return status.READY_FOR_DRIVE;

                default:
                    return status.READY_FOR_DRIVE;
            }
        }
        static void initBusesList()
        {

            for (int i = 0; i < 20; i++)
            {
                int a = r.Next(2000, 2020);
                int b = r.Next(11) + 1;
                int c = r.Next(29) + 1;

                BusesList.Add(new Bus()
                {
                    Valid = true,
                    LicenseNumber = Configuration.BusCounter,
                    LicenseDate = new DateTime(a, b, c),
                    KM = (float)r.NextDouble() + r.Next(1, 1199),
                    Fuel = r.Next(0, 1199) + (float)r.NextDouble(),
                    Status = getRandomStatus()
                });
            }
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

            #region User #1
            UserList.Add(new User()
            {
                Password = "123123",
                Valid = true,
                UserName = User_Name[0],
                Permission = authority.USER
            });
            #endregion

            #region User #2
            UserList.Add(new User()
            {
                Password = "123123",
                Valid = true,
                UserName = User_Name[1],
                Permission = authority.USER
            });
            #endregion

            #region User #3
            UserList.Add(new User()
            {
                Password = "123123",
                Valid = true,
                UserName = User_Name[2],
                Permission = authority.USER
            });
            #endregion

            #region User #4
            UserList.Add(new User()
            {
                Password = "123123",
                Valid = true,
                UserName = User_Name[3],
                Permission = authority.USER
            });
            #endregion

            #region User #5
            UserList.Add(new User()
            {
                Password = "123123",
                Valid = true,
                UserName = User_Name[4],
                Permission = authority.USER
            });
            #endregion

            #region User #6
            UserList.Add(new User()
            {
                Password = "123123",
                Valid = true,
                UserName = User_Name[5],
                Permission = authority.USER
            });
            #endregion

            #region User #7
            UserList.Add(new User()
            {
                Password = "123123",
                Valid = true,
                UserName = User_Name[6],
                Permission = authority.USER
            });
            #endregion

            #region User #8
            UserList.Add(new User()
            {
                Password = "123123",
                Valid = true,
                UserName = User_Name[7],
                Permission = authority.USER
            });
            #endregion

            #region User #9
            UserList.Add(new User()
            {
                Password = "123123",
                Valid = true,
                UserName = User_Name[8],
                Permission = authority.USER
            });
            #endregion

            #region User #10
            UserList.Add(new User()
            {
                Password = "123123",
                Valid = true,
                UserName = User_Name[9],
                Permission = authority.USER
            });
            #endregion

            #region User #11
            UserList.Add(new User()
            {
                Password = "123123",
                Valid = true,
                UserName = User_Name[10],
                Permission = authority.CEO
            });
            #endregion

            #region User #12
            UserList.Add(new User()
            {
                Password = "123123",
                Valid = true,
                UserName = User_Name[11],
                Permission = authority.CEO
            });
            #endregion

            #region User #13
            UserList.Add(new User()
            {
                Password = "123123",
                Valid = true,
                UserName = User_Name[12],
                Permission = authority.CEO
            });
            #endregion

            #region User #14
            UserList.Add(new User()
            {
                Password = "123123",
                Valid = true,
                UserName = User_Name[13],
                Permission = authority.CEO
            });
            #endregion

            #region User #15
            UserList.Add(new User()
            {
                Password = "123123",
                Valid = true,
                UserName = User_Name[14],
                Permission = authority.CEO
            });
            #endregion

            #region User #16
            UserList.Add(new User()
            {
                Password = "123123",
                Valid = true,
                UserName = User_Name[15],
                Permission = authority.CEO
            });
            #endregion

            #region User #17
            UserList.Add(new User()
            {
                Password = "123123",
                Valid = true,
                UserName = User_Name[16],
                Permission = authority.CEO
            });
            #endregion

            #region User #18
            UserList.Add(new User()
            {
                Password = "123123",
                Valid = true,
                UserName = User_Name[17],
                Permission = authority.CEO
            });
            #endregion

            #region User #19
            UserList.Add(new User()
            {
                Password = "123123",
                Valid = true,
                UserName = User_Name[18],
                Permission = authority.CEO
            });
            #endregion

            #region User #20
            UserList.Add(new User()
            {
                Password = "123123",
                Valid = true,
                UserName = User_Name[19],
                Permission = authority.CEO
            });
            #endregion

        }
        #endregion

        #region initLine_Station //++
        static void initLineStationList()
        {

            #region Line_Station #1
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                Line_Id = 10,
                Code = 571,
                Number_In_Line = 2
            });
            #endregion

            #region Line_Station #2
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                Line_Id = 10,
                Code = 574,
                Number_In_Line = 5
            });
            #endregion

            #region Line_Station #3
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                Line_Id = 10,
                Code = 577,
                Number_In_Line = 8
            });
            #endregion

            #region Line_Station #4
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                Line_Id = 11,
                Code = 581,
                Number_In_Line = 3
            });
            #endregion

            #region Line_Station #5
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                Line_Id = 11,
                Code = 582,
                Number_In_Line = 4
            });
            #endregion

            #region Line_Station #6
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                Line_Id = 11,
                Code = 583,
                Number_In_Line = 5
            });
            #endregion

            #region Line_Station #7
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                Line_Id = 12,
                Code = 577,
                Number_In_Line = 3
            });
            #endregion

            #region Line_Station #8
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                Line_Id = 12,
                Code = 569,
                Number_In_Line = 9
            });
            #endregion

            #region Line_Station #9
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                Line_Id = 13,
                Code = 562,
                Number_In_Line = 4
            });
            #endregion

            #region Line_Station #10
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                Line_Id = 14,
                Code = 577,
                Number_In_Line = 4
            });
            #endregion

            #region Line_Station #11
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                Line_Id = 15,
                Code = 578,
                Number_In_Line = 2
            });
            #endregion

            #region Line_Station #12
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                Line_Id = 15,
                Code = 572,
                Number_In_Line = 7
            });
            #endregion

            #region Line_Station #13
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                Line_Id = 16,
                Code = 593,
                Number_In_Line = 5
            });
            #endregion

            #region Line_Station #14
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                Line_Id = 17,
                Code = 573,
                Number_In_Line = 3
            });

            #endregion
            #region Line_Station #14
            LineStationList.Add(new LineStation()
            {
                Valid = true,
                Line_Id = 18,
                Code = 590,
                Number_In_Line = 5
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
                FirstStop = 4879,
                LastStop = 8767
            });
            #endregion

            #region initLineList#2
            LineList.Add(new Line()
            {
                Valid = true,
                Id = Configuration.LineCounter,
                Number = 142,
                Area = "Benjamin North",
                FirstStop = 9764,
                LastStop = 6482

            });
            #endregion

            #region initLineList #3
            LineList.Add(new Line()
            {
                Valid = true,
                Id = Configuration.LineCounter,
                Number = 145,
                Area = "Benjamin East",
                FirstStop = 9437,
                LastStop = 4879
            });
            #endregion

            #region initLineList #4
            LineList.Add(new Line()
            {
                Valid = true,
                Id = Configuration.LineCounter,
                Number = 144,
                Area = "Benjamin East",
                FirstStop = 9437,
                LastStop = 8767

            });
            #endregion

            #region initLineList #5
            LineList.Add(new Line()
            {
                Valid = true,
                Id = Configuration.LineCounter,
                Number = 148,
                Area = "Benjamin Southeast",
                FirstStop = 9437,
                LastStop = 3379
            });
            #endregion

            #region initLineList #6
            LineList.Add(new Line()
            {
                Valid = true,
                Id = Configuration.LineCounter,
                Number = 472,
                Area = "Benjamin North",
                FirstStop = 6482,
                LastStop = 4879

            });
            #endregion

            #region initLineList #7
            LineList.Add(new Line()
            {
                Valid = true,
                Id = Configuration.LineCounter,
                Number = 141,
                Area = "Benjamin North",
                FirstStop = 6482,
                LastStop = 3379
            });
            #endregion

            #region initLineList #8
            LineList.Add(new Line()
            {
                Valid = true,
                Id = Configuration.LineCounter,
                Number = 442,
                Area = "Benjamin Southeast",
                FirstStop = 4879,
                LastStop = 3379

            });
            #endregion

            #region initLineList #9
            LineList.Add(new Line()
            {
                Valid = true,
                Id = Configuration.LineCounter,
                Number = 433,
                Area = "Benjamin North",
                FirstStop = 6482,
                LastStop = 4571
            });
            #endregion

            #region initLineList #10
            LineList.Add(new Line()
            {
                Valid = true,
                Id = Configuration.LineCounter,
                Number = 456,
                Area = "Benjamin East",
                FirstStop = 4879,
                LastStop = 9627

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


