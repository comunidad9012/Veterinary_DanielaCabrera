using ApplicationsServices.Filters.PetResponseFilter;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Specifications.PaginatedPetSpecification
{
    internal class PaginatedPetSpecification : Specification<Pet>
    {
        public PaginatedPetSpecification(PetResponseFilter filter)
        {

            Query.Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize);

            if (!string.IsNullOrEmpty(filter.petName))
                Query.Search(x => x.petName, "%" + filter.petName + "%");
        }
    }
}
