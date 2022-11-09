using DomainClass.Common;

namespace Veterinary.DomainClass.Entity
{
    public class Procedure : BaseEntity
    {
        //public int procedureId { get; set; }
        public string? procedure { get; set; }
        public virtual ICollection<VisitDetail> VisitDetails { get; set; }
    }
}
