//API:Las API permiten que sus productos y servicios se comuniquen con otros, sin necesidad de saber cómo están implementados. 
//Exceptions=Error
using System.Globalization;

namespace ApplicationsServices.Exceptions
{
    public class ApiExceptions : Exception
    {
        //muestra seguimientos detallados de la pila para detectar errores de servidor.
        //Utiliza DeveloperExceptionPageMiddleware para capturar excepciones sincrónicas
        //y asincrónicas de la canalización HTTP y para generar respuestas de error.
        public ApiExceptions() : base() { }
        public ApiExceptions(string message) : base(message) { }
        public ApiExceptions(string message, params object[] args) 
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {

        }
    }
}
