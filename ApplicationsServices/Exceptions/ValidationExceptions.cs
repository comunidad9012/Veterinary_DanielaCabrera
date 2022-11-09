//Los errores de validación, captura los errores de validación
//La validación es verifica si los datos son correctos o no, les da el visto bueno si todo está bien.
//Tambíen se fija si por ejmeplo ese dato es muy extenso o no, o si tiene un caracter no permitido
//como un - en un correo, |ejemplo-2@gmail.com|
using FluentValidation.Results;

namespace ApplicationsServices.Exceptions
{
    public class ValidationExceptions : Exception
    {
        public List<string> Errors { get; set; }
        public ValidationExceptions() : base("Existen uno o más errores de validación.")
        {
            Errors = new List<string>();
        }
        //Recolecta las validaciones que larga "ValidationFailure"
        public ValidationExceptions(IEnumerable<ValidationFailure> failures) : this()
        {
            //Recorre todos los errores y lo va agregando al listado de errores
            foreach (var failure in failures)
            {
                //Imprime el ErrorMessage
                Errors.Add(failure.ErrorMessage);
            }
        }
    }
}
