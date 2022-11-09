using DomainClass.Common;

namespace Veterinary.DomainClass.Entity
{
    public class Client : BaseEntity
    {
        
        public string? clientName { get; set; }
        public string? clientSurname { get; set; }
        public string? clientAdress { get; set; }
        public string? clientPhoneNum { get; set; }
        public string? clientIdn { get; set; }
        public string? email { get; set; }

        #region
            public virtual ICollection<Pet> Pets { get; set; }
        
        #endregion
    }
}
