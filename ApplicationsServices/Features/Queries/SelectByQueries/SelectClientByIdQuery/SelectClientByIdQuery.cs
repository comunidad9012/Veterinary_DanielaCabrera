using ApplicationsServices.Interfaces;
using ApplicationsServices.Wrappers;
using AutoMapper;
using MediatR;
using Veterinary.Core.DTOs;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Features.Queries.SelectByQueries.SelectClientByIdQuery
{
    public class SelectClientByIdQuery : IRequest<Response<ClientFullDto>>
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class SelectClientByIdQueryHandler : IRequestHandler<SelectClientByIdQuery, Response<ClientFullDto>>
    {
        private readonly IRepository<Client> _repository;
        private readonly IMapper _mapper;

        public SelectClientByIdQueryHandler(IRepository<Client> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        async Task<Response<ClientFullDto>> IRequestHandler<SelectClientByIdQuery, Response<ClientFullDto>>.Handle(SelectClientByIdQuery request, CancellationToken cancellationToken)
        {
            var client = await _repository.GetByIdAsync(request.Id);
            if (client == null)
            {
                throw new KeyNotFoundException($"El registro solicitado con Id {request.Id} no existe en la base de datos");
            }
            else
            {
                var dto = _mapper.Map<ClientFullDto>(client);
                return new Response<ClientFullDto>(dto);

            }
        }
    }
}
