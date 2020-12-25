using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using dotNet5781_01_6077_5711;
//netanel bashan 0323056077
//chananel zaguri 206275711

namespace dotNet_5781_02_6077_5711
{
    

    /// <summary>
    /// the main class
    /// </summary>
    public class Program_6077_5711_02: Program_6077_5711_01
    {
        public static string[] Areas = { "Jerusalem", "Tel Aviv", "Raanana", "Beit Shemes", "Beer Sheva", "Tzefat", "MaaleAdumim", "Hayfa", "Aco", "Eilat" };
        public static string[] stopName = { "Abby_Park_Street", "Adelaide_Avenue", "Airplane_Avenue", "Airport_Avenue", "Airport_Street", "Andreas_Avenue", "Arthur_Street", "Auburn_Avenue", "Bay_Avenue", "Beatles_Avenue", "Belby_Road", "Bus_Avenue", "California_Street", "Camp_Street", "Cavour_Avenue", "Central_Cesta", "Central_Street", "China_Avenue", "Communal_Squar", "Constitution_Street", "Copper_Street", "Corn Street", "Costume_Street", "Cresson_Crescent", "Danish_Avenue", "Dean_Avenue", "Delaware_Avenue", "Delta_Street", "Democracy_Avenu", "Department_Street", "Dimitri_Street", "Dock_Street", "Dubnitz_Road", "Eastern_Cesta", "East_Hills_Avenue", "Easy_Street", "Elgin_Avenue", "Elisabeth_Street", "Empire_Avenue", "Eppink_Square" };
        public static int[] notUseDStops = new int[stopName.Length];
        public static stopLocation[] myStops = new stopLocation[stopName.Length];
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        /// <summary>
        /// main Function
        /// </summary>
        /// <param name="args">something weird from cmd</param>
        public static void Main(string[] args)
        {
            BusCollection myBusCollection = new BusCollection();
            LineManagement(ref myBusCollection);
            Console.ReadKey();
        }
        /// <summary>
        /// initialize a busCollection with 10 bus routs which contain at least 40 stops
        /// </summary>
        public static void initializeBusRoute(ref BusCollection myBusCollection, ref List<BusStop> myUniqueStops)
        {

            
            //BusCollection myBusCollection = new BusCollection();
            Random r = new Random();
            BusRoute myBusRoute = new BusRoute();
            BusRoute[] myRoutes = new BusRoute[Areas.Length];
            int myRandom;
            ///////////////////////////////////////////
            ///     INITAILIZEING 40 STOPS
            //////////////////////////////////////////
            for (int i = 0; i < stopName.Length; i++)
            {
                myStops[i] = new stopLocation();
                myStops[i].m_location = stopName[i];
                myStops[i].m_longitude = r.Next(34, 36) + (float)(r.NextDouble() % 0.2 + 0.3);
                if (myStops[i].m_longitude < 35)
                    myStops[i].m_longitude += (float)r.NextDouble();
                myStops[i].m_latitude = r.Next(31, 34) + (float)(r.NextDouble() % 0.3);
                if (myStops[i].m_longitude < 33)
                    myStops[i].m_longitude += (float)r.NextDouble();
                do
                {
                    myStops[i].m_busStationKey = r.Next(10000000);
                } while (myBusCollection.keyExist(myStops[i].m_busStationKey));
            }
            ///////////////////////////////////////////
            ///     INITAILIZEING 10 BUS ROUTES
            //////////////////////////////////////////
            for (int i = 0; i < 10; i++)
            {
                myBusRoute = new BusRoute();
                
                myBusRoute = initializeBus(myBusRoute,myBusCollection,myUniqueStops);
                
                myBusCollection.addFirstBusRoute(myBusRoute);
            }
            ///////////////////////////////////////////
            ///     ALL STOP ARE USED CHECK
            //////////////////////////////////////////
            bool addedNewBus = false;
            bool foundFirst = false;
            string last = "";
            myBusRoute = new BusRoute();
            for (int i = 0; i < stopName.Length; i++)
            {
                if (notUseDStops[i] == 0)
                {
                    BusStop myNewStop = new BusStop();
                    myNewStop.m_mylocation.m_busStationKey = myStops[i].m_busStationKey;
                    myNewStop.m_mylocation.m_latitude = myStops[i].m_latitude;
                    myNewStop.m_mylocation.m_location = myStops[i].m_location;
                    myNewStop.m_mylocation.m_longitude = myStops[i].m_longitude;
                    myNewStop.m_mylocation.m_location = myStops[i].m_location;
                    addedNewBus = true;
                    notUseDStops[i]++;
                    myBusRoute.add(myNewStop,myBusRoute.m_Stations.Count());
                    last = myStops[i].m_location;
                    if (!foundFirst)
                    {
                        myBusRoute.m_FirstStation = last;
                        foundFirst = true;
                    }
                    if (!myBusCollection.keyExist(myStops[i].m_busStationKey))
                    {
                        myBusCollection.m_BusKeysList.Add(myStops[i].m_busStationKey);
                        myUniqueStops.Add(myNewStop);
                    }
                }
            }
            if (foundFirst)
            {
                myBusRoute.m_LastStation = last;
                myBusRoute.m_Area = Areas[r.Next(Areas.Length)];
                do
                {
                    myBusRoute.m_BusLine = r.Next(1000);
                } while (myBusCollection.busLineExist(myBusRoute));
            }
            myBusCollection.addFirstBusRoute(myBusRoute);
            /////////////////////////////////////////////////
            //   10 STOPS ARE USED IN MORE THAN 1 BUS  LINE
            //////////////////////////////////////////////////
            
            BusRoute myNewRoute = new BusRoute();
            for (int i = 0; i < 10; i++)
            {
                if (notUseDStops[i] < 2)
                {
                    BusStop myNewStop = new BusStop();
                    myNewStop.m_mylocation.m_busStationKey = myStops[i].m_busStationKey;
                    myNewStop.m_mylocation.m_latitude = myStops[i].m_latitude;
                    myNewStop.m_mylocation.m_location = myStops[i].m_location;
                    myNewStop.m_mylocation.m_longitude = myStops[i].m_longitude; notUseDStops[i]++;
                    myNewRoute.add(myNewStop, myNewRoute.m_Stations.Count());
                    if (!myBusCollection.keyExist(myStops[i].m_busStationKey))
                    {
                        myBusCollection.m_BusKeysList.Add(myStops[i].m_busStationKey);
                        myUniqueStops.Add(myNewStop);
                    }
                }
            }
        }

