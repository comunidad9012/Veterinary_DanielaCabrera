//Asocia la base de datos con el código
using DomainClass.Common;
using Microsoft.EntityFrameworkCore;
using Veterinary.DomainClass.Entity;

namespace Persistence.Contexts
{
    public class VeterinaryAppContext : DbContext
    {
        public VeterinaryAppContext(DbContextOptions<VeterinaryAppContext> options) : base(options)
        {
            //Configurar QueryTrackingBehavior como NoTracking impide el seguimiento de cambios
            //que se realizan en las entidades del contexto, por tal motivo, si se realizan cambios
            //estos no se veran reflejados en el base de datos.
            //ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        DbSet<Client> Clients { get; set; }
        DbSet<User> Users { set; get; }
        DbSet<Pet> Pets { get; set; }
        DbSet<PetType> PetTypes { get; set; }
        DbSet<Procedure> Procedures { get; set; }
        DbSet<Specialty> Specialties { get; set; }
        DbSet<UserRol> UserRol { get; set; }
        DbSet<Vet> Vets { get; set; }
        DbSet<Visit> Visits { get; set; }
        DbSet<VisitDetail> VisitDetails { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        //entry.Entity.IdLastModifiedBy = 0;
                        entry.Entity.LastModifiedDate = DateTime.UtcNow;
                        break;
                    case EntityState.Added:
                        //entry.Entity.IdCreateBy = 0;
                        entry.Entity.CreateDate = DateTime.UtcNow;
                        entry.Entity.LastModifiedDate = DateTime.UtcNow;
                        entry.Entity.IsDeleted = false;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        
    }
}

    
