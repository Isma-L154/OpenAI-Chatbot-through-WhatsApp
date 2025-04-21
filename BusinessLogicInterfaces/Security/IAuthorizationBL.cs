using EntitiesInterfaces.Commons;
using EntitiesInterfaces.Security;

namespace BusinessLogicInterfaces.Security
{
     
     
    
    /// Interface to manage authorization methods to loggin in this api services.
     
    public interface IAuthorizationBL
    {
        #region  Get
         
         
        
        /// Method to validate credential sent of the other application.
         
        /// <param name="User">Here came user sent to another external application and also here came password sent to another external application.</param> 
        /// <@Return>This method return true if the credential are de same,  other hand the method'll return false .</param> 
        bool Get(IUserDTO User);
        #endregion
    }
}
