using ApplicationsServices.Filters.PetTypeResponseFilter;
using ApplicationsServices.Interfaces;
using ApplicationsServices.Specifications;
using ApplicationsServices.Wrappers;
using AutoMapper;
using MediatR;
using Veterinary.Core.DTOs;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Features.Queries.SelectAllQueries.SelectPetTypeQuery
{
    public class SelectPetTypeQuery : IRequest<PaginatedResponse<IEnumerable<PetTypeFullDto>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? type { get; set; }
    }

    public class SelectPetTypeQueryHandler : IRequestHandler<SelectPetTypeQuery, PaginatedResponse<IEnumerable<PetTypeFullDto>>>
    {
        private readonly IRepository<PetType> _repository;
        private readonly IMapper _mapper;

        public SelectPetTypeQueryHandler(IRepository<PetType> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<PaginatedResponse<IEnumerable<PetTypeFullDto>>> Handle(SelectPetTypeQuery request, CancellationToken cancellationToken)
        {
            PetTypeResponseFilter responseFilter = new PetTypeResponseFilter()
            {
                PageSize = request.PageSize,
                PageNumber = request.PageNumber,
                type = request.type,
            };

            var type = await _repository.ListAsync(new PaginatedPetTypeSpecification(responseFilter));
            var petTypeFullDtos = _mapper.Map<IEnumerable<PetTypeFullDto>>(type);
            return new PaginatedResponse<IEnumerable<PetTypeFullDto>>(petTypeFullDtos, request.PageNumber, request.PageSize);
        }
    }
}
