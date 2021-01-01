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
            DataSource.SequentialStopInfoList.Add(sequentialStopInfo);
        }
        /// <summary>
        /// request a SequentialStopInfo according to a predicate
        /// </summary>
        /// <param name="firstId"></param>
        /// <param name="secondId"></param>
        /// <returns></returns>
        public SequentialStopInfo RequestSequentialStopInfo(long firstId, long secondId)
        {
            return DataSource.SequentialStopInfoList.Find(s => s.stationCodeF == firstId && s.stationCodeS == secondId);
        }
        /// <summary>
        /// update sequentialStopInfo in database
        /// </summary>
        /// <param name="sequentialStopInfo"></param>
        public void UpdateSequentialStopInfo(SequentialStopInfo sequentialStopInfo)
        {
            int indLine;
            if (sequentialStopInfo.stationCodeF != null && sequentialStopInfo.stationCodeS != null)
            {
                indLine = DataSource.SequentialStopInfoList.FindIndex(s => s.stationCodeF == sequentialStopInfo.stationCodeF && s.stationCodeS == sequentialStopInfo.stationCodeS);
                DataSource.SequentialStopInfoList[indLine] = sequentialStopInfo;
            }
            else
                throw new Exception("sequentialStopInfo doesn't exist!!");
        }
        /// <summary>
        /// sets sequential  stop info valid to false
        /// </summary>
        /// <param name="sequentialStopInfo"></param>
        public void DeleteSequentialStopInfo(SequentialStopInfo sequentialStopInfo)
        {
            if (sequentialStopInfo.stationCodeF != null && sequentialStopInfo.stationCodeS != null)
                DataSource.SequentialStopInfoList.Remove(sequentialStopInfo);
            else
                throw new Exception("sequentialStopInfo doesn't exist!!");
        }
        /// <summary>
        /// gets all stops info
        /// </summary>
        /// <param name="pr"></param>
        /// <returns></returns>
        public IEnumerable<SequentialStopInfo> GetAllStopsInfo(Predicate<SequentialStopInfo> pr = null)
        {
            if (pr == null)
                return DataSource.SequentialStopInfoList;
            else
            return from b in DataSource.SequentialStopInfoList
                   where (pr(b))
                   select b;
        }
    }
}
