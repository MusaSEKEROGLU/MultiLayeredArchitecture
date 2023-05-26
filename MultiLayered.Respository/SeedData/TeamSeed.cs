using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiLayered.Core.Models;

namespace MultiLayered.Respository.SeedData
{
    public class TeamSeed : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasData(new Team
            {
                Id = 1,
                CountryId = 1,
                TeamPrice = 500000,
                Name = "Galatasaray SK",
                CreatedDate = DateTime.Now
            }, new Team
            {
                Id = 2,
                CountryId = 1,
                TeamPrice = 400000,
                Name = "Fenerbahce SK",
                CreatedDate = DateTime.Now
            }, new Team
            {
                Id = 3,
                CountryId = 1,
                TeamPrice = 300000,
                Name = "Besiktas JK",
                CreatedDate = DateTime.Now
            }, new Team
            {
                Id = 4,
                CountryId = 1,
                TeamPrice = 200000,
                Name = "Trabzonspor SK",
                CreatedDate = DateTime.Now
            }, new Team
            {
                Id = 5,
                CountryId = 1,
                TeamPrice = 100000,
                Name = "Basaksehir FC",
                CreatedDate = DateTime.Now
            }, new Team
            {
                Id = 6,
                CountryId = 2,
                TeamPrice = 15000000,
                Name = "Manchester City",
                CreatedDate = DateTime.Now
            }, new Team
            {
                Id = 7,
                CountryId = 2,
                TeamPrice = 14000000,
                Name = "Manchester UTD",
                CreatedDate = DateTime.Now
            }, new Team
            {
                Id = 8,
                CountryId = 2,
                TeamPrice = 12000000,
                Name = "Chesea FC",
                CreatedDate = DateTime.Now
            }, new Team
            {
                Id = 9,
                CountryId = 3,
                TeamPrice = 11480000,
                Name = "Barcelona FC",
                CreatedDate = DateTime.Now
            }, new Team
            {
                Id = 10,
                CountryId = 3,
                TeamPrice = 14000000,
                Name = "Real Madrid FC",
                CreatedDate = DateTime.Now
            }, new Team
            {
                Id = 11,
                CountryId = 3,
                TeamPrice = 12220000,
                Name = "Atetico Madrid FC",
                CreatedDate = DateTime.Now
            }, new Team
            {
                Id = 12,
                CountryId = 4,
                TeamPrice = 15420000,
                Name = "Juventus FC",
                CreatedDate = DateTime.Now
            }, new Team
            {
                Id = 13,
                CountryId = 4,
                TeamPrice = 12670000,
                Name = "Internazional FC",
                CreatedDate = DateTime.Now
            }, new Team
            {
                Id = 14,
                CountryId = 4,
                TeamPrice = 14790000,
                Name = "Inter Milan FC",
                CreatedDate = DateTime.Now
            }, new Team
            {
                Id = 15,
                CountryId = 4,
                TeamPrice = 155500000,
                Name = "Napoli FC",
                CreatedDate = DateTime.Now
            }, new Team
            {
                Id = 16,
                CountryId = 4,
                TeamPrice = 13330000,
                Name = "Roma FC",
                CreatedDate = DateTime.Now
            }, new Team
            {
                Id = 17,
                CountryId = 5,
                TeamPrice = 12550000,
                Name = "Bayern Munch",
                CreatedDate = DateTime.Now
            }, new Team
            {
                Id = 18,
                CountryId = 5,
                TeamPrice = 11000000,
                Name = "Borusia Dortmund",
                CreatedDate = DateTime.Now
            });
        }
    }
}
