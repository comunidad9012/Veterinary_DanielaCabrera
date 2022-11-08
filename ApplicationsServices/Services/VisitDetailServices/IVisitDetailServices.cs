using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Services.VisitDetailServices
{
    internal interface IVisitDetailServices
    {
        public Task<int> Insert(VisitDetail visitDetail);
    }
}
