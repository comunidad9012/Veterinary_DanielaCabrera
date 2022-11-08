using ApplicationsServices.Wrappers;


namespace ApplicationsServices.Filters.PetTypeResponseFilter
{
    public class PetTypeResponseFilter : ParameterResponse
    {
        public string? type { get; set; }
    }
}
