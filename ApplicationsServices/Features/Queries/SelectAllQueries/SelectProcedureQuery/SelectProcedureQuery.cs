using ApplicationsServices.Filters.ProcedureResponseFilter;
using ApplicationsServices.Interfaces;
using ApplicationsServices.Specifications.PaginatedProcedureSpecification;
using ApplicationsServices.Wrappers;
using AutoMapper;
using MediatR;
using Veterinary.Core.DTOs;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Features.Queries.SelectAllQueries.SelectProcedureQuery
{
    public class SelectProcedureQuery : IRequest<PaginatedResponse<IEnumerable<ProcedureFullDto>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? procedure { get; set; }
        public bool IsDeleted { get; set; }

        public class SelectProcedureQueryHandler : IRequestHandler<SelectProcedureQuery, PaginatedResponse<IEnumerable<ProcedureFullDto>>>
        {
            private readonly IRepository<Procedure> _repository;
            private readonly IMapper _mapper;

            public SelectProcedureQueryHandler(IRepository<Procedure> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }
            public async Task<PaginatedResponse<IEnumerable<ProcedureFullDto>>> Handle(SelectProcedureQuery request, CancellationToken cancellationToken)
            {
                ProcedureResponseFilter responseFilter = new ProcedureResponseFilter()
                {
                    PageSize = request.PageSize,
                    PageNumber = request.PageNumber,
                    procedure = request.procedure,
                };

                var procedures = await _repository.ListAsync(new PaginatedProcedureSpecification(responseFilter));
                var procedureFullDtos = _mapper.Map<IEnumerable<ProcedureFullDto>>(procedures);
                return new PaginatedResponse<IEnumerable<ProcedureFullDto>>(procedureFullDtos, request.PageNumber, request.PageSize, request.IsDeleted);
            }
        }
    }
}
