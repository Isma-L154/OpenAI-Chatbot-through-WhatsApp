using Entities.Commons;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DataModel.DracarysModel
{
     
     
    
    /// Class to execute stored procedures for the Dracarys database.
     
    public partial class DracarysContext : DbContext
    {
        public readonly DracarysContext _context = new DracarysContext(new DataBaseDTO());
        

        #region SaveSysErrorLog
         
         
        
        /// Executes the stored procedure to insert a new SysErrorLog entry.
         
        /// <param name="Host">The host or server name where the error occurred.</param>
        /// <param name="ErrorMessage">The error message to log.</param>
        /// <param name="CreatedDate">The timestamp of when the error occurred.</param>
        /// <param name="IsEnable">A boolean indicating if the log entry is enabled.</param>
        /// <returns>The result of the stored procedure execution.</returns>
        public int UspSaveSysErrorLog(string Host, string ErrorMessage, string ClassName, string MethodName, DateTime CreatedDate, bool IsEnable)
        {
            // Executes the stored procedure and returns the result
            return _context.Database.ExecuteSqlRaw("EXEC [dbo].[USP_SaveSysErrorLog] @Host, @ErrorMessage, @Class, @Method, @CreatedDate, @IsEnable", Host, ErrorMessage, ClassName, MethodName, CreatedDate, IsEnable);
        }
        #endregion
    }


}
