//El controlador es el que se encarga de devolver a la vista la informacio que traigamos de la base de datos o viceversa. 
//La  informacion fluye: de la vista al cotrolador, del controlador a los repositorios y del repositorio a la base de datos y viceversa.
//Vamos a tener tantos controladores como datos que se van a querer modificar en la base de datos.
//using ApplicationsServices.Features.Commands.CreateCommands.CreateUserRolCommand;
//using ApplicationsServices.Features.Commands.DeleteCommands.DeleteUserRolCommand;
//using ApplicationsServices.Features.Commands.UpdateCommands.UpdateUserRolCommand;
//using ApplicationsServices.Features.Queries.SelectAllQueries;
//using ApplicationsServices.Features.Queries.SelectAllQueries.SelectUserRolQuery;
//using ApplicationsServices.Features.Queries.SelectByQueries;
//using ApplicationsServices.Features.Queries.SelectByQueries.SelectUserRolByIdQuery;
//using ApplicationsServices.Filters.UserRolResponseFilter;
//using Microsoft.AspNetCore.Mvc;

//namespace Veterinary.WebApi.Controllers.v1._0
//{
//    [ApiVersion("1.0")]
//    public class UserRolController : BaseApiController
//    {
//        [HttpGet]
//        public async Task<IActionResult> GetAllUserRol([FromQuery] UserRolResponseFilter filter)
//        {
//            return Ok(await Mediator.Send(new SelectUserRolQuery
//            {
//                PageNumber = filter.PageNumber,
//                PageSize = filter.PageSize,
//                rol = filter.rol,
//                IsDeleted = filter.IsDeleted

//            }));
//        }

//        [HttpGet("{id:long}")]
//        public async Task<IActionResult> GetById(long id)
//        {
//            return Ok(await Mediator.Send(new SelectUserRolByIdQuery { Id = id }));
//        }

//        [HttpPost]
//        public async Task<IActionResult> Post(CreateUserRolCommand command)
//        {
//            return Ok(await Mediator.Send(command));
//        }

//        [HttpPut("{id:long}")]
//        public async Task<IActionResult> Put(long id, UpdateUserRolCommand command)
//        {
//            if (id != command.Id)
//                return BadRequest("Error en el Id suministrado no corresponde al registro a actualizar");
//            return Ok(await Mediator.Send(command));
//        }

//        [HttpDelete("{id:long}")]
//        public async Task<IActionResult> Delete(long id)
//        {
//            return Ok(await Mediator.Send(new DeleteUserRolCommand { Id = id }));
//        }
//    }
//}
