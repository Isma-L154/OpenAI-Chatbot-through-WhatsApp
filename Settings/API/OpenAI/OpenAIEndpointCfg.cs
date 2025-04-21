using Microsoft.Extensions.Configuration;
using Settings.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Settings.API.OpenAI
{
    public enum OpenAIEndpointType
    {
        Host,
        Completions
    }

    public class OpenAIEndpointCfg : BaseSettings
    {
        #region Global Data 

        private readonly IConfiguration _configuration;
        #endregion

        #region Constructor 
        public OpenAIEndpointCfg()
        {
            _configuration = this.GetConfiguration();
        }
        #endregion

        #region Get 
        /// <param name="openAiEndpointType">Represents a set of keys located in appsetting.</param> 
        public string Get(OpenAIEndpointType openAiEndpointType)
        {
            // Get the active profile from the configuration
            string profile = _configuration["Profile"];

            // Search for the configuration in the active profile and all defined profiles
            string value = GetFromProfile(profile, openAiEndpointType);

            // If the value is not found in the active profile, search in all profiles (without explicit ifs)
            if (string.IsNullOrEmpty(value))
            {
                value = _configuration.GetChildren()
                    .Where(section => section.Key != "Profile") // Exclude "Profile" from the list
                    .Select(section => GetFromProfile(section.Key, openAiEndpointType))
                    .FirstOrDefault(val => !string.IsNullOrEmpty(val)); // Get the first non-null value
            }

            // If no value is found, throw an exception
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception($"The property {openAiEndpointType} was not found in any profile.");
            }

            return value;
        }
        #endregion

        #region GetFromProfile 
        /// <param name="openAiEndpointType">Represents a set of keys located in appsetting.</param>  
        /// <param name="profile">Here came key of profile of appsettings.</param>  
        private string GetFromProfile(string profile, OpenAIEndpointType openAiEndpointType)
        {
            // Get the section corresponding to the profile
            var section = _configuration.GetSection(profile);

            // Get the name of the current class dynamically using reflection
            string className = this.GetType().Name;

            // Build the dynamic property name based on the class name and authorization type
            string propertyName = $"{className}{openAiEndpointType}";

            // Search for the value corresponding to the dynamic property name
            return section[propertyName];
        }
        #endregion
    }
}
