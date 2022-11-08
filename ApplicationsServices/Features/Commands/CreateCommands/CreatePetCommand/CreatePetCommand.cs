//Features (características): están los comandos para crear borrar, actualizar y traer datos por id o nombre.
//Los datos nuevos que queramos ingresar pueden ser creados gracías al comando CREATE.
using ApplicationsServices.Interfaces;
using ApplicationsServices.Wrappers;
using AutoMapper;
using MediatR;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Features.Commands.CreateCommands.CreatePetCommand
{
    public class CreatePetCommand :IRequest<Response<long>>
    {
        public string? petName { get; set; }
        public long clientId { get; set; }
        public long typeId { get; set; }
    }
    public class CreatePetCommandHandler : IRequestHandler<CreatePetCommand, Response<long>>
    {
        private readonly IRepository<Pet> _repository;
        private readonly IMapper _mapper;

        public CreatePetCommandHandler(IRepository<Pet> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<long>> Handle(CreatePetCommand request, CancellationToken cancellationToken)
        {
            //request.Password = request.Password.Encriptar();
            var newRegister = _mapper.Map<Pet>(request);
            var data = await _repository.AddAsync(newRegister);

            return new Response<long>(data.Id);
        }
    }
}
