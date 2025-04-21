using EntitiesInterfaces.API;
using Settings.API.OpenAI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.API
{
    //We separate our code in different DTO, this holds the specific config for the Settings we need so send to the OpenAI API
    public class OpenAiSettingsDTO : IOpenAiSettingsDTO
    {
        // Constructor that initializes the endpoint properties by retrieving values from configuration.
        public OpenAiSettingsDTO()
        {
            var cfg = new OpenAICfg();

            this.Model = cfg.Get(OpenAIType.Model);
            this.Temperature = double.Parse(cfg.Get(OpenAIType.Temperature));
            this.MaxTokens = int.Parse(cfg.Get(OpenAIType.MaxTokens));
            this.UseSandbox = bool.Parse(cfg.Get(OpenAIType.UseSandbox));
        }

        public string Model { get; set; }
        public double Temperature { get; set; }
        public int MaxTokens { get; set; }
        public bool UseSandbox { get; set; }
    }
}
