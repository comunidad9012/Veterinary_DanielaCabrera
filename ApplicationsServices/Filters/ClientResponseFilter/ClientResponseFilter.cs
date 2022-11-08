using ApplicationsServices.Wrappers;

namespace ApplicationsServices.Filters.ClientResponseFilter
{
    public class ClientResponseFilter : ParameterResponse
    {
        public string? clientName { get; set; }
        public string? clientSurname { get; set; }
    }
}
