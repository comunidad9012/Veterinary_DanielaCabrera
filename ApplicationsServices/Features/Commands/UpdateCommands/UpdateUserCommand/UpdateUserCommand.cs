//Con el comando Update puedo actualizar los datos Ya existentes en mi base de datos
//En update si necesito hacer uso de ID, ya que con este detecto que dato quiero actualizar
//***notas extras***
//Inyección de dependencia: creamos interfaces y nosotros lo que vamos a hacer es comunicar a las capas a travez de ellas. 
//Esto rompe la dependencia de una capa con otra, si cambio el codigo el formato de la interfaz sigue siendo la misma y no deberia influir.
//Esto hace el codigo más limpio y fácil de mantener.
//Realizo inyección de dependencia con el repositorio:El repositorio es el que se va a encargar de manipular los datos contra la base de datos.
//Las task se ejecutan en paralelo a los demas procesos, si es async se ejecuta en paralelo sin detener otras tareas.

using ApplicationsServices.Interfaces;
using ApplicationsServices.Wrappers;
using AutoMapper;
using MediatR;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Features.Commands.UpdateCommands.UpdateUserCommand
{
    public class UpdateUserCommand : IRequest<Response<long>>
    {
        public long Id { get; set; }
        public string name { get; set; }
        public string userSurname { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string? userPhoneNum { get; set; }
        public long userRol { get; set; }
    }
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Response<long>>
    {
        private readonly IRepository<User> _repository;


        public UpdateUserCommandHandler(IRepository<User> repository, IMapper mapper)
        {
            _repository = repository;

        }

        public async Task<Response<long>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            //Obtiene el registro en base al Id enviado.
            var register = await _repository.GetByIdAsync(request.Id);
            //Consulta si se regreso algún registro desde la base de datos.
            if (register == null)
            {
                throw new KeyNotFoundException($"No se encontro el registro con el Id: {request.Id}");
            }
            else
            {
                register.userName = request.name;
                register.userSurname = request.userSurname;
                register.userName = request.userName;
                register.password = request.password;
                register.email = request.email;
                register.userPhoneNum = request.userPhoneNum;
                register.userRol = request.userRol;

                await _repository.UpdateAsync(register);
            }


            return new Response<long>(register.Id);
        }
    }
}
