using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Services.ProcedureServices
{
    public interface IProcedureServices
    {
        public Task<int> Insert(Procedure procedure);
    }
}
