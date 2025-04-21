using EntitiesInterfaces.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesInterfaces.API
{
    public interface IOpenAiSettingsDTO
    {
         string Model { get; set; }
         double Temperature { get; set; }
         int MaxTokens { get; set; }
         bool UseSandbox { get; set; }
    }
}
