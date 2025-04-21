using BusinessLogic.API;
using BusinessLogicInterfaces.API;
using Microsoft.AspNetCore.Mvc;

namespace ChatbotOpenIA.Controllers
{

    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
     
    /// Interface manage the twilio conecction API  
     
    public class TwilioBotController : Controller
    {
        #region Get        
        /// Method handle of get message that I sent from Whatsapp.
         
        /// <param name="Body"> Here came the question from Whatsapp</param> 
        /// <param name="From"> Here came the number of Whatsapp from  whom sent message</param> 
        /// <returns>A string containing the OpenIA response.</returns>        
        [HttpPost]
        public IActionResult Get([FromForm] string Body, [FromForm] string From)
        {
            ITwilioBotBL twilioBotBL = new TwilioBotBL();
            return twilioBotBL.Get(Body, From);            
        }
        #endregion
    }
}
