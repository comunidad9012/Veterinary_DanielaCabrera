using DomainClass.Common;

namespace Veterinary.DomainClass.Entity
{
    public class Specialty : BaseEntity
    {
        //public int specialtyId { get; set; }
        public string? specialty { get; set; }
        public virtual Vet Vet { get; set; }
        
    }
}
