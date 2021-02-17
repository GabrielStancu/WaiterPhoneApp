namespace WaiterPhoneApp.Models
{
    public class Role : BaseModel
    { 
        public string Name { get; private set; }

        public override bool Equals(BaseModel other)
        {
            if (other.GetType() != typeof(Role))
            {
                return false;
            }  

            if (Id > 0 && other.Id > 0)
            {
                return Id == other.Id;
            }

            Role otherRole = (Role)other;

            return Name.ToUpper().Equals(otherRole.Name.ToUpper());
        }
    }
}
