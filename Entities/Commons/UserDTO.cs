using EntitiesInterfaces.Commons;

namespace Entities.Commons
{
     
     
    
    /// Class manage the user properties.
     
    public class UserDTO : IUserDTO
    {        
        public string UserName { get ; set ; }
        public string Password { get ; set ; }
    }
}
