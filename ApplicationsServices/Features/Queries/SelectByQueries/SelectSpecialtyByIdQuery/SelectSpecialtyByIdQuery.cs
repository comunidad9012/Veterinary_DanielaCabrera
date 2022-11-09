using ApplicationsServices.Interfaces;
using ApplicationsServices.Wrappers;
using AutoMapper;
using MediatR;
using Veterinary.Core.DTOs;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Features.Queries.SelectByQueries.SelectSpecialtyByIdQuery
{
    public class SelectSpecialtyByIdQuery : IRequest<Response<SpecialtyFullDto>>
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class SelectSpecialtyByIdQueryHandler : IRequestHandler<SelectSpecialtyByIdQuery, Response<SpecialtyFullDto>>
    {
        private readonly IRepository<Specialty> _repository;
        private readonly IMapper _mapper;

        public SelectSpecialtyByIdQueryHandler(IRepository<Specialty> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        async Task<Response<SpecialtyFullDto>> IRequestHandler<SelectSpecialtyByIdQuery, Response<SpecialtyFullDto>>.Handle(SelectSpecialtyByIdQuery request, CancellationToken cancellationToken)
        {
            var specialty = await _repository.GetByIdAsync(request.Id);
            if (specialty == null)
            {
                throw new KeyNotFoundException($"El registro solicitado con Id {request.Id} no existe en la base de datos");
            }
            else
            {
                var dto = _mapper.Map<SpecialtyFullDto>(specialty);
                return new Response<SpecialtyFullDto>(dto);

            }
        }
    }
}
