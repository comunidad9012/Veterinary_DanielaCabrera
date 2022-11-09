using ApplicationsServices.Filters.VisitDetailResponseFilter;
using Ardalis.Specification;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Specifications.PaginatedVisitDetailSpecification
{
    internal class PaginatedVisitDetailSpecification : Specification<VisitDetail>
    {
        public PaginatedVisitDetailSpecification(VisitDetailResponseFilter filter)
        {

            Query.Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize);

            if (!string.IsNullOrEmpty(filter.price))
                Query.Search(x => x.price, "%" + filter.price + "%");

        }
    }
}
