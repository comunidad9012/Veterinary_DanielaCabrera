using ApplicationsServices.Interfaces;
using ApplicationsServices.Wrappers;
using AutoMapper;
using MediatR;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Features.Commands.UpdateCommands.UpdateVisitCommand
{
    public class UpdateVisitCommand : IRequest<Response<long>>
    {
        public long Id { get; set; }
        public long petId { get; set; }
        public long vetId { get; set; }
        public DateTime visitDate { get; set; }

    }
    public class UpdateVisitCommandHandler : IRequestHandler<UpdateVisitCommand, Response<long>>
    {
        private readonly IRepository<Visit> _repository;


        public UpdateVisitCommandHandler(IRepository<Visit> repository, IMapper mapper)
        {
            _repository = repository;

        }

        public async Task<Response<long>> Handle(UpdateVisitCommand request, CancellationToken cancellationToken)
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
                register.petId = request.petId;
                register.vetId = request.vetId;
                register.visitDate = request.visitDate;


                await _repository.UpdateAsync(register);
            }


            return new Response<long>(register.Id);
        }
    }
}
