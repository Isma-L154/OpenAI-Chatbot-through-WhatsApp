using EntitiesInterfaces.Base;

namespace DataAccessInterface.Commons
{
     
     
    
    /// 
    /// This interface manages the syserrorlog CRUD.
     
    public interface ISysErrorLogDA
    {
        #region Save 
                 
         
         
        /// Method to save the system error log inside data base.  
         
        /// <param name="exceptionDTO">Here came the exception information about error.</param> 
        public int Save(IExceptionDTO exceptionDTO);
        #endregion
    }
}
