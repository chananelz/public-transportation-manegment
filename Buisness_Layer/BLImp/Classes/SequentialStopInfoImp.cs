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
    public partial class BL : IBL
    {
        public void CreateSequentialStopInfo(int stationCodeF, int stationCodeS, float distance, TimeSpan averageTime, TimeSpan travelTime)
        {
            SequentialStopInfo SequentialStopInfoBO = new SequentialStopInfo(stationCodeF, stationCodeS, distance, averageTime, travelTime);
            DO.SequentialStopInfo SequentialStopInfoDO = SequentialStopInfoBO.GetPropertiesFrom<DO.SequentialStopInfo, BO.SequentialStopInfo>();
            dal.CreateSequentialStopInfo(SequentialStopInfoDO);
        }
        public SequentialStopInfo RequestSequentialStopInfo(long fid, long sid)
        {
            DO.SequentialStopInfo SequentialStopInfoDO = new DO.SequentialStopInfo();
            SequentialStopInfoDO = dal.RequestSequentialStopInfo(fid, sid);
            BO.SequentialStopInfo SequentialStopInfoBO = SequentialStopInfoDO.GetPropertiesFrom<BO.SequentialStopInfo, DO.SequentialStopInfo>();
            return SequentialStopInfoBO;
        }
        public void UpdateSequentialStopInfo(int stationCodeF, int stationCodeS, float distance, TimeSpan averageTime, TimeSpan travelTime)
        {
            SequentialStopInfo SequentialStopInfoBO = new SequentialStopInfo(stationCodeF, stationCodeS, distance, averageTime, travelTime);
            DO.SequentialStopInfo SequentialStopInfoDO = SequentialStopInfoBO.GetPropertiesFrom<DO.SequentialStopInfo, BO.SequentialStopInfo>();
            dal.UpdateSequentialStopInfo(SequentialStopInfoDO);
        }
        public void DeleteSequentialStopInfo(int stationCodeF, int stationCodeS, float distance, TimeSpan averageTime, TimeSpan travelTime)
        {
            SequentialStopInfo SequentialStopInfoBO = new SequentialStopInfo(stationCodeF, stationCodeS, distance, averageTime, travelTime);
            DO.SequentialStopInfo SequentialStopInfoDO = SequentialStopInfoBO.GetPropertiesFrom<DO.SequentialStopInfo, BO.SequentialStopInfo>();
            dal.DeleteSequentialStopInfo(SequentialStopInfoDO);
        }
    }
}
