using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using WaiterPhoneApp.Models;

namespace WaiterPhoneApp.Helpers.Mappers
{
    public class EntityMapper<T> where T: BaseModel
    { 
        public virtual Task<T> Map(SqlDataReader reader)
        {
            throw new NotImplementedException("Type not implemented by the mapper!");
        }
    }
}
