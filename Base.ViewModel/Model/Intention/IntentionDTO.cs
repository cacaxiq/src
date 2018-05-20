namespace Base.ViewModel.Model.Intention
{
    public class IntentionDTO :BaseDTO
    {
        public long Rent { get; set; }
        public string ProspectId { get; set; }
        public long LowestPrice { get; set; }
        public long MaximumPrice { get; set; }
        public long Bedroom { get; set; }
        public long State { get; set; }
        public string City { get; set; }
        public string Neighborhood { get; set; }
        public long PropertyType { get; set; }
        public long PropertySituation { get; set; }
    }
}
