using ApplicationsServices.Features.Commands.CreateCommands.CreateClientCommand;
using ApplicationsServices.Features.Commands.CreateCommands.CreatePetCommand;
using ApplicationsServices.Features.Commands.CreateCommands.CreatePetTypeCommand;
using ApplicationsServices.Features.Commands.CreateCommands.CreateProcedureCommand;
using ApplicationsServices.Features.Commands.CreateCommands.CreateSpecialtyCommand;
using ApplicationsServices.Features.Commands.CreateCommands.CreateUserCommand;
using ApplicationsServices.Features.Commands.CreateCommands.CreateUserRolCommand;
using ApplicationsServices.Features.Commands.CreateCommands.CreateVetCommand;
using ApplicationsServices.Features.Commands.CreateCommands.CreateVisitCommand;
using ApplicationsServices.Features.Commands.CreateCommands.CreateVisitDetailCommand;
using AutoMapper;
using Veterinary.Core.DTOs;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Mapping
{
    public class GeneralMaping : Profile
    {
        public GeneralMaping()
        {
            CreateMap<Client, ClientFullDto>();
            CreateMap<CreateClientCommand, Client>();

            CreateMap<User, UserFullDto>();
            CreateMap<CreateUserCommand, User>();

            CreateMap<Pet, PetFullDto>();
            CreateMap<CreatePetCommand, Pet>();

            CreateMap<PetType,PetTypeFullDto>();
            CreateMap<CreatePetTypeCommand, PetType>();
            
            CreateMap<Procedure, ProcedureFullDto>();
            CreateMap<CreateProcedureCommand, Procedure>();

            CreateMap<Specialty, SpecialtyFullDto>();
            CreateMap<CreateSpecialtyCommand, Specialty>();

            CreateMap<UserRol, UserRolFullDto>();
            CreateMap<CreateUserRolCommand, UserRol>();

            CreateMap<Vet, VetFullDto>();
            CreateMap<CreateVetCommand, Vet>();

            CreateMap<Visit, VisitFullDto>();
            CreateMap<CreateVisitCommand, Visit>();

            CreateMap<VisitDetail,VisitDetailFullDto>();
            CreateMap<CreateVisitDetailCommand, VisitDetail>();
        }
    }
}
