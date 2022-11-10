//El controlador es el que se encarga de devolver a la vista la informacio que traigamos de la base de datos o viceversa. 
//La  informacion fluye: de la vista al cotrolador, del controlador a los repositorios y del repositorio a la base de datos y viceversa.
//Vamos a tener tantos controladores como datos que se van a querer modificar en la base de datos.
//using ApplicationsServices.Features.Commands.CreateCommands.CreateVisitCommand;
//using ApplicationsServices.Features.Commands.DeleteCommands.DeleteVisitCommand;
//using ApplicationsServices.Features.Commands.UpdateCommands.UpdateVisitCommand;
//using ApplicationsServices.Features.Queries.SelectAllQueries.SelectVisitQuery;
//using ApplicationsServices.Features.Queries.SelectByQueries.SelectVisitByIdQuery;
//using ApplicationsServices.Filters.VisitResponseFilter;
//using Microsoft.AspNetCore.Mvc;

//namespace Veterinary.WebApi.Controllers.v1._0
//{
//    [ApiVersion("1.0")]
//    public class VisitController : BaseApiController
//    {
//        [HttpGet]
//        public async Task<IActionResult> GetAllVisit([FromQuery] VisitResponseFilter filter)
//        {
//            return Ok(await Mediator.Send(new SelectVisitQuery
//            {
//                PageNumber = filter.PageNumber,
//                PageSize = filter.PageSize,
//                petId = filter.petId,
//                vetId = filter.vetId,
//                visitDate=filter.visitDate,
//            }));
//        }

//        [HttpGet("{id:long}")]
//        public async Task<IActionResult> GetById(long id)
//        {
//            return Ok(await Mediator.Send(new SelectVisitByIdQuery { Id = id }));
//        }

//        [HttpPost]
//        public async Task<IActionResult> Post(CreateVisitCommand command)
//        {
//            return Ok(await Mediator.Send(command));
//        }

//        [HttpPut("{id:long}")]
//        public async Task<IActionResult> Put(long id, UpdateVisitCommand command)
//        {
//            if (id != command.Id)
//                return BadRequest("Error en el Id suministrado no corresponde al registro a actualizar");
//            return Ok(await Mediator.Send(command));
//        }

//        [HttpDelete("{id:long}")]
//        public async Task<IActionResult> Delete(long id)
//        {
//            return Ok(await Mediator.Send(new DeleteVisitCommand { Id = id }));
//        }
//    }
//}
