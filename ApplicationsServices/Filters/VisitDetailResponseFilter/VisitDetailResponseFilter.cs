using ApplicationsServices.Wrappers;

namespace ApplicationsServices.Filters.VisitDetailResponseFilter
{
    public class VisitDetailResponseFilter : ParameterResponse
    {
        public long visitId { get; set; }
        public long procedureId { get; set; }
        public string? price { get; set; }
        public bool IsDeleted { get; set; }
    }
}
