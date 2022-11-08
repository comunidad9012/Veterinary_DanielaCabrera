using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Services.PetTypeServices
{
    public interface IPetTypeServices
    {
        public Task<int> Insert(PetType petType);
    }
}
