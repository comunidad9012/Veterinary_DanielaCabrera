using ApplicationsServices.Interfaces;
using ApplicationsServices.Wrappers;
using AutoMapper;
using MediatR;
using Veterinary.Core.DTOs;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Features.Queries.SelectAllQueries.SelectSpecialtyQuery
{
    public class SelectSpecialtyQuery : IRequest<PaginatedResponse<IEnumerable<SpecialtyFullDto>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? specialty { get; set; }

        public class SelectSpecialtyQueryHandler : IRequestHandler<SelectSpecialtyQuery, PaginatedResponse<IEnumerable<SpecialtyFullDto>>>
        {
            private readonly IRepository<Specialty> _repository;
            private readonly IMapper _mapper;

            public SelectSpecialtyQueryHandler(IRepository<Specialty> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }
            public async Task<PaginatedResponse<IEnumerable<SpecialtyFullDto>>> Handle(SelectSpecialtyQuery request, CancellationToken cancellationToken)
            {
                SpecialtyResponseFilter responseFilter = new SpecialtyResponseFilter()
                {
                    PageSize = request.PageSize,
                    PageNumber = request.PageNumber,
                    specialty = request.specialty,
                };

                var specialties = await _repository.ListAsync(new PaginatedSpecialtySpecification(responseFilter));
                var specialtyFullDtos = _mapper.Map<IEnumerable<SpecialtyFullDto>>(specialties);
                return new PaginatedResponse<IEnumerable<SpecialtyFullDto>>(specialtyFullDtos, request.PageNumber, request.PageSize);
            }
        }
    }
}
