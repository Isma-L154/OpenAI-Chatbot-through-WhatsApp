using EntitiesInterfaces.Commons.Enums;

namespace EntitiesInterfaces.Base
{
    /// Defines a standard structure for API response objects.
     
    public interface IResponseDTO: IBaseSettingDTO
    {
         
        /// Indicates the result of the operation (Success, Warning, Error).
         
        ActionResult Result { get; set; }
         
        /// A list of error messages associated with the operation.
         
        List<string> ErrorMessage { get; set; }
    }
}
