
namespace MultiLayered.Core.Models
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }

        //NavigationProperty
        public ICollection<Team> Teams { get; set; }
    }
}
