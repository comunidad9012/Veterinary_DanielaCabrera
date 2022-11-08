using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Services.PetServices
{
    public interface IPetServices
    {
        public Task<int> Insert(Pet pet);
    }
}