        public static BusRoute initializeBus(BusRoute myBusRoute, BusCollection myBusCollection, List<BusStop> myUniqueStops)
        {
            Random r = new Random();
            int myRandom = 0;
            myBusRoute.m_Area = Areas[r.Next(Areas.Length)];
            do
            {
                myBusRoute.m_BusLine = r.Next(1000);
            } while (myBusCollection.busLineExist(myBusRoute));
            for (int adDStop = 0; adDStop < 10; adDStop++)
            {
                BusStop myNewStop = new BusStop();
                int Stop_random = r.Next(stopName.Length);
                myNewStop.m_mylocation.m_busStationKey = myStops[Stop_random].m_busStationKey;
                myNewStop.m_mylocation.m_latitude = myStops[Stop_random].m_latitude;
                myNewStop.m_mylocation.m_location = myStops[Stop_random].m_location;
                myNewStop.m_mylocation.m_longitude = myStops[Stop_random].m_longitude;
                myNewStop.m_mylocation.m_location = myStops[Stop_random].m_location;
                if (adDStop == 0)
                {
                    myBusRoute.m_FirstStation = stopName[Stop_random];
                }
                else if (adDStop == 9)
                {
                    myBusRoute.m_LastStation = stopName[Stop_random];
                }
                if (!myBusRoute.stopExist(myNewStop))
                {
                    notUseDStops[Stop_random]++;
                }
                if (!myBusCollection.keyExist(myStops[myRandom].m_busStationKey))
                {
                    myBusCollection.m_BusKeysList.Add(myStops[adDStop].m_busStationKey);
                    myUniqueStops.Add(myNewStop);
                }
                myRandom = r.Next(myStops.Length);
                //myBusRoute.m_Stations.Add(myStops[myRandom]);
                myBusRoute.add(myNewStop, myBusRoute.m_Stations.Count());
                
            }

            return myBusRoute;
        }

