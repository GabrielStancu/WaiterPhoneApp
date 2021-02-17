using System.ComponentModel.DataAnnotations.Schema;

namespace WaiterPhoneApp.Models
{
    public class Product : BaseModel
    {
        public string Name { get; private set; }
        public Group Group { get; private set; }
        [ForeignKey("Group")]
        public int GroupId { get; private set; }
        public Subgroup Subgroup { get; private set; }
        [ForeignKey("Subgroup")]
        public int SubgroupId { get; private set; }
        public double Price { get; private set; }
        public Department Department { get; private set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; private set; }

        public override bool Equals(BaseModel other)
        {
            if (other.GetType() != typeof(Product))
            {
                return false;
            }

            Product otherProduct = (Product)other;

            if (Id > 0 && other.Id > 0)
            {
                return Id == other.Id;
            }

            return Name.ToUpper().Equals(otherProduct.Name.ToUpper())
                && Group == otherProduct.Group
                && Subgroup == otherProduct.Subgroup
                && Department == otherProduct.Department
                && Price == otherProduct.Price;
        }
    }
}
