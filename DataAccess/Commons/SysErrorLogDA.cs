using DataAccess.DataModel.DracarysModel;
using DataAccessInterface.Commons;
using Entities.Commons;
using EntitiesInterfaces.Base;

namespace DataAccess.Commons
{
     
     
    
    /// 
    /// This class manages the syserrorlog CRUD.
     
    public class SysErrorLogDA : ISysErrorLogDA
    {
        #region Save 
                 
         
         
        /// Method to save the system error log inside data base.  
        /// 
        /// To do: there are an error loading the  dracarys context, I have to review this code in this moment
         
        /// <param name="exceptionDTO">Here came the exception information about error.</param> 
        public int Save(IExceptionDTO exceptionDTO)
        {
            try
            {
                using (DracarysContext context = new DracarysContext(new DataBaseDTO()))
                {
                    return context.UspSaveSysErrorLog(exceptionDTO.HostName, exceptionDTO.Error, exceptionDTO.Class, exceptionDTO.Method, exceptionDTO.CurrentDate, exceptionDTO.IsEnable);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
                 
        }
        #endregion
    }
}
