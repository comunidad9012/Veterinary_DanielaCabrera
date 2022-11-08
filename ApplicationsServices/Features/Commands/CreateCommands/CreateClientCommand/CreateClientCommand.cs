//Features (características): están los comandos para crear borrar, actualizar y traer datos por id o nombre.
//Los datos nuevos que queramos ingresar pueden ser creados gracías al comando CREATE.
using ApplicationsServices.Interfaces;
using ApplicationsServices.Wrappers;
using AutoMapper;
using MediatR;
using Veterinary.DomainClass.Entity;
namespace ApplicationsServices.Features.Commands.CreateCommands.CreateClientCommand
{

    public class CreateClientCommand : IRequest<Response<long>>//response es quien nos arma la respuesta a devolver
    {
        //aca solo tengo los campos para crear un registro nuevo
        //public long Id { get; set; }
        public string clientName { get; set; }//aca no tengo id porque cuando inserto un dato no hace falta(? *consultar
        public string clientSurname { get; set; }
        public string? clientAdress { get; set; }
        public string clientPhoneNum { get; set; }
        public string clientIdn { get; set; }
        public string email { get; set; }
        //public string Password { get; set; }
        //public long userRol { get; set; }
    }
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, Response<long>>//handler manejador

    {
        private readonly IRepository<Client> _repository;//inyectamos la independencia del repositorio de aplication services
        private readonly IMapper _mapper;

        public CreateClientCommandHandler(IRepository<Client> repository, IMapper mapper)//constructor hago la inyecion de dependencia
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<long>> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            //request.Password = request.Password.Encriptar();//si hago encriptacion aca dentro debo de copiar la misma linea
            //por eso lo debo de tener dentro de la entidad, cuando le mano un dato al campo password automaticamente hace la aunteticación
            //llama a encriptar y emcripta el dato
            var newRegister = _mapper.Map<Client>(request);//mapeo con automapper
            var data = await _repository.AddAsync(newRegister);//al agregar asincronamente va a recibir los datos y los guarda

            return new Response<long>(data.Id);//del registro que se inserto va a encapsular una respuesta en donde va a venir un id
        }
    }
}
