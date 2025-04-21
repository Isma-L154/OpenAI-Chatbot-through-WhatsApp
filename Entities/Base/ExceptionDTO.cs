using EntitiesInterfaces.Base;
using Settings.Commons;

namespace Entities.Base
{
     
     
     
    /// 
    /// DTO for encapsulating exception details.
     
    public class ExceptionDTO: IExceptionDTO
    {
        public ExceptionDTO() 
        {
            this.InternalErrorMessage = new BaseAPISettingsCfg().Get(BaseAPISettingsType.InternalErrorMessage);
            this.CurrentDate = DateTime.Now;
            this.IsEnable = true;
            this.HostName = new BaseAPISettingsCfg().Get(BaseAPISettingsType.HostName);
        }

         
         
         
        /// The HTTP method or operation being performed when the exception occurred.
         
        public string Method { get; set; }

         
         
         
        /// The name of the class where the exception occurred.
         
        public string Class { get; set; }

         
         
         
        /// 
        /// Any additional data relevant to the exception.
         
        public object Data { get; set; }

         
         
         
        /// 
        /// The exception object containing the error details.
         
        public string Error { get; set; }
         
         
         
        /// 
        /// The exception object containing the InternalErrorMessage details.
         
        public string InternalErrorMessage { get; set; }
         
         
         
        /// 
        /// The exception object containing the CurrentDate details.
         
        public DateTime CurrentDate { get; set; }
         
         
         
        /// 
        /// The exception object containing the IsEnable details.
         
        public bool IsEnable { get; set; }
         
         
         
        /// 
        /// The exception object containing the HostName details.
         
        public string HostName { get ; set ; }
    }
}
