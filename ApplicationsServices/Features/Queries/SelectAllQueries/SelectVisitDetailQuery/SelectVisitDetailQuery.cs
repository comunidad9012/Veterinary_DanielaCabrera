

using ApplicationsServices.Filters.VisitDetailResponseFilter;
using ApplicationsServices.Interfaces;
using ApplicationsServices.Specifications.PaginatedVisitDetailSpecification;
using ApplicationsServices.Wrappers;
using AutoMapper;
using MediatR;
using Veterinary.Core.DTOs;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Features.Queries.SelectAllQueries.SelectVisitDetailQuery
{
    public class SelectVisitDetailQuery : IRequest<PaginatedResponse<IEnumerable<VisitDetailFullDto>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public long visitId { get; set; }
        public long procedureId { get; set; }
        public string? price { get; set; }
        public bool IsDeleted { get; set; }

        public class SelectVisitDetailQueryHandler : IRequestHandler<SelectVisitDetailQuery, PaginatedResponse<IEnumerable<VisitDetailFullDto>>>
        {
            private readonly IRepository<VisitDetail> _repository;
            private readonly IMapper _mapper;

            public SelectVisitDetailQueryHandler(IRepository<VisitDetail> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }
            public async Task<PaginatedResponse<IEnumerable<VisitDetailFullDto>>> Handle(SelectVisitDetailQuery request, CancellationToken cancellationToken)
            {
                VisitDetailResponseFilter responseFilter = new VisitDetailResponseFilter()
                {
                    PageSize = request.PageSize,
                    PageNumber = request.PageNumber,
                    visitId = request.visitId,
                    procedureId = request.procedureId,
                    price = request.price,
                    IsDeleted=request.IsDeleted
                };

                var visitdetails = await _repository.ListAsync(new PaginatedVisitDetailSpecification(responseFilter));
                var visitDetailFullDtos = _mapper.Map<IEnumerable<VisitDetailFullDto>>(visitdetails);
                return new PaginatedResponse<IEnumerable<VisitDetailFullDto>>(visitDetailFullDtos, request.PageNumber, request.PageSize,request.IsDeleted);
            }
        }
    }
}
