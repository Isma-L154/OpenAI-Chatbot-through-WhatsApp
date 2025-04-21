using BusinessLogicInterfaces.Security;
using Entities.Security;
using EntitiesInterfaces.Commons;
using EntitiesInterfaces.Security;

namespace BusinessLogic.Security
{
    public class OpenAIAuthBL : IOpenAIAuthBL
    {
        #region Global Data 
        private readonly IOpenAIAuthorizationDTO _configAuth;
        #endregion

        #region Constructor 
        public OpenAIAuthBL() 
        {
            _configAuth = new OpenAIAuthorizationDTO(); 
        }
        #endregion 

        #region  Get
        public bool IsAuthorized(IOpenAIAuthorizationDTO authDto)
        {
            if (authDto.ApiKey != _configAuth.ApiKey) {
                return false;
            }
            return true;
        }
        #endregion
    }
}
