using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalApi;
using DS;
using DO;

namespace DL
{
    public partial class DLObject : IDal
    {
        /// <summary>
        /// add new sequentialStopInfo to database
        /// </summary>
        /// <param name="sequentialStopInfo"></param>
        public void CreateSequentialStopInfo(SequentialStopInfo sequentialStopInfo)
        {
            sequentialStopInfo.Valid = true;
            try
            {
                GetSequentialStopInfo(sequentialStopInfo.StationCodeF, sequentialStopInfo.StationCodeS);
            }
            catch (Exception ex)
            {
                if (ex.Message == "no SequentialStopInfo with such license number!!")
                    DataSource.SequentialStopInfoList.Add(sequentialStopInfo);
                else if (ex.Message == "SequentialStopInfoList is not valid!!")
                {
                    DataSource.SequentialStopInfoList.Find(seqStopInf => seqStopInf.StationCodeF == sequentialStopInfo.StationCodeF && seqStopInf.StationCodeS == sequentialStopInfo.StationCodeS).Valid = true;
                }
                return;
            }
            throw new Exception("Sequential stop already exists!!!");
        }
        /// <summary>
        /// request a SequentialStopInfo according to a predicate
        /// </summary>
        /// <param name="firstId"></param>
        /// <param name="secondId"></param>
        /// <returns></returns>
        public SequentialStopInfo RequestSequentialStopInfo(Predicate<SequentialStopInfo> pr)
        {
            SequentialStopInfo ret = DataSource.SequentialStopInfoList.Find(seqStop => pr(seqStop));
            if (ret == null)
                    throw new Exception("no seqStop that meets these conditions!" + pr.ToString());
            if (ret.Valid == false)
                throw new Exception("seqStop that meets these conditions is not valid");
            return ret.GetPropertiesFrom<SequentialStopInfo, SequentialStopInfo>();
        }
        /// <summary>
        /// update sequentialStopInfo in database
        /// </summary>
        /// <param name="sequentialStopInfo"></param>
        public void UpdateSequentialStopInfoDistance(long firstId, long secondId, double distance)
        {
            GetSequentialStopInfo(firstId, secondId).Distance = distance;
        }
        public void UpdateSequentialStopInfoTravelTime(long firstId, long secondId, TimeSpan travelTime)
        {
            GetSequentialStopInfo(firstId, secondId).TravelTime = travelTime;
        }

        /// <summary>
        /// sets sequential  stop info valid to false
        /// </summary>
        /// <param name="sequentialStopInfo"></param>
        public void DeleteSequentialStopInfo(long firstId, long secondId)
        {
            GetSequentialStopInfo(firstId, secondId).Valid = false;
        }
        /// <summary>
        /// gets all stops info
        /// </summary>
        /// <param name="pr"></param>
        /// <returns></returns>
        public IEnumerable<SequentialStopInfo> GetAllSequentialStopInfo()
        {
            var cloneList = new List<SequentialStopInfo>();
            foreach (SequentialStopInfo seqStop in DataSource.SequentialStopInfoList)
            {
                if (seqStop.Valid == true)
                    cloneList.Add(seqStop.GetPropertiesFrom<SequentialStopInfo, SequentialStopInfo>());
            }
            return cloneList;
        }
        public SequentialStopInfo GetSequentialStopInfo(long fCode, long sCode)
        {
            //var t = from seqStop in DataSource.SequentialStopInfoList
            //        where (seqStop.StationCodeF == fCode && seqStop.StationCodeS == sCode)
            //        select seqStop;
            //if (t.ToList().Count == 0)
            //    throw new Exception("no SequentialStopInfo with such license number!!");
            //if (!t.First().Valid)
            //    throw new Exception("SequentialStopInfoList is not valid!!");
            return RequestSequentialStopInfo(seqStop =>  seqStop.StationCodeF == fCode && seqStop.StationCodeS == sCode);
        }
    }
}