using BusinessLogic.Commons;
using BusinessLogicInterfaces.Commons;
using EntitiesInterfaces.Base;
using Microsoft.AspNetCore.Mvc;

namespace ChatbotOpenIA.Controllers
{
    [ApiController]
    [Route("ChatBot/[controller]")]
    // Interface manage the OpenAI conecction API  
    public class CompletionsController : Controller
    {
        [HttpPost("Ask")]
        public  IResponseDTO Get([FromBody] string prompt)
        {
            ICompletionsBL completionsBL = new CompletionsBL();
            return  completionsBL.Post(prompt);
        }
    }
}
