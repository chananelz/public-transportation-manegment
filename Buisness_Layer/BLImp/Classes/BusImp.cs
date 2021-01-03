using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalApi;
using BLApi;
using BO;
using BL;
//ne


namespace BLImp
{
    public partial class BL : IBL
    {
        public void CreateBus(long licenseNumber, DateTime dateTime, float kM, float fuel, int statusInput)
        {

            string exception = "";
            bool foundException = false;
            try
            {
                valid.GoodLicense(licenseNumber, dateTime);
            }
            catch (BOBadBusIdException ex)
            {
                exception += ex.Message;
                foundException = true;
            }
            try
            {
                valid.ExistLicenseNumber(licenseNumber);
            }
            catch (BOBadBusIdException ex)
            {
                if (!foundException)
                {
                    exception += ex.Message;
                    foundException = true;
                }
            }
            try
            {
                valid.GoodFuel(fuel);
            }
            catch (BOBusException ex)
            {
                exception += ex.Message;
                foundException = true;
            }

            try
            {
                valid.GoodStatus(statusInput);
            }
            catch (BOBusException ex)
            {
                exception += ex.Message;
                foundException = true;
            }

            try
            {
                valid.GoodFloat(kM);
            }
            catch (BOBusException ex)
            {
                exception += ex.Message;
                foundException = true;
            }
            if (foundException)
                throw new BOBusException("There is something wrong with your input." + "Please Check these things :\n" + exception);  //להוסיף את האינפוט שלו עם דולר
            Bus busBO = new Bus(licenseNumber, dateTime, kM, fuel, statusInput);
            DO.Bus busDO = busBO.GetPropertiesFrom<DO.Bus, BO.Bus>();
            try
            {
                dal.CreateBus(busDO);
            }
            catch (DO.DOBadBusIdException ex)
            {

                throw new BODOBadBusIdException("cant create this bus" , ex);
            }
          
        }
        public Bus RequestBus(Predicate<Bus> pr)
        {
            try
            {
                return dal.RequestBus(bus => pr(bus.GetPropertiesFrom<BO.Bus, DO.Bus>())).GetPropertiesFrom<BO.Bus, DO.Bus>();
            }
            catch (DO.DOBusException ex)
            {

                throw  new BODOBadBusIdException("can't find this bus", ex) ;
            }
            
        }

        public void UpdateBusKM(float kM, long licenseNumber)
        {
            try
            {
                valid.GoodFloat(kM);
            }
            catch (BOBusException ex)
            {

                throw new BOBusException(ex.Message);
            }

            try
            {
                dal.UpdateBusKM(kM, licenseNumber);
            }
            catch (DO.DOBadBusIdException ex)
            {

                throw new BODOBadBusIdException("",ex);
            }
        }

        public void UpdateBusFuel(float fuel, long licenseNumber)
        {
            try
            {
                valid.GoodFuel(fuel);
            }
            catch (BOBusException ex)
            {

                throw new BOBusException(ex.Message);
            }

            try
            {
                dal.UpdateBusFuel(fuel, licenseNumber);
            }
            catch (DO.DOBadBusIdException ex)
            {

                throw new BODOBadBusIdException("", ex);
            }


        }

        public void UpdateBusStatus(int st, long licenseNumber)
        {
            try
            {
                valid.GoodStatus(st);
            }
            catch (BOBusException ex)
            {

                throw new BOBusException(ex.Message);
            }

            try
            {
                dal.UpdateBusStatus(st, licenseNumber);
            }
            catch (DO.DOBadBusIdException ex)
            {

                throw new BODOBadBusIdException("", ex);
            }
        }


        public void DeleteBus(long licenseNumber)
        {
            try
            {
                dal.DeleteBus(licenseNumber);
            }
            catch (DO.DOBadBusIdException ex)
            {

                throw new BODOBadBusIdException("", ex);
            }
        }
        public Bus GetBus(long licenseNumber)
        {
            return dal.GetBus(licenseNumber).GetPropertiesFrom<BO.Bus, DO.Bus>();
        }

        public IEnumerable<Bus> GetAllBusses(Predicate<Bus> pr = null)
        {
            if (pr == null)
            {
                return dal.GetAllBusses().Select(bus => bus.GetPropertiesFrom<BO.Bus, DO.Bus>()).ToList(); ;
            }
            return dal.GetAllBusses().Select(bus => bus.GetPropertiesFrom<BO.Bus, DO.Bus>()).Where(b => pr(b));
        }
        public IEnumerable<Bus> GetAllBussesReadyForDrive()
        { 
            return GetAllBusses(bus => bus.Status == BO.status.READY_FOR_DRIVE);
        }
        
    }
}
