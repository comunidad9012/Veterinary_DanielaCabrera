
using ApplicationsServices.Interfaces;
using ApplicationsServices.Wrappers;
using AutoMapper;
using MediatR;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Features.Commands.UpdateCommands.UpdateSpecialtyCommand
{
    public class UpdateSpecialtyCommand : IRequest<Response<long>>
    {
        public long Id { get; set; }
        public string specialty { get; set; }

    }
    public class UpdateSpecialtyCommandHandler : IRequestHandler<UpdateSpecialtyCommand, Response<long>>
    {
        private readonly IRepository<Specialty> _repository;


        public UpdateSpecialtyCommandHandler(IRepository<Specialty> repository, IMapper mapper)
        {
            _repository = repository;

        }

        public async Task<Response<long>> Handle(UpdateSpecialtyCommand request, CancellationToken cancellationToken)
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
                register.specialty = request.specialty;


                await _repository.UpdateAsync(register);
            }


            return new Response<long>(register.Id);
        }
    }
}
