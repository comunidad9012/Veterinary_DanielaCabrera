using ApplicationsServices.Interfaces;
using ApplicationsServices.Wrappers;
using MediatR;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Features.Commands.DeleteCommands.DeleteVisitDetailCommand
{
    public class DeleteVisitDetailCommand : IRequest<Response<long>>
    {
        public long Id { get; set; }
    }
    public class DeleteVisitDetailCommandHandle : IRequestHandler<DeleteVisitDetailCommand, Response<long>>
    {
        private readonly IRepository<VisitDetail> _repository;

        public DeleteVisitDetailCommandHandle(IRepository<VisitDetail> repository)
        {
            _repository = repository;
        }

        public async Task<Response<long>> Handle(DeleteVisitDetailCommand request, CancellationToken cancellationToken)
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
