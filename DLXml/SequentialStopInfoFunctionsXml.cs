using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DalApi;
using DO;


namespace DL
{
    public partial class DLXML : IDal
    {


        #region SequentialStopInfo

        /// <summary>
        /// add new sequentialStopInfo to database
        /// </summary>
        /// <param name="sequentialStopInfo"></param>
        public void CreateSequentialStopInfo(SequentialStopInfo sequentialStopInfo)
        {

            List<SequentialStopInfo> SequentialStopInfoList = XMLTools.LoadListFromXMLSerializer<SequentialStopInfo>(sequentialStopInfoPath);
            sequentialStopInfo.Valid = true;
            try
            {
                GetSequentialStopInfo(sequentialStopInfo.StationCodeF, sequentialStopInfo.StationCodeS);
            }
            catch (Exception ex)
            {
                if (ex.Message == "no SequentialStopInfo with such license number!!")
                    SequentialStopInfoList.Add(sequentialStopInfo);
                else if (ex.Message == "SequentialStopInfoList is not valid!!")
                {
                    SequentialStopInfoList.Find(seqStopInf => seqStopInf.StationCodeF == sequentialStopInfo.StationCodeF && seqStopInf.StationCodeS == sequentialStopInfo.StationCodeS).Valid = true;
                }
                XMLTools.SaveListToXMLSerializer(SequentialStopInfoList, sequentialStopInfoPath);
                return;
            }
            throw new Exception("bus already exists!!!");
        }

        /// <summary>
        /// request a SequentialStopInfo according to a predicate
        /// </summary>
        /// <param name="firstId"></param>
        /// <param name="secondId"></param>
        /// <returns></returns>
        public SequentialStopInfo RequestSequentialStopInfo(Predicate<SequentialStopInfo> pr)
        {
            List<SequentialStopInfo> SequentialStopInfoList = XMLTools.LoadListFromXMLSerializer<SequentialStopInfo>(sequentialStopInfoPath);
            SequentialStopInfo ret = SequentialStopInfoList.Find(seqStop => pr(seqStop));
            if (ret == null)
                throw new Exception("no seqStop that meets these conditions!");
            if (ret.Valid == false)
                throw new Exception("seqStop that meets these conditions is not valid");
            return ret;
        }

        /// <summary>
        /// update sequentialStopInfo in database
        /// </summary>
        /// <param name="sequentialStopInfo"></param>

        public void UpdateSequentialStopInfoDistance(long firstId, long secondId, double distance)
        {
            List<SequentialStopInfo> SequentialStopInfoList = XMLTools.LoadListFromXMLSerializer<SequentialStopInfo>(sequentialStopInfoPath);
            GetSequentialStopInfo(firstId, secondId);
            SequentialStopInfoList.Find(seqStopInf => seqStopInf.StationCodeF == firstId && seqStopInf.StationCodeS == secondId).Distance = distance;
            XMLTools.SaveListToXMLSerializer(SequentialStopInfoList, sequentialStopInfoPath);

        }

        /// <summary>
        /// update sequentialStopInfo in database
        /// </summary>
        /// <param name="sequentialStopInfo"></param>
        public void UpdateSequentialStopInfoTravelTime(long firstId, long secondId, TimeSpan travelTime)
        {
            List<SequentialStopInfo> SequentialStopInfoList = XMLTools.LoadListFromXMLSerializer<SequentialStopInfo>(sequentialStopInfoPath);
            GetSequentialStopInfo(firstId, secondId);
            SequentialStopInfoList.Find(seqStopInf => seqStopInf.StationCodeF == firstId && seqStopInf.StationCodeS == secondId).TravelTime = travelTime;
            XMLTools.SaveListToXMLSerializer(SequentialStopInfoList, sequentialStopInfoPath);
        }


        /// <summary>
        /// sets sequential  stop info valid to false
        /// </summary>
        /// <param name="sequentialStopInfo"></param>
        public void DeleteSequentialStopInfo(long firstId, long secondId)
        {
            List<SequentialStopInfo> SequentialStopInfoList = XMLTools.LoadListFromXMLSerializer<SequentialStopInfo>(sequentialStopInfoPath);
            GetSequentialStopInfo(firstId, secondId);
            SequentialStopInfoList.Find(seqStopInf => seqStopInf.StationCodeF == firstId && seqStopInf.StationCodeS == secondId).Valid = false;
            XMLTools.SaveListToXMLSerializer(SequentialStopInfoList, sequentialStopInfoPath);
        }

        /// <summary>
        /// gets all stops info
        /// </summary>
        /// <param name="pr"></param>
        /// <returns></returns>
        public IEnumerable<SequentialStopInfo> GetAllSequentialStopInfo()
        {
            List<SequentialStopInfo> SequentialStopInfoList = XMLTools.LoadListFromXMLSerializer<SequentialStopInfo>(sequentialStopInfoPath);
            var myList = new List<SequentialStopInfo>();
            foreach (SequentialStopInfo seqStop in SequentialStopInfoList)
            {
                if (seqStop.Valid == true)
                    myList.Add(seqStop);
            }
            return myList;

        }

        public SequentialStopInfo GetSequentialStopInfo(long fCode, long sCode)
        {
            List<SequentialStopInfo> SequentialStopInfoList = XMLTools.LoadListFromXMLSerializer<SequentialStopInfo>(sequentialStopInfoPath);
            var t = from seqStop in SequentialStopInfoList
                    where (seqStop.StationCodeF == fCode && seqStop.StationCodeS == sCode)
                    select seqStop;
            if (t.ToList().Count == 0)
                throw new Exception("no SequentialStopInfo with such license number!!");
            if (!t.First().Valid)
                throw new Exception("SequentialStopInfoList is not valid!!");
            return t.ToList().First();
        }

        #endregion

    }
}
