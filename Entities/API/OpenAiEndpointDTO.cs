using EntitiesInterfaces.API;
using Settings.API.OpenAI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.API
{
    //We separate our code in different DTO, this holds the specific config for the Endpoints of OpenAI API
    public class OpenAiEndpointDTO : IOpenAiEndpointDTO
    {
        // Constructor that initializes the endpoint properties by retrieving values from configuration.
        public OpenAiEndpointDTO()
        {
            var cfg = new OpenAIEndpointCfg();

            this.Host = cfg.Get(OpenAIEndpointType.Host);
            this.Completions = cfg.Get(OpenAIEndpointType.Completions);
        }
        public string Completions { get; set; }
        public string Host { get; set; }
    }
}
