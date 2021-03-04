using System.ComponentModel.DataAnnotations.Schema;

namespace WaiterPhoneApp.Models
{
    public class RestaurantUser : BaseModel
    {
        public string Nickname { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Department Department { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Role Role { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get; set; }

        public override bool Equals(BaseModel other)
        {
            if (other.GetType() != typeof(RestaurantUser))
            {
                return false;
            }

            if (Id > 0 && other.Id > 0)
            {
                return Id == other.Id;
            }

            RestaurantUser otherUser = (RestaurantUser)other;

            return Username.ToUpper().Equals(otherUser.Username.ToUpper())
                && FirstName.ToUpper().Equals(otherUser.FirstName.ToUpper())
                && LastName.ToUpper().Equals(otherUser.LastName.ToUpper())
                && Department == otherUser.Department
                && Role == otherUser.Role;
        }
    }
}
