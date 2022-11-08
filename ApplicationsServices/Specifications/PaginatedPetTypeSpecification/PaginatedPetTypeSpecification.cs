using ApplicationsServices.Filters.PetTypeResponseFilter;
using Ardalis.Specification;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Specifications.PaginatedPetTypeSpecification
{
    internal class PaginatedPetTypeSpecification : Specification<PetType>
    {
        public PaginatedPetTypeSpecification(PetTypeResponseFilter filter)
        {

            Query.Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize);

            if (!string.IsNullOrEmpty(filter.type))
                Query.Search(x => x.type, "%" + filter.type + "%");
        }
    }
}
