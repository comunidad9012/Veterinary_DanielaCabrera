using ApplicationsServices.Wrappers;


namespace ApplicationsServices.Filters.PetResponseFilter
{
    public class PetResponseFilter : ParameterResponse
    {
        public string? petName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
