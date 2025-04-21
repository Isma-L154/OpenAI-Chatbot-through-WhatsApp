using EntitiesInterfaces.Base;
using EntitiesInterfaces.Commons.Enums;

namespace Entities.Base
{

    /// Defines a standard structure for API response objects.
     
    public class ResponseDTO : IResponseDTO
    {
        #region Constructor 
         
        /// Constructor to initialize the container with any type of data.
                  
        public ResponseDTO() 
        {
            this.Result = ActionResult.Success; 
        }
        #endregion

         
        /// Indicates the result of the operation (Success, Warning, Error).
         
        public ActionResult Result { get ; set ; }
         
        /// A list of error messages associated with the operation.
         
        public List<string> ErrorMessage { get ; set ; }
         
        /// Holds the response value from the API. It can be any type of data.
         
        public object Value { get ; set ; }

    }
}
