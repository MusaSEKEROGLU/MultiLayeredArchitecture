using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiLayered.Core.Models;

namespace MultiLayered.Respository.Configurations
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.TeamPrice).IsRequired().HasColumnType("decimal(18,2)");

            builder.ToTable("Teams");

            //tablo ilişkileri
            builder.HasOne(x => x.Country).WithMany(x => x.Teams).HasForeignKey(x => x.CountryId);
        }
    }
}
