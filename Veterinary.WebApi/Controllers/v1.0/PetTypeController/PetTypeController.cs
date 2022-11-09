//El controlador es el que se encarga de devolver a la vista la informacio que traigamos de la base de datos o viceversa. 
//La  informacion fluye: de la visata al cotrolador, del controlador a los repositorios y del repositorio a la base de datos y viceversa.
//El controlador es el que va a tener los comandos http que se van a ejecutar,
//los comandos que se condicen con lo que uno quiere hacer en la base de datos.
//Un comando select en la base de datos se llama get en http, insert es put, etc.
//Vamos a tener tantos controladores como datos que se van a querer modificar en la base de datos.
using ApplicationsServices.Features.Commands.CreateCommands.CreatePetTypeCommand;
using ApplicationsServices.Features.Commands.DeleteCommands.DeletePetTypeCommand;
using ApplicationsServices.Features.Commands.UpdateCommands.UpdatePetTypeCommand;
using ApplicationsServices.Features.Queries.SelectAllQueries;
using ApplicationsServices.Features.Queries.SelectAllQueries.SelectPetTypeQuery;
using ApplicationsServices.Features.Queries.SelectByQueries;
using ApplicationsServices.Features.Queries.SelectByQueries.SelectPetTypeByIdQuery;
using ApplicationsServices.Filters.PetTypeResponseFilter;
using Microsoft.AspNetCore.Mvc;

namespace Veterinary.WebApi.Controllers.v1._0
{

    [ApiVersion("1.0")]
    public class PetTypeController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllPetType([FromQuery] PetTypeResponseFilter filter)
        {
            return Ok(await Mediator.Send(new SelectPetTypeQuery
            {
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                type = filter.type,
                IsDeleted = filter.IsDeleted
            }));
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            return Ok(await Mediator.Send(new SelectPetTypeByIdQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreatePetTypeCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> Put(long id, UpdatePetTypeCommand command)
        {
            if (id != command.Id)
                return BadRequest("Error en el Id suministrado no corresponde al registro a actualizar");
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            return Ok(await Mediator.Send(new DeletePetTypeCommand { Id = id }));
        }
    }
}
