using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using WaiterPhoneApp.Models;

namespace WaiterPhoneApp.Mappers
{
    public class EntityMapper<T> where T : BaseModel
    {
        public Task<T> Map(SqlDataReader reader)
        {
            throw new NotImplementedException("Type not supported for the mapping hierarchy!");
        }
    }
}
