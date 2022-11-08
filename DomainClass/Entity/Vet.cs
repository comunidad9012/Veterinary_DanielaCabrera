using DomainClass.Common;

namespace Veterinary.DomainClass.Entity
{
    public class Vet : BaseEntity
    {
        
        public string? vetName { get; set; }
        public string? vetSurname { get; set; }
        public string? vetAdress { get; set; }
        public string? vetPhoneNum { get; set; }
        public string? vetIdn { get; set; }
        public long specialtyId { get; set; }

       
    }
}
