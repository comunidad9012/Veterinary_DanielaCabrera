using ApplicationsServices.Wrappers;


namespace ApplicationsServices.Filters.UserResponseFilter
{
    public class UserResponseFilter : ParameterResponse
    {
        public string? name { get; set; }
        public string? userSurname { get; set; }
        public bool IsDeleted { get; set; }
    }
}
