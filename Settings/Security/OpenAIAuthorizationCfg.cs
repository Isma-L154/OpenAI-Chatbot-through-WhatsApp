using Microsoft.Extensions.Configuration;
using Settings.Commons;
namespace Settings.Security
{
    #region Enums 
    public enum OpenAIAuthorizationType
    {
        ApiKey
    }
    #endregion
    public class OpenAIAuthorizationCfg : BaseSettings
    {
        #region Global Data   
        private readonly IConfiguration _configuration;
        #endregion

        #region Constructor 
        /// <param name="configuration">Represents a set of key/value application configuration properties.</param> 
        public OpenAIAuthorizationCfg()
        {
            _configuration = this.GetConfiguration();
        }
        #endregion

        #region Get 
        /// <param name="authorizationType">Represents a set of keys located in appsetting.</param> 
        public string Get(OpenAIAuthorizationType authorizationType)
        {
            // Get the active profile from the configuration
            string profile = _configuration["Profile"];

            // Search for the configuration in the active profile and all defined profiles
            string value = GetFromProfile(profile, authorizationType);

            // If the value is not found in the active profile, search in all profiles (without explicit ifs)
            if (string.IsNullOrEmpty(value))
            {
                value = _configuration.GetChildren()
                    .Where(section => section.Key != "Profile") // Exclude "Profile" from the list
                    .Select(section => GetFromProfile(section.Key, authorizationType))
                    .FirstOrDefault(val => !string.IsNullOrEmpty(val)); // Get the first non-null value
            }

            // If no value is found, throw an exception
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception($"The property {authorizationType} was not found in any profile.");
            }

            return value;
        }
        #endregion

        #region GetFromProfile 
        /// <param name="authorizationType">Represents a set of keys located in appsetting.</param>  
        /// <param name="profile">Here came key of profile of appsettings.</param>  
        private string GetFromProfile(string profile, OpenAIAuthorizationType authorizationType)
        {
            // Get the section corresponding to the profile
            var section = _configuration.GetSection(profile);

            // Get the name of the current class dynamically using reflection
            string className = this.GetType().Name;

            // Build the dynamic property name based on the class name and authorization type
            string propertyName = $"{className}{authorizationType}";

            // Search for the value corresponding to the dynamic property name
            return section[propertyName];
        }
        #endregion
    }

}
