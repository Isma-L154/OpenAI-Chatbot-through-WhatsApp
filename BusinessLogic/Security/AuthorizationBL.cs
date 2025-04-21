using BusinessLogicInterfaces.Security;
using Entities.Security;
using EntitiesInterfaces.Commons;
using EntitiesInterfaces.Security;

namespace BusinessLogic.Security
{

     
    
    /// Class to manage authorization methods to loggin in this api services.

    public class AuthorizationBL : IAuthorizationBL
    {
        #region Global Data 

        /// Here you can find instances or global variables.
    
        private IAuthorizationDTO authorizationDTO;
        #endregion

        #region Constructor 

        /// Constructor for initializing the class with the configuration object.

        public AuthorizationBL() 
        {
            authorizationDTO = new AuthorizationDTO(); 
        }
        #endregion 

        #region  Get

        /// Method to validate credential sent of the other application.

        /// <param name="User">Here came user sent to another external application and also here came password sent to another external application.</param> 
        /// <@Return>This method return true if the credential are diferent ,other hand the method'll return false if both credential are de same .</param> 
        public bool Get(IUserDTO User)
        {
            if (User.UserName != authorizationDTO.UserName || User.Password != authorizationDTO.Password) 
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
