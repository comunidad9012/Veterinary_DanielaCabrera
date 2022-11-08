using ApplicationsServices.Interfaces;
using ApplicationsServices.Wrappers;
using AutoMapper;
using MediatR;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Features.Commands.UpdateCommands.UpdateProcedureCommand
{
    public class UpdateProcedureCommand : IRequest<Response<long>>
    {
        public long Id { get; set; }
        public string procedure { get; set; }
        
    }
    public class UpdateProcedureCommandHandler : IRequestHandler<UpdateProcedureCommand, Response<long>>
    {
        private readonly IRepository<Procedure> _repository;


        public UpdateProcedureCommandHandler(IRepository<Procedure> repository, IMapper mapper)
        {
            _repository = repository;

        }

        public async Task<Response<long>> Handle(UpdateProcedureCommand request, CancellationToken cancellationToken)
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
                register.procedure = request.procedure;
                

                await _repository.UpdateAsync(register);
            }


            return new Response<long>(register.Id);
        }
    }
}
