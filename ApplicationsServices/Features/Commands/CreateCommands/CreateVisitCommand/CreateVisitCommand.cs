using ApplicationsServices.Interfaces;
using ApplicationsServices.Wrappers;
using AutoMapper;
using MediatR;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Features.Commands.CreateCommands.CreateVisitCommand
{
    public class CreateVisitCommand : IRequest<Response<long>>
    {
        public long petId { get; set; }
        public long vetId { get; set; }
        public DateTime visitDate { get; set; }
    }
    public class CreateVisitCommandHandler : IRequestHandler<CreateVisitCommand, Response<long>>
    {
        private readonly IRepository<Visit> _repository;
        private readonly IMapper _mapper;

        public CreateVisitCommandHandler(IRepository<Visit> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<long>> Handle(CreateVisitCommand request, CancellationToken cancellationToken)
        {
            //request.Password = request.Password.Encriptar();
            var newRegister = _mapper.Map<Visit>(request);
            var data = await _repository.AddAsync(newRegister);

            return new Response<long>(data.Id);
        }
    }
}
