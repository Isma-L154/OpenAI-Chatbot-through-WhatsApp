using EntitiesInterfaces.Base;

namespace Entities.Base
{
     
     
     
    /// Class is a versatile container class to store various types of data,
    /// including strings, JSON strings, integers, or other entities, this object is a Request class to manage in this base structure
     
    public class RequestDTO : IRequestDTO
    {
        #region Constructor 
         
         
         
        /// Constructor to initialize the container with any type of data.
         
        /// <param name="value">The data to store, which can be of any type.</param>     
        public RequestDTO(object value)
        {
            Value = value;
        }
        public RequestDTO()
        {
            
        }
        #endregion

         
         
         
        /// Stores data as a generic object, allowing any data type.
         
        public object Value { get; set; }        
        
    }
}
