using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Services.VisitServices
{
    internal interface IVisitServices
    {
        public Task<int> Insert(Visit visit);
    }
}
