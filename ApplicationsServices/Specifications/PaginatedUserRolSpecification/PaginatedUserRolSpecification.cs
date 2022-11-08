using ApplicationsServices.Filters.UserRolResponseFilter;
using Ardalis.Specification;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Specifications.PaginatedUserRolSpecification
{
    internal class PaginatedUserRolSpecification : Specification<UserRol>
    {
        public PaginatedUserRolSpecification(UserRolResponseFilter filter)
        {

            Query.Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize);

            if (!string.IsNullOrEmpty(filter.rol))
                Query.Search(x => x.rol, "%" + filter.rol + "%");


        }
    }
}
