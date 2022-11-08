using ApplicationsServices.Interfaces;
using ApplicationsServices.Wrappers;
using AutoMapper;
using MediatR;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Features.Commands.UpdateCommands.UpdateVisitDetailCommand
{
    public class UpdateVisitDetailCommand : IRequest<Response<long>>
    {
        public long Id { get; set; }
        public long visitId { get; set; }
        public long procedureId { get; set; }
        public string? price { get; set; }

    }
    public class UpdateVisitDetailCommandHandler : IRequestHandler<UpdateVisitDetailCommand, Response<long>>
    {
        private readonly IRepository<VisitDetail> _repository;


        public UpdateVisitDetailCommandHandler(IRepository<VisitDetail> repository, IMapper mapper)
        {
            _repository = repository;

        }

        public async Task<Response<long>> Handle(UpdateVisitDetailCommand request, CancellationToken cancellationToken)
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
                register.visitId = request.visitId;
                register.procedureId = request.procedureId;
                register.price = request.price;


                await _repository.UpdateAsync(register);
            }


            return new Response<long>(register.Id);
        }
    }
}
