﻿using ApplicationsServices.Interfaces;
using Ardalis.Specification.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repository
{
    public class RepositoryCustom<T> : RepositoryBase<T>, IRepository<T> where T : class
    {
        private readonly VeterinaryAppContext _context;

        public RepositoryCustom(VeterinaryAppContext context) : base(context)
        {
            _context = context;
        }
    }
}
