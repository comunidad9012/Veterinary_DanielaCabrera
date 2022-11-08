using DomainClass.Common;

namespace Veterinary.DomainClass.Entity
{
    public class Client : BaseEntity
    {
        
        //private string _password;
        public string? clientName { get; set; }
        public string? clientSurname { get; set; }
        public string? clientAdress { get; set; }
        public string? clientPhoneNum { get; set; }
        public string? clientIdn { get; set; }
        public string? email { get; set; }
        //public long userRol { get; set; }
        //public string Password { get => _password; set => _password = value.Encriptar(); }
        //esto de arriba es nuevo
        //cada vez que mande un valor al password este va a encriptar y lo va a guardar dentro del password
    }
}
