﻿using System.ComponentModel.DataAnnotations.Schema;

namespace WaiterPhoneApp.Models
{
    public class User : BaseModel
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public Department Department { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Role Role { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get; set; }

        public override bool Equals(BaseModel other)
        {
            if (other.GetType() != typeof(User))
            {
                return false;
            }

            if (Id > 0 && other.Id > 0)
            {
                return Id == other.Id;
            }

            User otherUser = (User)other;

            return Username.ToUpper().Equals(otherUser.Username.ToUpper())
                && FirstName.ToUpper().Equals(otherUser.FirstName.ToUpper())
                && LastName.ToUpper().Equals(otherUser.LastName.ToUpper())
                && Department == otherUser.Department
                && Role == otherUser.Role;
        }
    }
}
