using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiLayered.Core.Models;


namespace MultiLayered.Respository.SeedData
{
    public class CountrySeed : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(new Country
            {
                Id = 1,
                Name = "Turkey",
            }, new Country
            {
                Id = 2,
                Name = "England"
            }, new Country
            {
                Id = 3,
                Name = "Spain"
            }, new Country
            {
                Id = 4,
                Name = "Italy"
            }, new Country
            {
                Id = 5,
                Name = "Germany"
            });
        }
    }
}
