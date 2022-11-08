

using ApplicationsServices.Interfaces;
using ApplicationsServices.Wrappers;
using AutoMapper;
using MediatR;
using Veterinary.Core.DTOs;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Features.Queries.SelectByQueries.SelectVisitDetailByIdQuery
{
    public class SelectVisitDetailByIdQuery : IRequest<Response<VisitDetailFullDto>>
    {
        public long Id { get; set; }
    }
    public class SelectVisitDetailByIdQueryHandler : IRequestHandler<SelectVisitDetailByIdQuery, Response<VisitDetailFullDto>>
    {
        private readonly IRepository<VisitDetail> _repository;
        private readonly IMapper _mapper;

        public SelectVisitDetailByIdQueryHandler(IRepository<VisitDetail> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        async Task<Response<VisitDetailFullDto>> IRequestHandler<SelectVisitDetailByIdQuery, Response<VisitDetailFullDto>>.Handle(SelectVisitDetailByIdQuery request, CancellationToken cancellationToken)
        {
            var visitDetail = await _repository.GetByIdAsync(request.Id);
            if (visitDetail == null)
            {
                throw new KeyNotFoundException($"El registro solicitado con Id {request.Id} no existe en la base de datos");
            }
            else
            {
                var dto = _mapper.Map<VisitDetailFullDto>(visitDetail);
                return new Response<VisitDetailFullDto>(dto);

            }
        }
    }
}
