using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Services.VetServices
{
    public interface IVetServices
    {
        public Task<int> Insert(Vet vet);
    }
}
