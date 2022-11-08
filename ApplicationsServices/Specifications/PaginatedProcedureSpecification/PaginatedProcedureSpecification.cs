using ApplicationsServices.Filters.ProcedureResponseFilter;
using Ardalis.Specification;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Specifications.PaginatedProcedureSpecification
{
    internal class PaginatedProcedureSpecification : Specification<Procedure>
    {
        public PaginatedProcedureSpecification(ProcedureResponseFilter filter)
        {

            Query.Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize);

            if (!string.IsNullOrEmpty(filter.procedure))
                Query.Search(x => x.procedure, "%" + filter.procedure + "%");

            

        }
    }
}
