using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using WaiterPhoneApp.Database.OnlineDatabase.DbOnline;
using WaiterPhoneApp.Helpers.Mappers;
using WaiterPhoneApp.Models;

namespace WaiterPhoneApp.Database.OnlineDatabase.OnlineDbEntities
{
    public class OnlineGenericEntity<T> where T: BaseModel
    {
        protected SqlConnection EstablishSqlConnection()
        {
            var conn = new OnlineSqlConnection().GetSqlConnection();

            try
            {
                conn.Open();
                return conn;
            }
            catch(SqlException)
            {
                return null;
            }
        }
        public async Task<List<T>> SelectAllEntitiesAsync()
        {
            List<T> entities = new List<T>();

            using (var sqlConnection = EstablishSqlConnection())
            {
                string cmdText = $"SELECT * FROM {typeof(T).Name}";
                SqlCommand cmd = new SqlCommand()
                {
                    CommandText = cmdText,
                    Connection = sqlConnection
                };

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        EntityMapper<T> mapper = new EntityMapper<T>();
                        T mappedEntity = await mapper.Map(reader);
                        entities.Add(mappedEntity);
                    }
                }
            }

            return entities;
        }

        public async Task<T> SelectByIdAsync(int id)
        {
            using (var sqlConnection = EstablishSqlConnection())
            {
                string cmdText = $"SELECT * FROM {typeof(T).Name} WHERE Id = {id}";
                SqlCommand cmd = new SqlCommand()
                {
                    CommandText = cmdText,
                    Connection = sqlConnection
                };

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (reader.Read())
                    {
                        EntityMapper<T> mapper = new EntityMapper<T>();
                        T mappedEntity = await mapper.Map(reader);

                        return mappedEntity;
                    }

                    return null;
                }
            }
        }

        public async Task DeleteById(int id)
        {
            using (var sqlConnection = EstablishSqlConnection())
            {
                string cmdText = $"DELETE FROM {typeof(T).Name} WHERE Id = {id}";
                SqlCommand cmd = new SqlCommand()
                {
                    CommandText = cmdText,
                    Connection = sqlConnection
                };

                await cmd.ExecuteNonQueryAsync();
            }
        }

        //UPDATE and INSERT queries are dependent on field structure, not all classes should implement it
        //Create OnlineEntity mirroring for those classes that need it
    }
}
