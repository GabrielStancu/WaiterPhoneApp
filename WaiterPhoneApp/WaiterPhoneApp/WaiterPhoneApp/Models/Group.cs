using System.ComponentModel.DataAnnotations.Schema;

namespace WaiterPhoneApp.Models
{
    public class Group : BaseModel
    {
        public string Name { get; private set; }
        public Department Department { get; private set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; private set; }

        public override bool Equals(BaseModel other)
        {
            if (other.GetType() != typeof(Group))
            {
                return false;
            }

            if (Id > 0 && other.Id > 0)
            {
                return Id == other.Id;
            }

            Group otherGroup = (Group)other;

            return Name.ToUpper().Equals(otherGroup.Name.ToUpper())
                && Department == otherGroup.Department;
        }
    }
}
