using ApplicationsServices.Filters.UserResponseFilter;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Specifications.PaginatedUserSpecification
{
    internal class PaginatedUserSpecification : Specification<User>
    {
        public PaginatedUserSpecification(UserResponseFilter filter)
        {

            Query.Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize);

            if (!string.IsNullOrEmpty(filter.name))
                Query.Search(x => x.name, "%" + filter.name + "%");

            if (!string.IsNullOrEmpty(filter.userSurname))
                Query.Search(x => x.userSurname, "%" + filter.userSurname + "%");

        }
    }
}
