using ApplicationsServices.Filters.PetResponseFilter;
using ApplicationsServices.Interfaces;
using ApplicationsServices.Specifications;
using ApplicationsServices.Specifications.PaginatedPetSpecification;
using ApplicationsServices.Wrappers;
using AutoMapper;
using MediatR;
using Veterinary.Core.DTOs;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Features.Queries.SelectAllQueries.SelectPetQuery
{
    public class SelectPetQuery : IRequest<PaginatedResponse<IEnumerable<PetFullDto>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? petName { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class SelectPetQueryHandler : IRequestHandler<SelectPetQuery, PaginatedResponse<IEnumerable<PetFullDto>>>
    {
        private readonly IRepository<Pet> _repository;
        private readonly IMapper _mapper;

        public SelectPetQueryHandler(IRepository<Pet> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<PaginatedResponse<IEnumerable<PetFullDto>>> Handle(SelectPetQuery request, CancellationToken cancellationToken)
        {
            PetResponseFilter responseFilter = new PetResponseFilter()
            {
                PageSize = request.PageSize,
                PageNumber = request.PageNumber,
                petName = request.petName,
            };

            var pets = await _repository.ListAsync(new PaginatedPetSpecification(responseFilter));
            var petFullDtos = _mapper.Map<IEnumerable<PetFullDto>>(pets);
            return new PaginatedResponse<IEnumerable<PetFullDto>>(petFullDtos, request.PageNumber, request.PageSize,request.IsDeleted);
        }
    }
}
