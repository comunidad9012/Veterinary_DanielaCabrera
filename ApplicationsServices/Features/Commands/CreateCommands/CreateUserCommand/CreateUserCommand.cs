﻿//Features (características): están los comandos para crear borrar, actualizar y traer datos por id o nombre.
//Los datos nuevos que queramos ingresar pueden ser creados gracías al comando CREATE.
using ApplicationsServices.Interfaces;
using ApplicationsServices.Wrappers;
using AutoMapper;
using MediatR;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Features.Commands.CreateCommands.CreateUserCommand
{
    public class CreateUserCommand : IRequest<Response<long>>
    {
        public string name { get; set; }
        public string userSurname { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string? userPhoneNum { get; set; }
        public long userRol { get; set; }
    }
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Response<long>>
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<long>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var newRegister = _mapper.Map<User>(request);
            var data = await _repository.AddAsync(newRegister);

            return new Response<long>(data.Id);
        }
    }
}
