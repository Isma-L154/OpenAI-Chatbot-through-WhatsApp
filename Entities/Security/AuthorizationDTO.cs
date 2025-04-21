using EntitiesInterfaces.Security;
using Settings.Security;

namespace Entities.Security
{
     
     
    
    /// This class manages the authorization properties to loging in this API services.
     
    public class AuthorizationDTO : IAuthorizationDTO
    {
        public AuthorizationDTO() 
        {
        }
        public string UserName { get ; set ; }
        public string Password { get ; set ; }
    }
}
