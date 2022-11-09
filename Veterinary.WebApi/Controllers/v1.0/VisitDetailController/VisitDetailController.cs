using ApplicationsServices.Features.Commands.CreateCommands.CreateVisitDetailCommand;
using ApplicationsServices.Features.Commands.DeleteCommands.DeleteVisitDetailCommand;
using ApplicationsServices.Features.Commands.UpdateCommands.UpdateVisitDetailCommand;
using ApplicationsServices.Features.Queries.SelectAllQueries.SelectVisitDetailQuery;
using ApplicationsServices.Features.Queries.SelectByQueries.SelectVisitDetailByIdQuery;
using ApplicationsServices.Filters.VisitDetailResponseFilter;
using Microsoft.AspNetCore.Mvc;

namespace Veterinary.WebApi.Controllers.v1._0
{
    [ApiVersion("1.0")]
    public class VisitDetailController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllVisitDetail([FromQuery] VisitDetailResponseFilter filter)
        {
            return Ok(await Mediator.Send(new SelectVisitDetailQuery
            {
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                visitId = filter.visitId,
                procedureId = filter.procedureId,
                price = filter.price,
            }));
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            return Ok(await Mediator.Send(new SelectVisitDetailByIdQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateVisitDetailCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> Put(long id, UpdateVisitDetailCommand command)
        {
            if (id != command.Id)
                return BadRequest("Error en el Id suministrado no corresponde al registro a actualizar");
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            return Ok(await Mediator.Send(new DeleteVisitDetailCommand { Id = id }));
        }
    }
}
