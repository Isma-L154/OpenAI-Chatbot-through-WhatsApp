using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesInterfaces.Security
{
    public interface IOpenAIAuthorizationDTO
    {
        string ApiKey { get; set; }
    }
}
