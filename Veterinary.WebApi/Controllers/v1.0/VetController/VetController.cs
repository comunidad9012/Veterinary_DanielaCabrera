//El controlador es el que se encarga de devolver a la vista la informacio que traigamos de la base de datos o viceversa. 
//La  informacion fluye: de la visata al cotrolador, del controlador a los repositorios y del repositorio a la base de datos y viceversa.using ApplicationsServices.Features.Commands.CreateCommands.CreateVetCommand;
using ApplicationsServices.Features.Commands.CreateCommands.CreateVetCommand;
using ApplicationsServices.Features.Commands.DeleteCommands.DeleteVetCommand;
using ApplicationsServices.Features.Commands.UpdateCommands.UpdateVetCommand;
using ApplicationsServices.Features.Queries.SelectAllQueries;
using ApplicationsServices.Features.Queries.SelectAllQueries.SelectVetQuery;
using ApplicationsServices.Features.Queries.SelectByQueries;
using ApplicationsServices.Features.Queries.SelectByQueries.SelectVetByIdQuery;
using ApplicationsServices.Filters.VetResponseFilter;
using Microsoft.AspNetCore.Mvc;

namespace Veterinary.WebApi.Controllers.v1._0
{
    [ApiVersion("1.0")]
    public class VetController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllVet([FromQuery] VetResponseFilter filter)
        {
            return Ok(await Mediator.Send(new SelectVetQuery
            {
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                vetName = filter.vetName,
                vetSurname = filter.vetSurname,
                IsDeleted = filter.IsDeleted
            }));
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            return Ok(await Mediator.Send(new SelectVetByIdQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateVetCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> Put(long id, UpdateVetCommand command)
        {
            if (id != command.Id)
                return BadRequest("Error en el Id suministrado no corresponde al registro a actualizar");
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            return Ok(await Mediator.Send(new DeleteVetCommand { Id = id }));
        }
    }
}