        /// <summary>
        /// save the choise for line management
        /// </summary>
        enum menuChoice
        {
            ADD = 1,
            ERASE,
            SEARCH,
            PRINT,
            EXIT
        };
        /// <summary>
        /// menu for adding
        /// </summary>
        enum menuAdd
        {
            ADD_BUS_STOP = 1,
            ADD_BUS_ROUTE
        };
        /// <summary>
        /// menu for delete
        /// </summary>
        enum menuDelete
        {
            DELETE_BUS_ROUTE = 1,
            DELETE_STOP

        };
        /// <summary>
        /// enum for search
        /// </summary>
        enum menuSearch
        {
            LINES_THAT_PASS_IN_STOP = 1,
            FIND_PATH

        };
        /// <summary>
        /// menu to print
        /// </summary>
        enum menuPrintInfo
        {
            printAllBusses = 1,
            printBusStopInfo,
            printAllInfo
        }
        /// <summary>
        /// get a bus stop from the user
        /// </summary>
        /// <param name="myBusCollection">the Collection of all the bus </param>
        /// <param name="myUniqueStops">a list of stop</param>
        /// <returns></returns>
        public static BusStop GetBusStop(BusCollection myBusCollection, ref List<BusStop> myUniqueStops)
        {
            BusStop ret = new BusStop();
            int realChoice = 0;
            string choice = "";
            bool keyOk = false;
            while (!keyOk)
            {
                Console.WriteLine("enter bus station key");
                ret.m_mylocation.m_busStationKey = Program_6077_5711_01.getInt(choice, ref realChoice);
                if (myBusCollection.keyExist(realChoice))
                {
                    Console.WriteLine("ERROR bus key taken!!");
                }
                else
                    keyOk = true;
            }
            if (!myBusCollection.keyExist(ret.m_mylocation.m_busStationKey))
            {
                myBusCollection.m_BusKeysList.Add(ret.m_mylocation.m_busStationKey);
                myUniqueStops.Add(ret);
            }
            return ret;
        }
        /// <summary>
        /// User menu
        /// </summary>
        /// <param name="myBusCollection">the Collection of all the bus</param>
        public static void LineManagement(ref BusCollection myBusCollection)
        {
            
            List<BusStop> myUniqueStops = new List<BusStop>();
            initializeBusRoute(ref myBusCollection, ref myUniqueStops);
            bool NotEnd = true;
            int countBus = 0;
            BusStop firstStop = new BusStop(), lastStop = new BusStop(), addeDStop = new BusStop();
            BusCollection pathCollection = new BusCollection();
            while (NotEnd)
            {
                Console.WriteLine("OPTIONS:\n1: ADD\n2: DELETE\n3: SEARCH\n4: PRINT \n5: EXIT");
                string choice = "";
                int realChoice = 0, placeAdd = 0;
                realChoice = Program_6077_5711_01.getInt(choice, ref realChoice);
                switch (realChoice)
                {
                    case (int)menuChoice.ADD:
                        Console.WriteLine("1: add bus Stop\n2: add busLine");
                        realChoice = Program_6077_5711_01.getInt(choice, ref realChoice);
                        switch (realChoice)
                        {
                        
                            case (int)menuAdd.ADD_BUS_STOP:
                                do
                                {
                                    Console.WriteLine("enter busLine range 0 - {0}:\n", myBusCollection.m_BusCollectionList.Count);
                                    placeAdd = Program_6077_5711_01.getInt(choice, ref realChoice);
                                    if (placeAdd > myBusCollection.m_BusCollectionList.Count || placeAdd < 0)
                                        Console.WriteLine("ERROR");
                                } while (placeAdd > myBusCollection.m_BusCollectionList.Count || placeAdd < 0);
                                addeDStop = GetBusStop(myBusCollection, ref myUniqueStops);
                                try
                                {
                                    myBusCollection[placeAdd].add(addeDStop, myBusCollection[placeAdd].m_Stations.Count);
                                }
                                catch (IndexOutOfRangeException ex)
                                {

                                    Console.WriteLine(ex.Message);
                                }
                                break;
                            case (int)menuAdd.ADD_BUS_ROUTE:
                                {
                                    myBusCollection.addBusRoute(GetBusRoute(myBusCollection, ref myUniqueStops));
                                }
                                break;
                            default:
                                Console.WriteLine("wrong choice!!!");
                                break; 
                        }
                        break;
                    case (int)menuChoice.ERASE:
                        BusRoute temp = new BusRoute();
                        Console.WriteLine("enter 1 to erase bus route  2 - to erase stope");
                        realChoice = Program_6077_5711_01.getInt(choice, ref realChoice);
                        switch (realChoice)
                        {
                            case (int)menuDelete.DELETE_BUS_ROUTE:
                                Console.WriteLine("enter bus line key to be deleted:");
                                realChoice = Program_6077_5711_01.getInt(choice, ref realChoice);
                                try
                                {
                                    myBusCollection.deleteBusRouteKey(realChoice);
                                }
                                catch (Exception ex)
                                {

                                    Console.WriteLine(ex.Message); ;
                                }
                                break;
                            case (int)menuDelete.DELETE_STOP:
                                Console.WriteLine("enter the line number details at the station for deletion");
                                FindAndDelete(myBusCollection, ref myUniqueStops);
                                break;
                            default:
                                Console.WriteLine("wrong choice!!!");
                                break;
                        }
                        break;
                    case (int)menuChoice.SEARCH:
                        Console.WriteLine("1: print all busses that pass in a bus stop\n2:find all paths");
                        realChoice = Program_6077_5711_01.getInt(choice, ref realChoice);
                        switch (realChoice)
                        {
                            case (int)menuSearch.LINES_THAT_PASS_IN_STOP:
                                Console.WriteLine("enter bus stop key:");
                                realChoice = Program_6077_5711_01.getInt(choice, ref realChoice);
                                foreach (BusRoute bus in myBusCollection.BusStopList(realChoice))
                                {
                                    try
                                    {
                                        bus.print();
                                    }
                                    catch (ArgumentNullException ex)
                                    {
                                        Console.WriteLine(ex.Message); 
                                    }
                                }
                                break;
                            case (int)menuSearch.FIND_PATH:
                                do
                                {
                                    try
                                    {
                                        Console.WriteLine("enter first station key");
                                        realChoice = Program_6077_5711_01.getInt(choice, ref realChoice);
                                        firstStop = myBusCollection.retStop(realChoice);
                                        NotEnd = true;
                                    }
                                    catch (NotFoundkey exception)
                                    {
                                        Console.WriteLine(exception.Message);
                                        NotEnd = false;
                                    }
                                } while (!NotEnd);
                                do
                                {
                                    try
                                    {
                                        Console.WriteLine("enter last station key");
                                        realChoice = Program_6077_5711_01.getInt(choice, ref realChoice);
                                        lastStop = myBusCollection.retStop(realChoice);
                                    }
                                    catch (NotFoundkey exception)
                                    {
                                        Console.WriteLine(exception.Message);
                                        NotEnd = false;
                                    }
                                } while (!NotEnd);
                                if (!(lastStop.m_distance == 0 || firstStop.m_distance == 0))
                                {
                                    foreach (BusRoute bus in myBusCollection)
                                    {
                                         pathCollection.addBusRoute(bus.Section(firstStop, lastStop));
                                    }
                                    foreach (BusRoute bus in pathCollection)
                                    {
                                        try
                                        {
                                            bus.print();
                                        }
                                        catch (ArgumentNullException ex)
                                        {

                                            Console.WriteLine(ex.Message); 
                                        }
                                        Console.WriteLine(bus.travelTime(bus.m_Stations[0], bus.m_Stations[bus.m_Stations.Count - 1]));
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("ERROR NO SUCH STOP");
                                }
                                break;
                            default:
                                Console.WriteLine("wrong choice!!!");
                                break;
                        }
                        break;
                    case (int)menuChoice.PRINT:
                        
                        try
                        {
                            Console.WriteLine("1: print all busses\n2:print all stops");
                            realChoice = Program_6077_5711_01.getInt(choice, ref realChoice);
                            switch (realChoice)
                            {
                                case (int)menuPrintInfo.printAllBusses:
                                    foreach (BusRoute bus in myBusCollection)
                                    {
                                        Console.WriteLine(bus);
                                    }
                                    break;
                                case (int)menuPrintInfo.printBusStopInfo:
                                    int countBus2 = 0;
                                    foreach (BusStop stop in myUniqueStops)
                                    {
                                        Console.WriteLine(stop);
                                        countBus2 = 0;
                                        foreach (BusRoute route in myBusCollection.BusStopList(stop.m_mylocation.m_busStationKey))
                                        {
                                            Console.WriteLine(route);
                                            countBus2++;
                                        }
                                        Console.WriteLine("");
                                    }
                                    break;
                                //case (int)menuPrintInfo.printAllInfo:
                                //    countBus = 0;

                                //    foreach (BusRoute bus in myBusCollection)
                                //    {
                                //        Console.WriteLine("bus number {0}", countBus);
                                //        try
                                //        {
                                //            bus.print();
                                //        }
                                //        catch (NullReferenceException ex)
                                //        {
                                //            Console.WriteLine(ex.Message);
                                //        }
                                //        Console.WriteLine("");
                                //        Console.WriteLine("###  BUS LIST: ###");
                                //        try
                                //        {
                                //            bus.printStops();
                                //        }
                                //        catch (NullReferenceException ex)
                                //        {
                                //            Console.WriteLine(ex.Message);
                                //        }
                                //        countBus++;
                                //    }
                                //    break;
                                default:
                                    Console.WriteLine("wrong choice!!!");
                                    break;
                            }
                        }
                        catch (ArgumentNullException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case (int)menuChoice.EXIT:
                        Console.WriteLine("bye bye!!!");
                        NotEnd = false;
                        break;
                    default:
                        Console.WriteLine("wrong choice please try again!");
                        break;
                }
            }
        }
        /// <summary>
        /// get a bus route from the user
        /// </summary>
        /// <param name="myBusCollection">the Collection of all the bus</param>
        /// <param name="myUniqueStops">a list of stop</param>
        /// <returns></returns>
        public static BusRoute GetBusRoute(BusCollection myBusCollection, ref List<BusStop> myUniqueStops)
        {
            BusStop temBusStop = new BusStop();
            int realChoice = 0;
            string choice = "";

            BusRoute temp = new BusRoute();

            Console.WriteLine("enter bus line:");
            realChoice = Program_6077_5711_01.getInt(choice, ref realChoice);
            while (realChoice <= 0)
            {
                Console.WriteLine("enter positive number");
                realChoice = Program_6077_5711_01.getInt(choice, ref realChoice);
            }
            temp.m_BusLine = realChoice;


            Console.WriteLine("enter firstStation:");
            temp.m_FirstStation = Console.ReadLine();


            Console.WriteLine("enter lastStation:");
            temp.m_LastStation = Console.ReadLine();

            Console.WriteLine("enter bus area:");
            temp.m_Area = Console.ReadLine();

            Console.WriteLine("enter list of bus stop:");
            realChoice = 1;

            do
            {
                Console.WriteLine("enter 1 to add more bus stop enter 2 to end");
                realChoice = Program_6077_5711_01.getInt(choice, ref realChoice);
                if (realChoice != 2)
                {
                    temBusStop = GetBusStop(myBusCollection, ref myUniqueStops);
                    temp.add(temBusStop, temp.m_Stations.Count);
                }
            } while (realChoice != 2);
            return temp;
        }
        /// <summary>
        /// find a specific stop and delete it
        /// </summary>
        /// <param name="myBusCollection">the Collection of all the bus</param>
        /// <param name="myUniqueStops">a list of stop</param>
        public static void FindAndDelete(BusCollection myBusCollection, ref List<BusStop> myUniqueStops)
        {
            int place = 0;
            string firstStation, lastStation;
            int tempBusLine;
            int realChoice = 0;
            string choice = "";

            Console.WriteLine("enter bus line:");
            realChoice = Program_6077_5711_01.getInt(choice, ref realChoice);
            while (realChoice <= 0)
            {
                Console.WriteLine("enter positive number");
                realChoice = Program_6077_5711_01.getInt(choice, ref realChoice);
            }
            tempBusLine = realChoice;


            Console.WriteLine("enter firstStation:");

            firstStation = Console.ReadLine();


            Console.WriteLine("enter lastStation:");

            lastStation = Console.ReadLine();

            foreach (BusRoute myBusRoute in myBusCollection)
            {
                if ((myBusRoute.m_BusLine == tempBusLine) && (myBusRoute.m_LastStation == lastStation) && (myBusRoute.m_FirstStation == firstStation))
                {
                    Console.WriteLine("what is the bus station key of this stop?");
                    realChoice = Program_6077_5711_01.getInt(choice, ref realChoice);
                    while (realChoice <= 0)
                    {
                        Console.WriteLine("enter positive number");
                        realChoice = Program_6077_5711_01.getInt(choice, ref realChoice);
                    }
                    foreach (BusStop stop in myBusRoute.m_Stations)
                    {
                        if (stop.m_mylocation.m_busStationKey == realChoice)
                        {
                            try
                            {
                                myBusRoute.delete(place);
                            
                            }
                            catch (ArgumentOutOfRangeException ex)
                            {
                                Console.WriteLine(ex.Message);                            }
                            break;
                        }
                        place++;
                    }
                }

            }
            foreach (BusStop stop in myUniqueStops)
            {
                if (stop.m_mylocation.m_busStationKey == realChoice)
                {
                    myUniqueStops.Remove(stop);
                    break;
                }
            }

        }
    }
}
