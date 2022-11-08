using ApplicationsServices.Wrappers;

namespace ApplicationsServices.Filters.VisitResponseFilter
{
    public class VisitResponseFilter : ParameterResponse
    {
        public long petId { get; set; }
        public long vetId { get; set; }
        public DateTime visitDate { get; set; }
    }
}
