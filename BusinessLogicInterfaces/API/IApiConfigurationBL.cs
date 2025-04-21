namespace BusinessLogicInterfaces.API
{

    /// Interface that defines the structure and methods required for configuring and 
    /// executing API calls. This interface standardizes the properties and operations 
    /// needed to perform HTTP requests consistently.

    public interface IApiConfigurationBL
    {
        #region API Configuration Setting 
        
        /// Gets or sets the URL of the endpoint to be called.

        string Url { get; set; }

      
        /// Gets or sets the HTTP method to be used in the request.
        /// This can be GET, POST, PUT, DELETE, etc.
       
        HttpMethod Method { get; set; }

       
        /// Gets or sets the content of the request body (if applicable).
        /// This content can be an object that will be serialized to JSON.
       
        object Content { get; set; }

       
        /// Gets or sets the basic authentication string in Base64 format.
        /// If no authentication is required, this value can be null or empty.

        string BaseAuthentication { get; set; }
        #endregion

        #region Get

 
        /// Generates and configures an HttpRequestMessage object based on 
        /// the current property values, including URL, method, content, and 
        /// authentication. This method prepares the request for sending.
    
        /// <returns>An HttpRequestMessage object ready to send the HTTP request.</returns>
        HttpRequestMessage Get();
        #endregion

        #region Call

        /// Executes the API call using the configured values and 
        /// returns the response as a string. This method handles 
        /// the entire interaction with the API server.

        /// <returns>A string containing the server's response.</returns>
        string Call();
        #endregion
    }

}
