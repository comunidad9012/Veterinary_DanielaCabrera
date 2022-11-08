using ApplicationsServices.Interfaces;
using ApplicationsServices.Wrappers;
using AutoMapper;
using MediatR;
using Veterinary.Core.DTOs;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Features.Queries.SelectByQueries.SelectVetByIdQuery
{
    public class SelectVetByIdQuery : IRequest<Response<VetFullDto>>
    {
        public long Id { get; set; }
    }
    public class SelectVetByIdQueryHandler : IRequestHandler<SelectVetByIdQuery, Response<VetFullDto>>
    {
        private readonly IRepository<Vet> _repository;
        private readonly IMapper _mapper;

        public SelectVetByIdQueryHandler(IRepository<Vet> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        async Task<Response<VetFullDto>> IRequestHandler<SelectVetByIdQuery, Response<VetFullDto>>.Handle(SelectVetByIdQuery request, CancellationToken cancellationToken)
        {
            var vet = await _repository.GetByIdAsync(request.Id);
            if (vet == null)
            {
                throw new KeyNotFoundException($"El registro solicitado con Id {request.Id} no existe en la base de datos");
            }
            else
            {
                var dto = _mapper.Map<VetFullDto>(vet);
                return new Response<VetFullDto>(dto);

            }
        }
    }
}
