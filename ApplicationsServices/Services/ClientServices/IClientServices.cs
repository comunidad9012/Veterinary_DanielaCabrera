using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Services.ClientServices
{
    public interface IClientServices
    {
        public Task<int> Insert(Client client);

    }
}
