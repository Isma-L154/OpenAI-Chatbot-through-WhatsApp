using EntitiesInterfaces.API;

namespace Entities.API
{
     
     
    
    /// Class manage entities handle Api response.
     
    public class ApiResponseDTO : IApiResponseDTO
    {
        public int StatusCode { get ; set ; }
        public string Status { get ; set ; }
        public string Message { get ; set ; }
        public string Timestamp { get ; set ; }
        public string Data { get ; set ; }
    }
}
