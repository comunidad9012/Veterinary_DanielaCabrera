using ApplicationsServices.Filters.VetResponseFilter;
using Ardalis.Specification;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Specifications.PaginatedVetSpecification
{
    internal class PaginatedVetSpecification : Specification<Vet>
    {
        public PaginatedVetSpecification(VetResponseFilter filter)
        {

            Query.Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize);

            if (!string.IsNullOrEmpty(filter.vetName))
                Query.Search(x => x.vetName, "%" + filter.vetName + "%");

            if (!string.IsNullOrEmpty(filter.vetSurname))
                Query.Search(x => x.vetSurname, "%" + filter.vetSurname + "%");

        }
    }
}
