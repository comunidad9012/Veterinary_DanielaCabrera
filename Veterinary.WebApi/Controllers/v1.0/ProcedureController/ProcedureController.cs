//El controlador es el que se encarga de devolver a la vista la informacio que traigamos de la base de datos o viceversa. 
//La  informacion fluye: de la vista al cotrolador, del controlador a los repositorios y del repositorio a la base de datos y viceversa.
//Vamos a tener tantos controladores como datos que se van a querer modificar en la base de datos.
//using ApplicationsServices.Features.Commands.CreateCommands.CreateProcedureCommand;
//using ApplicationsServices.Features.Commands.DeleteCommands.DeleteProcedureCommand;
//using ApplicationsServices.Features.Commands.UpdateCommands.UpdateProcedureCommand;
//using ApplicationsServices.Features.Queries.SelectAllQueries.SelectProcedureQuery;
//using ApplicationsServices.Features.Queries.SelectByQueries.SelectProcedureByIdQuery;
//using ApplicationsServices.Filters.ProcedureResponseFilter;
//using Microsoft.AspNetCore.Mvc;

//namespace Veterinary.WebApi.Controllers.v1._0
//{
//    [ApiVersion("1.0")]
//    public class ProcedureController : BaseApiController
//    {
//        [HttpGet]
//        public async Task<IActionResult> GetAllVet([FromQuery] ProcedureResponseFilter filter)
//        {
//            return Ok(await Mediator.Send(new SelectProcedureQuery
//            {
//                PageNumber = filter.PageNumber,
//                PageSize = filter.PageSize,
//                procedure = filter.procedure,
                
//            }));
//        }

//        [HttpGet("{id:long}")]
//        public async Task<IActionResult> GetById(long id)
//        {
//            return Ok(await Mediator.Send(new SelectProcedureByIdQuery { Id = id }));
//        }

//        [HttpPost]
//        public async Task<IActionResult> Post(CreateProcedureCommand command)
//        {
//            return Ok(await Mediator.Send(command));
//        }

//        [HttpPut("{id:long}")]
//        public async Task<IActionResult> Put(long id, UpdateProcedureCommand command)
//        {
//            if (id != command.Id)
//                return BadRequest("Error en el Id suministrado no corresponde al registro a actualizar");
//            return Ok(await Mediator.Send(command));
//        }

//        [HttpDelete("{id:long}")]
//        public async Task<IActionResult> Delete(long id)
//        {
//            return Ok(await Mediator.Send(new DeleteProcedureCommand { Id = id }));
//        }
//    }
//}
