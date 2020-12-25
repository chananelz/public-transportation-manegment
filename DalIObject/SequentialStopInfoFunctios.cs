using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ds;
using DalApi;
using DO;


namespace DalObject
{
    public partial class DOImp : IDal
    {
        public void CreateSequentialStopInfo(SequentialStopInfo sequentialStopInfo)
        {
            DataSource.Sequential_Stop_InfoList.Add(sequentialStopInfo);
        }
        public SequentialStopInfo RequestSequentialStopInfo(long firstId,long secondId)
        {
            return DataSource.Sequential_Stop_InfoList.Find(s=>s.stationCodeF == firstId && s.stationCodeS == secondId);
        }
        public void UpdateSequentialStopInfo(SequentialStopInfo sequentialStopInfo)
        {
            int indLine;
            if (sequentialStopInfo.stationCodeF != null && sequentialStopInfo.stationCodeS != null)
            {
                indLine = DataSource.Sequential_Stop_InfoList.FindIndex(s => s.stationCodeF == sequentialStopInfo.stationCodeF && s.stationCodeS == sequentialStopInfo.stationCodeS);
                DataSource.Sequential_Stop_InfoList[indLine] = sequentialStopInfo;
            }
            else
                throw new Exception("sequentialStopInfo doesn't exist!!");
        }
        public void DeleteSequentialStopInfo(SequentialStopInfo sequentialStopInfo)
        {
            if (sequentialStopInfo.stationCodeF != null && sequentialStopInfo.stationCodeS != null)
                DataSource.Sequential_Stop_InfoList.Remove(sequentialStopInfo);
            else
                throw new Exception("sequentialStopInfo doesn't exist!!");
        }
        public IEnumerable<SequentialStopInfo> GetAll_StopsInfo(Func<SequentialStopInfo, bool> predicate = null)
        {
            return from b in DataSource.Sequential_Stop_InfoList
                   where (predicate(b))
                   select b;
        }
    }
}
