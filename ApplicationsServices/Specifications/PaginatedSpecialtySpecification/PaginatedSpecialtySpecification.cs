using ApplicationsServices.Filters.SpecialtyResponseFilter;
using Ardalis.Specification;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Specifications.PaginatedSpecialtySpecification
{
    internal class PaginatedSpecialtySpecification : Specification<Specialty>
    {
        public PaginatedSpecialtySpecification(SpecialtyResponseFilter filter)
        {

            Query.Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize);

            if (!string.IsNullOrEmpty(filter.specialty))
                Query.Search(x => x.specialty, "%" + filter.specialty + "%");



        }
    }
}
