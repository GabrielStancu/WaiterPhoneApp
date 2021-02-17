using System.ComponentModel.DataAnnotations.Schema;

namespace WaiterPhoneApp.Models
{
    public class Subgroup : BaseModel
    {
        public string Name { get; private set; }
        public Group Group { get; private set; }
        [ForeignKey("Group")]
        public int GroupId { get; private set; }
        public Department Department { get; private set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; private set; }

        public override bool Equals(BaseModel other)
        {
            if (other.GetType() != typeof(Subgroup))
            {
                return false;
            }

            if (Id > 0 && other.Id > 0)
            {
                return Id == other.Id;
            }

            Subgroup otherSubgroup = (Subgroup)other;

            return Name.ToUpper().Equals(otherSubgroup.Name.ToUpper())
                && Group == otherSubgroup.Group
                && Department == otherSubgroup.Department;
        }
    }
}
