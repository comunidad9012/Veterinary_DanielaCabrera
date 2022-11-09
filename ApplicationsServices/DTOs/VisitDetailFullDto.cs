//la entidad tendrá 20 propiedades pero la DTO tendrá los 5 que se quieren enviar por la red.
//El mapeo se hará entre la entidad y el DTO, no con el modelo.
//Los datos se enviarán en un formato que sea en tipos de datos simples(string, int, bool, date ya no)
//Todos los tipos de datos complejos se deben convertir a tipo string, el tipo más simple que hay,
//para enviar por la red cadenas de caracteres sencillas que ocupan menos espacio que un tipo de dato complejo.
//El formato de dato que viaja por la red es de tipo json.
//Por esto debo aplanar los datos para enviarlos a través de la red.
namespace Veterinary.Core.DTOs
{
    public class VisitDetailFullDto
    {
        public long Id { get; set; }
        public long visitId { get; set; }
        public long procedureId { get; set; }
        public string? price { get; set; }
        public bool IsDeleted { get; set; }
    }
}
