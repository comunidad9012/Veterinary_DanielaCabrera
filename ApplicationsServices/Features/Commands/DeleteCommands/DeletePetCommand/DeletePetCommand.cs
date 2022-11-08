//Features (características): están los comandos para crear borrar, actualizar y traer datos por id o nombre.
//Los datos que se crearon anteriormente, puedens er borrados gracías al comando DELETE.
using ApplicationsServices.Interfaces;
using ApplicationsServices.Wrappers;
using MediatR;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Features.Commands.DeleteCommands.DeletePetCommand
{
    public class DeletePetCommand : IRequest<Response<long>>
    {
        public long Id { get; set; }
    }
    public class DeletePetCommandHandle : IRequestHandler<DeletePetCommand, Response<long>>
    {
        private readonly IRepository<Pet> _repository;

        public DeletePetCommandHandle(IRepository<Pet> repository)
        {
            _repository = repository;
        }

        public async Task<Response<long>> Handle(DeletePetCommand request, CancellationToken cancellationToken)
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
                await _repository.DeleteAsync(register);
                return new Response<long>(register.Id);
            }



        }
    }
}
