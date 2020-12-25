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
        public void CreateSequentialStopInfo(SequentialStopInfo sequentialStopInfo)
        {
            DataSource.SequentialStopInfoList.Add(sequentialStopInfo);
        }
        public SequentialStopInfo RequestSequentialStopInfo(long firstId, long secondId)
        {
            return DataSource.SequentialStopInfoList.Find(s => s.stationCodeF == firstId && s.stationCodeS == secondId);
        }
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
        public void DeleteSequentialStopInfo(SequentialStopInfo sequentialStopInfo)
        {
            if (sequentialStopInfo.stationCodeF != null && sequentialStopInfo.stationCodeS != null)
                DataSource.SequentialStopInfoList.Remove(sequentialStopInfo);
            else
                throw new Exception("sequentialStopInfo doesn't exist!!");
        }
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
