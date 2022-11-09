//El controlador es el que se encarga de devolver a la vista la informacio que traigamos de la base de datos o viceversa. 
//La  informacion fluye: de la vista al cotrolador, del controlador a los repositorios y del repositorio a la base de datos y viceversa.
//Vamos a tener tantos controladores como datos que se van a querer modificar en la base de datos.
using ApplicationsServices.Features.Commands.CreateCommands.CreatePetCommand;
using ApplicationsServices.Features.Commands.DeleteCommands.DeletePetCommand;
using ApplicationsServices.Features.Commands.UpdateCommands.UpdatePetCommand;
using ApplicationsServices.Features.Queries.SelectAllQueries;
using ApplicationsServices.Features.Queries.SelectAllQueries.SelectPetQuery;
using ApplicationsServices.Features.Queries.SelectByQueries;
using ApplicationsServices.Features.Queries.SelectByQueries.SelectPetByIdQuery;
using ApplicationsServices.Filters.PetResponseFilter;
using Microsoft.AspNetCore.Mvc;

namespace Veterinary.WebApi.Controllers.v1._0
{
    [ApiVersion("1.0")]
    public class PetController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllPet([FromQuery] PetResponseFilter filter)
        {
            return Ok(await Mediator.Send(new SelectPetQuery
            {
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                petName = filter.petName,
                IsDeleted = filter.IsDeleted
            }));
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            return Ok(await Mediator.Send(new SelectPetByIdQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreatePetCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> Put(long id, UpdatePetCommand command)
        {
            if (id != command.Id)
                return BadRequest("Error en el Id suministrado no corresponde al registro a actualizar");
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            return Ok(await Mediator.Send(new DeletePetCommand { Id = id }));
        }
    }

}
