//BaseEntity=Esta clase tendrá todas las cosas que sean comunes para
//todas las entidades como un id, IdCreateBy, DateTime? CreateDate, IdLastModifiedBy y LastModifiedDate.
//todas las demás entidades van a heredar de aquí
using Veterinary.DomainClass.Entity;

namespace DomainClass.Common
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }
        public long IdCreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public long IdLastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsDeleted { get; set; }

        /// <summary>
        /// virtual significa sobreescribir, al heredar de una clase, la clase hija
        /// hereda todos los metodos y atributos de clase padre
        /// pero estos pueden ser modificados, esto es sobreescribir
        /// </summary>
        //#region Navigation Properties
        //public virtual User CreateBy { get; set; }
        //public virtual User LastModifiedBy { get; set; }
        //#endregion
        //Esto es lo de auditoria
        //virtual es sobreescribir

    }
}
