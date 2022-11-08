using ApplicationsServices.Filters.ClientResponseFilter;
using Ardalis.Specification;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Specifications.PaginatedClientSpecification
{
    internal class PaginatedClientSpecification : Specification<Client>
    {
        public PaginatedClientSpecification(ClientResponseFilter filter)
        {

            Query.Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize);

            if (!string.IsNullOrEmpty(filter.clientName))
                Query.Search(x => x.clientName, "%" + filter.clientName + "%");

            if (!string.IsNullOrEmpty(filter.clientSurname))
                Query.Search(x => x.clientSurname, "%" + filter.clientSurname + "%");

        }
    }
}
