﻿namespace WaiterPhoneApp.Models
{
    public class Department : BaseModel
    {
        public string Name { get; set; }

        public override bool Equals(BaseModel other)
        {
            if (other.GetType() != typeof(Department))
            {
                return false;
            }

            if (Id > 0 && other.Id > 0)
            {
                return Id == other.Id;
            }

            Department otherDepartment = (Department)other;

            return Name.ToUpper().Equals(otherDepartment.Name.ToUpper());
        }
    }
}
