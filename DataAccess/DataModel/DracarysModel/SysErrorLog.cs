using System;
using System.Collections.Generic;

namespace DataAccess.DataModel.DracarysModel
{
    public partial class SysErrorLog
    {
        public int SysErrorLogId { get; set; }
        public string Host { get; set; } = null!;
        public string Class { get; set; } = null!;
        public string Method { get; set; } = null!;
        public string ErrorMessage { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public bool? IsEnable { get; set; }
    }
}
