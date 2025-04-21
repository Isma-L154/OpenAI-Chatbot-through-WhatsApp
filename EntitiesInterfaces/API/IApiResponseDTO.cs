namespace EntitiesInterfaces.API
{

    /// Interface manage entities handle Api response.
  
    public interface IApiResponseDTO
    {
        int StatusCode { get; set; }
        string Status { get; set; }
        string Message { get; set; }
        string Timestamp { get; set; }
        string Data { get; set; } 
    }
}
