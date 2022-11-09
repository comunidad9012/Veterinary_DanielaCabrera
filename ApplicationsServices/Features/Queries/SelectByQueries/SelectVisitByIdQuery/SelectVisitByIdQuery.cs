using ApplicationsServices.Interfaces;
using ApplicationsServices.Wrappers;
using AutoMapper;
using MediatR;
using Veterinary.Core.DTOs;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Features.Queries.SelectByQueries.SelectVisitByIdQuery
{
    public class SelectVisitByIdQuery : IRequest<Response<VisitFullDto>>
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class SelectVisitByIdQueryHandler : IRequestHandler<SelectVisitByIdQuery, Response<VisitFullDto>>
    {
        private readonly IRepository<Visit> _repository;
        private readonly IMapper _mapper;

        public SelectVisitByIdQueryHandler(IRepository<Visit> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        async Task<Response<VisitFullDto>> IRequestHandler<SelectVisitByIdQuery, Response<VisitFullDto>>.Handle(SelectVisitByIdQuery request, CancellationToken cancellationToken)
        {
            var vet = await _repository.GetByIdAsync(request.Id);
            if (vet == null)
            {
                throw new KeyNotFoundException($"El registro solicitado con Id {request.Id} no existe en la base de datos");
            }
            else
            {
                var dto = _mapper.Map<VisitFullDto>(vet);
                return new Response<VisitFullDto>(dto);

            }
        }
    }
}
