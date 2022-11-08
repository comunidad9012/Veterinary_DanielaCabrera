using ApplicationsServices.Filters.VisitResponseFilter;
using Ardalis.Specification;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Specifications.PaginatedVisitSpecification
{
    internal class PaginatedVisitSpecification : Specification<Visit>
    {
        public PaginatedVisitSpecification(VisitResponseFilter filter)
        {

            Query.Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize);

            //if (!DateTime.IsNullOrEmpty(filter.visitDate))
            //Query.Search(x => x.visitDate, "%" + filter.visitDate + "%");

            

        }
    }
}
