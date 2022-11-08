using ApplicationsServices.Interfaces;
using ApplicationsServices.Wrappers;
using AutoMapper;
using MediatR;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Features.Commands.CreateCommands.CreateProcedureCommand
{
   public class CreateProcedureCommand : IRequest<Response<long>>//response es quien nos arma la respuesta a devolver
   {
        public string? procedure { get; set; }
   }
   public class CreateProcedureCommandHandler : IRequestHandler<CreateProcedureCommand, Response<long>>
   {//handler manejador
        private readonly IRepository<Procedure> _repository;//inyectamos la independencia del repositorio de aplication services
        private readonly IMapper _mapper;
        public CreateProcedureCommandHandler(IRepository<Procedure> repository, IMapper mapper)//constructor hago la inyecion de dependencia
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<long>> Handle(CreateProcedureCommand request, CancellationToken cancellationToken)
        {
         //request.Password = request.Password.Encriptar();//si hago encriptacion aca dentro debo de copiar la misma linea
         //por eso lo debo de tener dentro de la entidad, cuando le mano un dato al campo password automaticamente hace la aunteticación
         //llama a encriptar y emcripta el dato
            var newRegister = _mapper.Map<Procedure>(request);
            var data = await _repository.AddAsync(newRegister);//al agregar asincronamente va a recibir los datos y los guarda

            return new Response<long>(data.Id);//del registro que se inserto va a encapsular una respuesta en donde va a venir un id
        }
   }
    
}
