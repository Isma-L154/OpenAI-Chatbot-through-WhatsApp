using EntitiesInterfaces.Commons;
using EntitiesInterfaces.Security;

namespace BusinessLogicInterfaces.Security
{
    public interface IOpenAIAuthBL
    {
        bool IsAuthorized(IOpenAIAuthorizationDTO authDto);
    }
}
