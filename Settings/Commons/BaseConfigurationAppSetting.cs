using Microsoft.Extensions.Configuration;

namespace Settings.Commons
{
     
     
    
    /// 
    /// This class manages the base configuration to manage appsetting file that some special classes share with each other.
     
    public class BaseConfigurationAppSetting
    {
        #region GetConfiguration
         
         
        
        /// Method to initialize the configuration object for the class by loading settings from the appsettings.json file.
         
        /// <returns>IConfiguration object containing the application settings.</returns>
        protected IConfiguration GetConfiguration()
        {
            // Define the path to the appsettings.json
            string basePath = Directory.GetCurrentDirectory(); // Gets the output directory
            return new ConfigurationBuilder()
                .SetBasePath(basePath) // Set the base path
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) // Load the file
                .Build();
        }
        #endregion
    }
}
