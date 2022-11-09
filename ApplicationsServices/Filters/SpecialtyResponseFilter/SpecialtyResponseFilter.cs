using ApplicationsServices.Wrappers;

namespace ApplicationsServices.Filters.SpecialtyResponseFilter
{
    public class SpecialtyResponseFilter : ParameterResponse
    {
        public string? specialty { get; set; }
        public bool IsDeleted { get; set; }

    }
}
