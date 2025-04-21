using EntitiesInterfaces.Commons;
using Settings.Commons;

namespace Entities.Commons
{

     
     
    
    /// This class manages way to get the default data base connection properties.
     
    public class DataBaseDTO : IDataBaseDTO
    {
        public DataBaseDTO()
        {
            this.DefaultConnection = new DataBaseCfg().Get(DataBaseType.DefaultConnection);            
        }        
        public string DefaultConnection { get; set; }
    }
}
