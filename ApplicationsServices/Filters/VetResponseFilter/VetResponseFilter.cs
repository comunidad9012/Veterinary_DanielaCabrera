using ApplicationsServices.Wrappers;

namespace ApplicationsServices.Filters.VetResponseFilter
{
    public class VetResponseFilter : ParameterResponse
    {
        public string? vetName { get; set; }
        public string? vetSurname { get; set; }
    }
}
