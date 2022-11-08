using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Services.SpecialtyServices
{
    public interface ISpecialtyServices
    {
        public Task<int> Insert(Specialty specialty);
    }
}
