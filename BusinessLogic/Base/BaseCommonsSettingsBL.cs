using DataAccess.Commons;
using DataAccessInterface.Commons;
using Entities.Base;
using EntitiesInterfaces.Base;
using EntitiesInterfaces.Commons.Enums;

namespace BusinessLogic.Base
{
    /// This class serves as a base for reusable methods that can be shared across multiple classes.

    public class BaseCommonsSettingsBL
    {

        /// Handles exceptions by formatting their details for further processing or display.

        /// <param name="exceptionDTO">The DTO containing exception details.</param>
        /// <returns>An IResponseDTO with formatted error information.</returns>
        protected IResponseDTO ManageException(ExceptionDTO exceptionDTO)
        {
            IResponseDTO response = new ResponseDTO();
            response.ErrorMessage = new List<string>();
            try
            {
                //To do: Here we have to added logic to save this error in data base
                ISysErrorLogDA sysErrorLogDA = new SysErrorLogDA();
                sysErrorLogDA.Save(exceptionDTO);
                // Format the error details into the response object
                response.Result = ActionResult.Error;                
                response.ErrorMessage.Add(exceptionDTO.Error);
            }
            catch (Exception ex)
            {
                //To do: Here we have to add  logic to send a error email indicating the exception            
            }

            return response;
        }
    }
}
