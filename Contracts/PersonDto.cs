
namespace Contracts
{
    public class PersonDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual AddressDto Address { get; set; }
    }
}
