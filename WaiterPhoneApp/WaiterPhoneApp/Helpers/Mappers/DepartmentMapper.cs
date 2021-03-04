using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using WaiterPhoneApp.Models;

namespace WaiterPhoneApp.Helpers.Mappers
{
    public class DepartmentMapper : EntityMapper<Department>
    {
        public override async Task<Department> Map(SqlDataReader reader)
        {
            await Task.Run(() =>
            {
                Department department = new Department();

                department.Id = Int32.Parse(reader["Id"].ToString());
                department.Name = reader["Name"].ToString();

                return department;
            });

            return null;
        }
    }
}
