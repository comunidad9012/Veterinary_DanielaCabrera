using ApplicationsServices.Wrappers;

namespace ApplicationsServices.Filters.ProcedureResponseFilter
{
    public class ProcedureResponseFilter : ParameterResponse
    {
        public string? procedure { get; set; }
        public bool IsDeleted { get; set; }

    }
}
