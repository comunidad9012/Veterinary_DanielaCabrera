using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Services.UserServices
{
    public interface IUserServices
    {
        public Task<int> Insert(User user);

    }
}
