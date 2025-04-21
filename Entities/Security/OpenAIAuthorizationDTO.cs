
using EntitiesInterfaces.Security;
using Settings.Security;

namespace Entities.Security
{
    //We separate our code in different DTO, this holds the specific config for the Bearer Auth -> API KEY, we need so send to the OpenAI API
    public class OpenAIAuthorizationDTO : IOpenAIAuthorizationDTO
    {
        //In this construcutor you should call the API Key from Settings and set the value, in this case, for security purposes this constructor is using 
        // a env variable for the Api Key
        public OpenAIAuthorizationDTO()
        {
            this.ApiKey = Environment.GetEnvironmentVariable("OPEN_AI_APIKEY");
        }
        public string ApiKey { get; set; }
    }
}
