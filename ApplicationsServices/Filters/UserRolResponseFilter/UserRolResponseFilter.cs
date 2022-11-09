using ApplicationsServices.Wrappers;

namespace ApplicationsServices.Filters.UserRolResponseFilter
{
    public class UserRolResponseFilter : ParameterResponse
    {
        public string? rol { get; set; }
        public bool IsDeleted { get; set; }

    }
}
