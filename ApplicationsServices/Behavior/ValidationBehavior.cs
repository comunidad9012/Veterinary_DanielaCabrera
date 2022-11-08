//Behavior:significa comportamiento, esto quiere decir que aquí se 
//encuentran las validaciones las cuales están hechas con el paquete de fluent validation.
//Se encargarán de controlar el comportamiento de las validaciones de las peticiones.
//Validación:proceso que asegura la entrega de datos limpios y claros a los programas,
//aplicaciones y servicios que lo utilizan. Comprueba la integridad y validez de los datos
//que se están introduciendo en diferentes software y sus componentes. La validación de los datos
//garantiza que los datos cumplen con los requisitos y los parámetros de calidad.
using FluentValidation;
using MediatR;

namespace ApplicationsServices.Behavior

{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validator;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validator)
        {
            _validator = validator;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validator.Any())
            {
                var context = new FluentValidation.ValidationContext<TRequest>(request);
                //WhenAll: Crea una tarea que se completará cuando se hayan completado todas las tareas proporcionadas.
                var validationResult = await Task.WhenAll(_validator.Select(x => x.ValidateAsync(context, cancellationToken)));
                var failures = validationResult.SelectMany(v => v.Errors).Where(x => x != null).ToList();

                if (failures.Count != 0)
                {
                    throw new Exceptions.ValidationExceptions(failures);
                    //Exception significa error
                }
            }
            return await next();
        }
    }
}