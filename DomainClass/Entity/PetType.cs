using DomainClass.Common;

namespace Veterinary.DomainClass.Entity
{
    public class PetType : BaseEntity
    {
        
        public string? type { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }
    }
}
