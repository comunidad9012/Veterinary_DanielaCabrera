using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Services.UserRolServices
{
    public interface IUserRolServices
    {
        public Task<int> Insert(UserRol userRol);
    }
}
