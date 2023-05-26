
namespace MultiLayered.Core.Dtos
{
    public class CountryWithTeamsDto : CountryDto
    {
        public List<TeamDto> Teams { get; set; }
    }
}
