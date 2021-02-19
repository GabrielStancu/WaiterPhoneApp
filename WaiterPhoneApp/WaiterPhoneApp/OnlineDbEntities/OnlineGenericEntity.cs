using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using WaiterPhoneApp.Helpers;
using WaiterPhoneApp.Models;

namespace WaiterPhoneApp.OnlineDbEntities
{
    public class OnlineGenericEntity<T> where T: BaseModel
    {
        protected SqlConnection EstablishSqlConnection()
        {
            return new OnlineSqlConnection().GetSqlConnection();
        }
        public async Task<List<BaseModel>> SelectAllEntities()
        {
            List<BaseModel> entities = new List<BaseModel>();

            using (var sqlConnection = EstablishSqlConnection())
            {
                string cmdText = $"SELECT * FROM {new GenericToStringMapper<T>().Map()}";
                SqlCommand cmd = new SqlCommand()
                {
                    CommandText = cmdText,
                    Connection = sqlConnection
                };

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {

                    }
                }
            }

            return entities;
        }
    }
}
