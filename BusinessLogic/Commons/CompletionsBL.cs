using BusinessLogic.API;
using BusinessLogic.Base;
using BusinessLogicInterfaces.API;
using BusinessLogicInterfaces.Commons;
using Entities.API;
using Entities.Base;
using Entities.Security;
using EntitiesInterfaces.API;
using EntitiesInterfaces.Base;
using EntitiesInterfaces.Commons.Enums;
using EntitiesInterfaces.Security;
using System.Text.Json;

namespace BusinessLogic.Commons
{
    public class CompletionsBL : BaseCommonsSettingsBL, ICompletionsBL
    {
        private IApiConfigurationBL apiConfigurationBL;
        private IOpenAiSettingsDTO openAiSettingsDTO;
        private IOpenAIAuthorizationDTO openAiAuthorizationDTO;
        private IOpenAiEndpointDTO openAiEndpointDTO;
        public CompletionsBL()
        {
            openAiSettingsDTO = new OpenAiSettingsDTO();
            openAiAuthorizationDTO = new OpenAIAuthorizationDTO();
            openAiEndpointDTO = new OpenAiEndpointDTO();
        }

        public IResponseDTO Post(string prompt)
        {
            IResponseDTO Response = new ResponseDTO();
            //In here we build the body of the request and 
            try
            {
                //Validation to know if we are using the sandbox
                if (openAiSettingsDTO.UseSandbox)
                {

                    Response.Result = ActionResult.Success;
                    Response.Value = "Simulación de respuesta en entorno Sandbox";
                    return Response;
                }

                var body = new
                {
                    model = openAiSettingsDTO.Model,
                    messages = new[]
                    {
                        //We give the Chatbot/System a context and also a validation so he can answer only in the context of develop
                        new { role = "system", content = "Eres un asistente experto en TI y desarrollo de software. No puedes responder preguntas fuera de este dominio. Si se te hace una pregunta fuera de TI, responde con algo generico negando la pregunta" },
                        new { role = "user", content = prompt } //Send the user prompt that we recieve as a parameter 
                    },
                    temperature = openAiSettingsDTO.Temperature,
                    max_tokens = openAiSettingsDTO.MaxTokens
                    
                };
                
                //Build the values of the  ApiConfig
                apiConfigurationBL = new ApiConfigurationBL
                {
                    Url = openAiEndpointDTO.Host + openAiEndpointDTO.Completions,
                    Method = HttpMethod.Post,
                    Content = body,
                    BaseAuthentication = openAiAuthorizationDTO.ApiKey
                };

                var result = apiConfigurationBL.Call();

                // Parse the JSON response to extract only the relevant data (the assistant's reply).
                using var doc = JsonDocument.Parse(result);

                // Access the "choices" array in the JSON response, which contains the model's reply.
                var content = doc.RootElement
                                 .GetProperty("choices")[0]          
                                 .GetProperty("message")             
                                 .GetProperty("content")             
                                 .GetString();                       

                Response.Result = ActionResult.Success;

                // Store the extracted response content (the assistant's reply) in the Value property.
                Response.Value = content?.Trim(); 

            }
            catch (Exception ex) {
                Response = ManageException(
                        new ExceptionDTO
                        {
                            Class  = this.GetType().Name,
                            Method = Method.Get.ToString(),
                            Error = ex.ToString(),
                        });
            }
            return Response;
        }
    }
}
