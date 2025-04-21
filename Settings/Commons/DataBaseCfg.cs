using Microsoft.Extensions.Configuration;

namespace Settings.Commons
{

    #region Enums 
             
     
     
    /// Enum for dataBaseType. Here, you add the name of all the properties 
    /// that will be in the appsettings for this entity, using them as keys. 
     
    public enum DataBaseType
    {
        DefaultConnection        
    }
    #endregion

     
     
    
    /// 
    /// This class manages the retrieval of configuration values from the application's settings 
    /// based on dynamic keys and profiles.
     
    public class DataBaseCfg : BaseSettings
    {
        #region Global Data 
                 
         
         
        /// Here you can find instances or global variables.
             
        private readonly IConfiguration _configuration;
        #endregion

        #region Constructor 
                 
         
         
        /// Constructor for initializing the class with the configuration object.
         
        /// <param name="configuration">Represents a set of key/value application configuration properties.</param> 
        public DataBaseCfg()
        {
            _configuration = this.GetConfiguration();
        }
        #endregion

        #region Get 
                 
         
         
        /// Method to get the configuration value  in appsetting file using dataBaseType enum as a key.  
         
        /// <param name="dataBaseType">Represents a set of keys located in appsetting.</param> 
        public string Get(DataBaseType dataBaseType)
        {
            // Get the active profile from the configuration
            string profile = _configuration["Profile"];

            // Search for the configuration in the active profile and all defined profiles
            string value = GetFromProfile(profile, dataBaseType);

            // If the value is not found in the active profile, search in all profiles (without explicit ifs)
            if (string.IsNullOrEmpty(value))
            {
                value = _configuration.GetChildren()
                    .Where(section => section.Key != "Profile") // Exclude "Profile" from the list
                    .Select(section => GetFromProfile(section.Key, dataBaseType))
                    .FirstOrDefault(val => !string.IsNullOrEmpty(val)); // Get the first non-null value
            }

            // If no value is found, throw an exception
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception($"The property {dataBaseType} was not found in any profile.");
            }

            return value;
        }
        #endregion

        #region GetFromProfile 
                 
         
         
        /// Method to get the configuration value in the appsetting file using dataBaseType enum as a key.
         
        /// <param name="dataBaseType">Represents a set of keys located in appsetting.</param>  
        /// <param name="profile">Here came key of profile of appsettings.</param>  
        private string GetFromProfile(string profile, DataBaseType dataBaseType)
        {
            // Get the section corresponding to the profile
            var section = _configuration.GetSection(profile);

            // Get the name of the current class dynamically using reflection
            string className = this.GetType().Name;

            // Build the dynamic property name based on the class name and authorization type
            string propertyName = $"{className}{dataBaseType}";

            // Search for the value corresponding to the dynamic property name
            return section[propertyName];
        }
        #endregion
    }
}
