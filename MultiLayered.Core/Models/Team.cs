
namespace MultiLayered.Core.Models
{
    public class Team : BaseEntity
    {
        public string Name { get; set; }
        public decimal TeamPrice { get; set; }

        //NavigationProperty
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public TeamFeature TeamFeature { get; set; }
    }
}
