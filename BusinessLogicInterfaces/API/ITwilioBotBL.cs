using Microsoft.AspNetCore.Mvc;

namespace BusinessLogicInterfaces.API
{  
    /// Interface manage the twilio conecction API  
     
    public interface ITwilioBotBL
    {
        #region Get
         
        /// Method handle of get message that I sent from Whatsapp.
         
        /// <param name="Body"> Here came the question from Whatsapp</param> 
        /// <param name="From"> Here came the number of Whatsapp from  whom sent message</param> 
        /// <returns>A string containing the OpenIA response.</returns>    
        IActionResult Get([FromForm] string Body, [FromForm] string From);
        #endregion
    }
}
