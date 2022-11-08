//Validamos los datos ingresados. Aquí podemos ver los requisitos para el dato sea aceptado
//Los datos nuevos que queramos ingresar pueden ser creados gracías al comando CREATE.
//No llegamos a terminar esta entidad :(
using ApplicationsServices.Features.Commands.CreateCommands.CreateVetCommand;
using ApplicationsServices.Interfaces;
using ApplicationsServices.Wrappers;
using AutoMapper;
using MediatR;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Features.Commands.CreateCommands.CreateVetCommand
{
    public class CreateVetCommand : IRequest<Response<long>>//response es quien nos arma la respuesta a devolver
    {
       
        
        public string vetName { get; set; }//aca no tengo id porque cuando inserto un dato no hace falta(? *consultar
        public string vetSurname { get; set; }
        public string? vetAdress { get; set; }
        public string vetPhoneNum { get; set; }
        public string vetIdn { get; set; }
        public long specialtyId { get; set; }
    }

    public class CreateVetCommandHandler : IRequestHandler<CreateVetCommand, Response<long>>
    {//handler manejador
        private readonly IRepository<Vet> _repository;//inyectamos la independencia del repositorio de aplication services
        private readonly IMapper _mapper;

        public CreateVetCommandHandler(IRepository<Vet> repository, IMapper mapper)//constructor hago la inyecion de dependencia
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<long>> Handle(CreateVetCommand request, CancellationToken cancellationToken)
        {
            //request.Password = request.Password.Encriptar();//si hago encriptacion aca dentro debo de copiar la misma linea
            //por eso lo debo de tener dentro de la entidad, cuando le mano un dato al campo password automaticamente hace la aunteticación
            //llama a encriptar y emcripta el dato
            var newRegister = _mapper.Map<Vet>(request);
            var data = await _repository.AddAsync(newRegister);//al agregar asincronamente va a recibir los datos y los guarda

            return new Response<long>(data.Id);//del registro que se inserto va a encapsular una respuesta en donde va a venir un id
        }
    }
}
    


