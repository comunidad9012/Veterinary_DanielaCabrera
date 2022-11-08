

using ApplicationsServices.Interfaces;
using ApplicationsServices.Wrappers;
using AutoMapper;
using MediatR;
using Veterinary.Core.DTOs;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Features.Queries.SelectAllQueries.SelectVisitQuery
{
    public class SelectVisitQuery : IRequest<PaginatedResponse<IEnumerable<VisitFullDto>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public long petId { get; set; }
        public long vetId { get; set; }
        public DateTime visitDate { get; set; }

        public class SelectVisitQueryHandler : IRequestHandler<SelectVisitQuery, PaginatedResponse<IEnumerable<VisitFullDto>>>
        {
            private readonly IRepository<Visit> _repository;
            private readonly IMapper _mapper;

            public SelectVisitQueryHandler(IRepository<Visit> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }
            public async Task<PaginatedResponse<IEnumerable<VisitFullDto>>> Handle(SelectVisitQuery request, CancellationToken cancellationToken)
            {
                VisitResponseFilter responseFilter = new VisitResponseFilter()
                {
                    PageSize = request.PageSize,
                    PageNumber = request.PageNumber,
                    petId = request.petId,
                    vetId = request.vetId,
                    visitDate = request.visitDate,
                };

                var visits = await _repository.ListAsync(new PaginatedVisitSpecification(responseFilter));
                var visitFullDtos = _mapper.Map<IEnumerable<VisitFullDto>>(visits);
                return new PaginatedResponse<IEnumerable<VisitFullDto>>(visitFullDtos, request.PageNumber, request.PageSize);
            }
        }
    }
}
