//Features (características): están los comandos para crear borrar, actualizar y traer datos por id o nombre.
//Los datos nuevos que queramos ingresar pueden ser creados gracías al comando CREATE.
using ApplicationsServices.Interfaces;
using ApplicationsServices.Wrappers;
using AutoMapper;
using MediatR;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Features.Commands.CreateCommands.CreateUserRolCommand
{
    public class CreateUserRolCommand : IRequest<Response<long>>
    {
        public string rol { get; set; }
       
    }
    public class CreateUserRolCommandHandler : IRequestHandler<CreateUserRolCommand, Response<long>>
    {
        private readonly IRepository<UserRol> _repository;
        private readonly IMapper _mapper;

        public CreateUserRolCommandHandler(IRepository<UserRol> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<long>> Handle(CreateUserRolCommand request, CancellationToken cancellationToken)
        {
            var newRegister = _mapper.Map<UserRol>(request);
            var data = await _repository.AddAsync(newRegister);

            return new Response<long>(data.Id);
        }
    }
}
