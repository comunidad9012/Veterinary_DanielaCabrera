//Data Object Transfer: Objeto de transferencia de datos. Es algo similar a la entidad que
//solo contiene los campos que quiero enviar a la vista.
//Si hay una tabla con 20 campos en un registro y se quieren enviar 5,
//la entidad tendrá 20 propiedades pero la DTO tendrá los 5 que se quieren enviar por la red.
//El mapeo se hará entre la entidad y el DTO, no con el modelo.
//Los datos se enviarán en un formato que sea en tipos de datos simples(string, int, bool, date ya no)
//Todos los tipos de datos complejos se deben convertir a tipo string, el tipo más simple que hay,
//para enviar por la red cadenas de caracteres sencillas que ocupan menos espacio que un tipo de dato complejo.
//El formato de dato que viaja por la red es de tipo json.
//Por esto debo aplanar los datos para enviarlos a través de la red. 
namespace Veterinary.Core.DTOs
{
    public class ClientFullDto
    {
        public long Id { get; set; } //Long es una dato de tipo numerico, en la base de datos(SQL) se coloca bigint(dato grande)
        public string? clientName { get; set; }
        public string? clientSurname { get; set; }
        public string? clientAdress { get; set; }
        public string? clientPhoneNum { get; set; }
        public string? clientIdn { get; set; }
        public string? email { get; set; }

        
    }
}
