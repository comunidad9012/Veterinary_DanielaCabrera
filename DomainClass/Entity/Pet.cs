using DomainClass.Common;

namespace Veterinary.DomainClass.Entity
{
    public class Pet : BaseEntity
    {
        //public int petId { get; set; }
        public string? petName { get; set; }
        public long clientId { get; set; }
        public long typeId { get; set; }


        public virtual Client Client { get; set; }
    }
}
