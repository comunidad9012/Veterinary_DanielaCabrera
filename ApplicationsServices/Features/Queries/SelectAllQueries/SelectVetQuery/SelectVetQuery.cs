using ApplicationsServices.Filters.VetResponseFilter;
using ApplicationsServices.Interfaces;
using ApplicationsServices.Specifications;
using ApplicationsServices.Specifications.PaginatedVetSpecification;
using ApplicationsServices.Wrappers;
using AutoMapper;
using MediatR;
using Veterinary.Core.DTOs;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Features.Queries.SelectAllQueries.SelectVetQuery
{
    public class SelectVetQuery : IRequest<PaginatedResponse<IEnumerable<VetFullDto>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? vetName { get; set; }
        public string? vetSurname { get; set; }
        public bool IsDeleted { get; set; }

        public class SelectVetQueryHandler : IRequestHandler<SelectVetQuery, PaginatedResponse<IEnumerable<VetFullDto>>>
        {
            private readonly IRepository<Vet> _repository;
            private readonly IMapper _mapper;

            public SelectVetQueryHandler(IRepository<Vet> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }
            public async Task<PaginatedResponse<IEnumerable<VetFullDto>>> Handle(SelectVetQuery request, CancellationToken cancellationToken)
            {
                VetResponseFilter responseFilter = new VetResponseFilter()
                {
                    PageSize = request.PageSize,
                    PageNumber = request.PageNumber,
                    vetName = request.vetName,
                    vetSurname = request.vetSurname,
                    IsDeleted = request.IsDeleted
                };

                var vets = await _repository.ListAsync(new PaginatedVetSpecification(responseFilter));
                var vetFullDtos = _mapper.Map<IEnumerable<VetFullDto>>(vets);
                return new PaginatedResponse<IEnumerable<VetFullDto>>(vetFullDtos, request.PageNumber, request.PageSize,request.IsDeleted);
            }
        }
    }
}
