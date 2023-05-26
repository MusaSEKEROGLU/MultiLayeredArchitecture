
namespace MultiLayered.Core.Models
{
    public class TeamFeature
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public int LeagueCup { get; set; }
        public int EuropeanCup { get; set; }

        //NavigationProperty
        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}
