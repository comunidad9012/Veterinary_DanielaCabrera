using ApplicationsServices.Interfaces;
using ApplicationsServices.Wrappers;
using AutoMapper;
using MediatR;
using Veterinary.Core.DTOs;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Features.Queries.SelectByQueries.SelectProcedureByIdQuery
{
    public class SelectProcedureByIdQuery : IRequest<Response<ProcedureFullDto>>
    {
        public long Id { get; set; }
    }
    public class SelectProcedureByIdQueryHandler : IRequestHandler<SelectProcedureByIdQuery, Response<ProcedureFullDto>>
    {
        private readonly IRepository<Procedure> _repository;
        private readonly IMapper _mapper;

        public SelectProcedureByIdQueryHandler(IRepository<Procedure> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        async Task<Response<ProcedureFullDto>> IRequestHandler<SelectProcedureByIdQuery, Response<ProcedureFullDto>>.Handle(SelectProcedureByIdQuery request, CancellationToken cancellationToken)
        {
            var procedure = await _repository.GetByIdAsync(request.Id);
            if (procedure == null)
            {
                throw new KeyNotFoundException($"El registro solicitado con Id {request.Id} no existe en la base de datos");
            }
            else
            {
                var dto = _mapper.Map<ProcedureFullDto>(procedure);
                return new Response<ProcedureFullDto>(dto);

            }
        }
    }
}
