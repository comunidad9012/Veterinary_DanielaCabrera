using ApplicationsServices.Behavior;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ApplicationsServices
{
    public static class ServiceExtensions
    {
        //Para no tener que ir al program para hacer inyección de dependencias linea por línea.
        //Para eso la hago acá y en el program llamo a este para que llame a todos estos.
        //Todos los servicios matriculados aca haciendo referencia a
        //"AddApplicationLayer" seran reflejados en Program de la WEBAPI
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            //Registrar los mapeos que haga en esta biblioteca de clase automaticamente
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            //Implementa El patron Mediator
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}
