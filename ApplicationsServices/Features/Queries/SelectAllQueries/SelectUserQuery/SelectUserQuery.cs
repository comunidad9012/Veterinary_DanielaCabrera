using ApplicationsServices.Filters.UserResponseFilter;
using ApplicationsServices.Interfaces;
using ApplicationsServices.Specifications;
using ApplicationsServices.Specifications.PaginatedUserSpecification;
using ApplicationsServices.Wrappers;
using AutoMapper;
using MediatR;
using Veterinary.Core.DTOs;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Features.Queries.SelectAllQueries.SelectUserQuery
{
    public class SelectUserQuery : IRequest<PaginatedResponse<IEnumerable<UserFullDto>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? name { get; set; }
        public string? userSurname { get; set; }
        public bool IsDeleted { get; set; }

        public class SelectUserQueryHandler : IRequestHandler<SelectUserQuery, PaginatedResponse<IEnumerable<UserFullDto>>>
        {
            private readonly IRepository<User> _repository;
            private readonly IMapper _mapper;

            public SelectUserQueryHandler(IRepository<User> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }
            public async Task<PaginatedResponse<IEnumerable<UserFullDto>>> Handle(SelectUserQuery request, CancellationToken cancellationToken)
            {
                UserResponseFilter responseFilter = new UserResponseFilter()
                {
                    PageSize = request.PageSize,
                    PageNumber = request.PageNumber,
                    name = request.name,
                    userSurname = request.userSurname,
                    IsDeleted = request.IsDeleted
                };

                var users = await _repository.ListAsync(new PaginatedUserSpecification(responseFilter));
                var userFullDtos = _mapper.Map<IEnumerable<UserFullDto>>(users);
                return new PaginatedResponse<IEnumerable<UserFullDto>>(userFullDtos, request.PageNumber, request.PageSize, request.IsDeleted);
            }
        }
    }
}
